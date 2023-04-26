using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    internal class Board
    {
        public const sbyte Empty = 0;
        public const sbyte White = 1;
        public const sbyte Black = 2;

        public static readonly (sbyte, sbyte)[] offsets = { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        internal static bool IsCoordValid(sbyte x, sbyte y, sbyte dx, sbyte dy)
        {
            var (xx, yy) = (x + dx, y + dy);
            return xx >= 0 && xx < 8 && yy >= 0 && yy < 8;
        }

        internal static string NameOfColor(sbyte color)
        {
            return color switch
            {
                White => "White",
                Black => "Black",
                _ => throw new Exception("getting name of non-color"),
            };
        }

        internal static (sbyte x, sbyte y) ToXYCoord(sbyte compressed)
        {
            return ((sbyte)(compressed / 8), (sbyte)(compressed % 8));
        }

        internal static (sbyte x, sbyte y) ToXYCoord(ulong onehot)
        {
            return ToXYCoord((sbyte)BitOperations.TrailingZeroCount(onehot));
        }

        internal static sbyte OneHotToCompressed(ulong onehot)
        {
            return (sbyte)BitOperations.TrailingZeroCount(onehot);
        }

        ulong[] b = new ulong[2];
        sbyte steps = 0;
        bool player
        {
            get { return steps % 2 == 0; }
        }

        public Board()
        {
            b[0] = b[1] = 0;
            SetCell(3, 3, White);
            SetCell(4, 4, White);
            SetCell(3, 4, Black);
            SetCell(4, 3, Black);
        }

        public Board Clone()
        {
            var clone = new Board();
            clone.b[0] = b[0];
            clone.b[1] = b[1];
            clone.steps = steps;
            return clone;
        }

        public int GetStep()
        {
            return steps;
        }

        private void SetCell(sbyte x, sbyte y, sbyte color)
        {
            var index = (x * 8 + y) * 2;
            b[index / 64] &= ~((ulong)0b11 << (index % 64));
            b[index / 64] |= ((ulong)color << (index % 64));
        }

        public sbyte GetCell(sbyte x, sbyte y)
        {
            var index = (x * 8 + y) * 2;
            return (sbyte)(((b[index / 64]) >> (index % 64)) & 0b11);
        }

        public sbyte GetCurrentColor() => player ? Black : White;

        public bool IsEmpty(sbyte x, sbyte y) => GetCell(x, y) == Empty;

        public bool IsWhite(sbyte x, sbyte y) => GetCell(x, y) == White;

        public bool IsBlack(sbyte x, sbyte y) => GetCell(x, y) == Black;

        public bool IsSame(sbyte x, sbyte y, sbyte color) => GetCell(x, y) == color;

        public bool IsOpposite(sbyte x, sbyte y, sbyte color) => GetCell(x, y) == (color == Black ? White : Black);

        private void Flip(sbyte x, sbyte y, sbyte dx, sbyte dy)
        {
            var color = GetCell(x, y);
            for (sbyte i = 1; i < 8; ++i)
            {
                var (xx, yy) = (x + dx * i, y + dy * i);
                if (!IsOpposite((sbyte)xx, (sbyte)yy, color))
                    break;
                SetCell((sbyte)xx, (sbyte)yy, color);
            }
        }

        /// <summary>
        /// Make the current player play a chess at the given position.
        /// The validity of the move will not be validated.
        /// </summary>
        /// <param name="x">X coordinate (0~7).</param>
        /// <param name="y">Y coordinate (0~7).</param>
        public void Play(sbyte x, sbyte y)
        {
            var color = GetCurrentColor();
            steps++;

            SetCell(x, y, color);
            foreach ((sbyte dx, sbyte dy) in offsets) {
                if (IsValidInDirection(x, y, dx, dy, color))
                    Flip(x, y, dx, dy);
            }
        }

        /// <summary>
        /// Make the current player skip his move.
        /// </summary>
        public void Pass() => steps++;

        public (int empty, int white, int black) Count()
        {
            int empty = 0, white = 0, black = 0;
            for (sbyte x = 0; x < 8; ++x)
            {
                for (sbyte y = 0; y < 8; ++y)
                {
                    switch (GetCell(x, y)) {
                        case Empty: empty++; break;
                        case White: white++; break;
                        default: black++; break;
                    }
                }
            }
            return (empty, white, black);
        }

        public bool IsValidInDirection(sbyte x, sbyte y, sbyte dx, sbyte dy, sbyte color)
        {
            if (!IsCoordValid(x, y, dx, dy) || !IsOpposite((sbyte)(x + dx), (sbyte)(y + dy), color))
                return false;
            for (sbyte i = 2; i < 8; ++i)
            {
                if (!IsCoordValid(x, y, (sbyte)(dx * i), (sbyte)(dy * i))
                    || IsEmpty((sbyte)(x + dx * i), (sbyte)(y + dy * i)))
                    return false;
                if (IsSame((sbyte)(x + dx * i), (sbyte)(y + dy * i), color))
                    return true;
            }
            return false;
        }

        public ulong GetValidPositions(sbyte color)
        {
            ulong ret = 0;
            for (sbyte x = 0; x < 8; ++x)
            {
                for (sbyte y = 0; y < 8; ++y)
                {
                    if (!IsOpposite(x, y, color))
                        continue;
                    foreach ((sbyte dx, sbyte dy) in offsets)
                    {
                        if (IsCoordValid(x, y, dx, dy) && IsEmpty((sbyte)(x + dx), (sbyte)(y + dy)))
                        {
                            if (IsValidInDirection((sbyte)(x + dx), (sbyte)(y + dy), (sbyte)-dx, (sbyte)-dy, color))
                                ret |= (ulong)1 << ((x + dx) * 8 + (y + dy));
                        }
                    }
                }
            }
            return ret;
        }

        public ulong GetCurrentValidPositions() => GetValidPositions(GetCurrentColor());

        public bool IsTerminal() => GetValidPositions(White) == 0 && GetValidPositions(Black) == 0;
    }
}
