using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace Waiting4Rain.Games.TileGame
{
    public class Board : List<List<string>>
    {
        public const string FreeCell = "__";

        public void MoveTile(string direction)
        {
            var xOffset = 0;
            var yOffset = 0;
            if (direction == "right") xOffset = -1;
            if (direction == "left") xOffset = 1;
            if (direction == "up") yOffset = 1;
            if (direction == "down") yOffset = -1;
            int row = -1;
            int col = -1;
            for (var r = 0; r < Count; r++)
            {
                if (this[r].Contains(FreeCell))
                {
                    row = r;
                    col = this[r].IndexOf(FreeCell);
                }
            }
            if (col == 0 & direction == "right") return;
            if (row == 0 & direction == "down") return;
            if (col == this[0].Count - 1 & direction == "left") return;
            if (row == Count -1 & direction == "up") return;
            this[row][col] = this[row + yOffset][col +xOffset];
            this[row + yOffset][col + xOffset] = FreeCell;
        }

        public static bool operator ==(Board leftBoard, Board rightBoard)
        {
            if (ReferenceEquals(leftBoard, rightBoard))
            {
                return true;
            }
            if (leftBoard is null)
            {
                return false;
            }
            if (rightBoard is null)
            {
                return false;
            }

            return leftBoard.Equals(rightBoard);
        }

        public static bool operator !=(Board leftBoard, Board rightBoard)
        {
            return !(leftBoard == rightBoard);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            Board other = obj as Board;
            if (Count != other.Count)
                return false;
            for (var r = 0; r < Count; r++)
            {
                if (this[r].Count != other[r].Count) return false;
            }
            for (var r = 0; r < Count; r++)
            {
                for (var c = 0; c < this[r].Count; c++)
                {
                    if (!this[r][c].Equals(other[r][c])) return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            // This is not a good idea - see Richter.
            return base.GetHashCode();
        }
    }
}
