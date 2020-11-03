using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Waiting4Rain.Games.TileGame
{
    public class Board : List<List<string>>
    {
        public static bool operator ==(Board leftBoard, Board rightBoard)
        {
            if (ReferenceEquals(leftBoard, rightBoard))
            {
                return true;
            }
            if (ReferenceEquals(leftBoard, null))
            {
                return false;
            }
            if (ReferenceEquals(rightBoard, null))
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
            Board other = obj as Board;
            if (other == null)
            {
                return false;
            }
            // Test type equality.
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
