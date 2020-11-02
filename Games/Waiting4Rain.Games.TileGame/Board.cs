using System.Collections.Generic;

namespace Waiting4Rain.Games.TileGame
{
    public class Board : List<List<string>>
    {
        public static bool operator ==(Board obj1, Board obj2)
        {
            if (ReferenceEquals(obj1, obj2))
            {
                return true;
            }
            if (ReferenceEquals(obj1, null))
            {
                return false;
            }
            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(Board obj1, Board obj2)
        {
            return !(obj1 == obj2);
        }

        public override bool Equals(object obj)
        {
            Board other = obj as Board;
            if (other == null)
            {
                return false;
            }
            if (this.Count == 0 & other.Count == 0)
                return true;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
