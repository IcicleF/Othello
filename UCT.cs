using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class UCT
    {
        internal class Node
        {
            static readonly double Exploration = 1.00;

            public Board board;
            public sbyte step;
            public ulong nextSteps;
            public int depth;

            public Node? parent;
            public bool terminal;
            public int accessed;
            public int score;
            public Dictionary<sbyte, Node> children;

            public Node(Node? parent, Board board, sbyte step)
            {
                this.board = board;
                this.step = step;
                this.nextSteps = board.GetCurrentValidPositions();
                this.depth = (parent?.depth ?? 0) + 1;

                this.parent = parent;
                this.terminal = board.IsTerminal();
                this.accessed = 0;
                this.score = 0;
                this.children = new();
                this.step = step;
            }

            public bool IsTerminal { get { return terminal; } }

            public double UCTValue
            {
                get
                {
                    if (parent == null)
                        return 0;
                    if (accessed == 0)
                        return double.MaxValue;
                    return 1.0 * score / accessed + 
                        Exploration * Math.Sqrt(2.0 * Math.Log(parent.accessed) / accessed);
                }
            }

            internal Node? GetBestChild()
            {
                if (children.Count == 0)
                    return null;

                Node? ret = null;
                foreach (var child in children)
                {
                    if (child.Value.UCTValue > (ret?.UCTValue ?? double.MinValue))
                        ret = child.Value;
                }
                return ret;
            }
        }

        Node root;

        public UCT(Board board)
        {
            root = new Node(null, board, -1);
        }

        public Node SelectNode(Node node)
        {
            while (!node.IsTerminal)
            {
                Node? next = node.GetBestChild();
                if (next == null)
                {
                    Expand(node);
                    return node.GetBestChild();
                }
                node = next;
            }
            return node;
        }

        public void Expand(Node node)
        {
            ulong actions = node.board.GetCurrentValidPositions();

            // I have no action to perform, but I am also not a terminal, so I must pass
            if (actions == 0)
            {
                var newBoard = node.board.Clone();
                newBoard.Pass();
                node.children.Add(-1, new Node(node, newBoard, -1));
                return;
            }

            while (actions > 0)
            {
                ulong act = actions & (actions ^ (actions - 1));
                actions -= act;
                sbyte actCompressed = Board.OneHotToCompressed(act);

                var (x, y) = Board.ToXYCoord(act);
                var newBoard = node.board.Clone();
                newBoard.Play(x, y);
                node.children.Add(actCompressed, new Node(node, newBoard, actCompressed));
            }
        }

        public sbyte Rollout(Board board)
        {
            // TODO
            return 0;
        }
    }
}
