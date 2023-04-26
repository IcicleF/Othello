using System.Collections;

namespace Othello
{
    public partial class Form1 : Form
    {
        private Button[,] boardButtons = new Button[8,8];
        private List<Board> boards = new();
        private Board board
        {
            get { return boards.Last(); }
        }

        public Form1()
        {
            InitializeComponent();
            boards.Add(new Board());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            const int BORDER = 20, SIZE = 55, SKIP = 5;
            for (sbyte i = 0; i < 8; i++)
            {
                Label label = new();
                label.Text = Convert.ToString((char)('A' + i));
                label.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label.Name = "lblHorizontal_" + i.ToString();
                label.Location = new System.Drawing.Point(BORDER + (SIZE + SKIP) * i + SIZE / 2 + 10, BORDER);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(SIZE / 2, BORDER * 2);
                grpBoard.Controls.Add(label);
            }
            for (sbyte i = 0; i < 8; i++)
            {
                Label label = new();
                label.Text = Convert.ToString((char)('1' + i));
                label.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label.Name = "lblVertical_" + i.ToString();
                label.Location = new System.Drawing.Point(BORDER / 2, BORDER * 2 + (SIZE + SKIP) * i + SIZE / 2);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(SIZE / 2, BORDER * 2);
                grpBoard.Controls.Add(label);
            }

            for (sbyte i = 0; i < 8; i++)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    boardButtons[i, j] = new Button();
                    boardButtons[i, j].Location = 
                        new System.Drawing.Point(BORDER * 2 + (SIZE + SKIP) * i, BORDER * 3 + (SIZE + SKIP) * j);
                    boardButtons[i, j].Name = "btnCell_" + i.ToString() + j.ToString();
                    boardButtons[i, j].Size = new Size(SIZE, SIZE);
                    boardButtons[i, j].Tag = (i, j);
                    boardButtons[i, j].Click += BoardButtonClick;
                    boardButtons[i, j].Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    grpBoard.Controls.Add(boardButtons[i, j]);
                }
            }
            RenderUI();
        }

        private void BoardButtonClick(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                (sbyte x, sbyte y) = ((sbyte, sbyte))(sender as Button).Tag;
                lstHistory.Items.Add(
                    Board.NameOfColor(board.GetCurrentColor()) + " "
                    + Convert.ToString((char)('A' + x)) + (y + 1).ToString()
                    );

                Board newBoard = board.Clone();
                newBoard.Play(x, y);
                boards.Add(newBoard);

                RenderUI();
                Task.Run(() => RestartAI());
            }
        }

        delegate void SetAIProgressBar(int value);

        private void RestartAI()
        {
            Board b = board.Clone();
            if (prgAI.InvokeRequired)
            {
                while (!prgAI.IsHandleCreated)
                {
                    if (prgAI.Disposing || prgAI.IsDisposed)
                        return;
                }
                SetAIProgressBar d = new SetAIProgressBar((int value) => prgAI.Value = value);
                prgAI.Invoke(d, 0);
            }
            else
            {
                prgAI.Value = 0;
            }

            const int BATCH = 100;
            int AITime = hScrollBarAITime.Value * 1000;
            var startTime = DateTime.Now;
            while (true)
            {
                var elapsed = DateTime.Now - startTime;
                var elapsedPercentage = (int)(100.0 * elapsed.TotalMilliseconds / AITime);
                if (elapsedPercentage >= 100)
                    elapsedPercentage = 100;

                // Update progress bar
                if (prgAI.InvokeRequired)
                {
                    while (!prgAI.IsHandleCreated)
                    {
                        if (prgAI.Disposing || prgAI.IsDisposed)
                            return;
                    }
                    SetAIProgressBar d = new((int value) => prgAI.Value = value);
                    prgAI.Invoke(d, elapsedPercentage);
                }
                else
                {
                    prgAI.Value = elapsedPercentage;
                }

                if (elapsedPercentage == 100)
                    break;

                // Do MCTS search
                // TODO


                // Check whether UI has been updated
                if (board.GetStep() != b.GetStep())
                    break;
            }
        }

        private void RenderUI()
        {
            lblAITime.Text = hScrollBarAITime.Value.ToString();

            var valid = board.GetCurrentValidPositions();
            for (sbyte i = 0; i < 8; i++)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    bool isCandidate = (valid & ((ulong)1 << (i * 8 + j))) != 0;
                    boardButtons[i, j].BackColor = board.GetCell(i, j) switch
                    {
                        Board.Empty => isCandidate ? Color.Yellow : Color.LightGray,
                        Board.White => Color.White,
                        Board.Black => Color.Black,
                        _ => throw new Exception("unexpected color"),
                    };
                    boardButtons[i, j].Enabled = isCandidate;
                }
            }

            (_, int white, int black) = board.Count();
            lblWinLose.Text = "Black " + black.ToString() + "    /    White " + white.ToString();

            if (valid == 0)
            {
                var passed = board.GetCurrentColor();
                Board newBoard = board.Clone();
                newBoard.Pass();
                boards.Add(newBoard);

                lstHistory.Items.Add(Board.NameOfColor(passed) + " Pass");

                valid = board.GetCurrentValidPositions();
                if (valid != 0)
                {
                    MessageBox.Show(Board.NameOfColor(passed) + " passed!", "Passed a move", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    RenderUI();
                }
                else
                {
                    MessageBox.Show("No possible moves, finish!", "End of the game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            this.Focus();
        }

        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = lstHistory.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var ret = MessageBox.Show("Rollback to before move " + index.ToString() + "?", "History", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ret == DialogResult.Yes)
                {
                    while (lstHistory.Items.Count > index)
                    {
                        boards.RemoveAt(boards.Count - 1);
                        lstHistory.Items.RemoveAt(lstHistory.Items.Count - 1);
                    }
                    RenderUI();
                }
            }
        }

        private void hScrollBarComputeTime_Scroll(object sender, ScrollEventArgs e)
        {
            lblAITime.Text = hScrollBarAITime.Value.ToString();
        }
    }
}