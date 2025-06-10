using System;
using System.Collections.Generic;

namespace DominoClasses
{
    //IComparable<Domino>
    public class Domino : IComparable<Domino>
    {
        private int side1;
        private int side2;

        //Define sides
        public int Side1
        {
            get
            {
                return side1;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side1 = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Side1), "Value must be between 0 and 12.");
            }
        }

        public int Side2
        {
            get
            {
                return side2;
            }
            set
            {
                if (value >= 0 && value <= 12)
                    side2 = value;
                else
                    throw new ArgumentOutOfRangeException(nameof(Side2), "Value must be between 0 and 12.");
            }
        }
        //Construct
        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        public Domino(int p1, int p2)
        {
            Side1 = p1;
            Side2 = p2;
        }

        //Methods
        public void Flip()
        //Reverses order (no effect on value)
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        public int Score
        //Addition, disregard order
        {
            get
            {
                return side1 + side2;
            }
        }

        public bool IsDouble()
        {
            return side1 == side2;
        }

        //Overrides
        public override string ToString()
        {
            return $"[{side1}|{side2}]";
        }

        public override bool Equals(object obj)
        {
            //Equality does not consider order
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            else
            {
                Domino other = (Domino)obj;
                return (this.Side1 == other.Side1 && this.Side2 == other.Side2) ||
                       (this.Side1 == other.Side2 && this.Side2 == other.Side1);
            }
        }

        public override int GetHashCode()
        {
            //Does not consider order
            return (Side1 < Side2) ? (13 + 7 * Side1.GetHashCode() + 7 * Side2.GetHashCode()) :
                                     (13 + 7 * Side2.GetHashCode() + 7 * Side1.GetHashCode());
        }

        //Operators
        public static bool operator ==(Domino d1, Domino d2)
        {
            if (ReferenceEquals(d1, null))
            {
                return ReferenceEquals(d2, null);
            }
            return d1.Equals(d2);
        }

        public static bool operator !=(Domino d1, Domino d2)
        {
            return !(d1 == d2);
        }

        //IComparable
        public int CompareTo(Domino other)
        {
            if (other == null) return 1;

            //Compare based on Score
            return this.Score.CompareTo(other.Score);
        }
    }
}