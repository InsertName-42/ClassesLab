using System;
using System.Collections.Generic;

namespace DominoClasses
{
    public class Hand
    {
        //Stores hand
        private List<Domino> dominos;

        //Constructors
        public Hand()
        {
            dominos = new List<Domino>();
        }

        //Properties
        public int Count
        {
            get { return dominos.Count; }
        }

        //Methods
        public void Add(Domino d)
        {
            dominos.Add(d);
        }

        public void Remove(Domino d)
        {
            dominos.Remove(d);
        }

        public Domino GetDomino(Domino d)
        {
            int index = dominos.IndexOf(d);
            if (index != -1)
            {
                return dominos[index];
            }
            return null;
        }

        public bool Contains(Domino d)
        {
            return dominos.Contains(d);
        }

        public override string ToString()
        {
            if (dominos.Count == 0)
            {
                return "Hand is empty.";
            }

            string result = "Hand: ";
            foreach (Domino d in dominos)
            {
                result += d.ToString() + " ";
            }
            return result.Trim();
        }
    }
}