using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    //IEnumerable<Domino>
    public abstract class Train : IEnumerable<Domino>
    {
        protected List<Domino> dominos;
        protected int engineValue;

        //Constructors
        public Train()
        {
            dominos = new List<Domino>();
            engineValue = 1;
        }

        public Train(int engValue)
        {
            dominos = new List<Domino>();
            engineValue = engValue;
        }

        //Properties
        public int Count
        {
            get { return dominos.Count; }
        }

        public int EngineValue
        {
            get { return engineValue; }
            set { engineValue = value; }
        }

        public bool IsEmpty
        {
            get { return dominos.Count == 0; }
        }

        public Domino LastDomino
        {
            get
            {
                if (IsEmpty)
                {
                    return null;
                }
                return dominos[dominos.Count - 1];
            }
        }

        public int PlayableValue
        {
            get
            {
                if (IsEmpty)
                {
                    return engineValue;
                }
                return LastDomino.Side2;
            }
        }

        public Domino this[int index]
        {
            get
            {
                if (index < 0 || index >= dominos.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                return dominos[index];
            }
        }

        //Methods
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);

        public void Play(Hand h, Domino d)
        {
            bool mustFlip = false;
            if (IsPlayable(h, d, out mustFlip))
            {
                //IsPlayable logic determines if a flip is needed.
                if (mustFlip && d.Side1 != PlayableValue)
                {
                    d.Flip();
                }


                Add(d);
                //Remove domino from hand after playing
                h.Remove(d);
            }
            else
            {
                throw new ArgumentException("Domino is not playable on this train.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Engine: [{engineValue}] - ");
            if (IsEmpty)
            {
                sb.Append("Empty Train");
            }
            else
            {
                foreach (Domino d in dominos)
                {
                    sb.Append($"{d.ToString()} ");
                }
            }
            return sb.ToString().Trim();
        }

        //IEnumerator for foreach loops
        public IEnumerator<Domino> GetEnumerator()
        {
            return dominos.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}