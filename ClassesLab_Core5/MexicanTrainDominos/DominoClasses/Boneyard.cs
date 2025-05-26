using System;
using System.Collections.Generic;
using System.Linq;

namespace DominoClasses
{
    public class Boneyard
    {
        private List<Domino> dominos;
        private Random generator;

        public Boneyard(int maxDots)
        {
            dominos = new List<Domino>();
            generator = new Random(); // Initialize Random object here

            // Populate the boneyard with all possible unique dominoes up to maxDots
            for (int i = 0; i <= maxDots; i++)
            {
                for (int j = i; j <= maxDots; j++)
                {
                    dominos.Add(new Domino(i, j));
                }
            }
        }

        public int NumDominos
        {
            get
            {
                return dominos.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (dominos.Count == 0);
            }
        }

        public Domino this[int i]
        {
            get
            {
                if (i < 0 || i >= dominos.Count)
                    throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range.");
                return dominos[i];
            }
            set
            {
                if (i < 0 || i >= dominos.Count)
                    throw new ArgumentOutOfRangeException(nameof(i), "Index is out of range.");
                dominos[i] = value;
            }
        }

        public Domino Deal()
        {
            if (!IsEmpty)
            {
                Domino d = dominos[0];
                dominos.RemoveAt(0);
                return d;
            }
            return null; // Or throw an exception if dealing from an empty boneyard is not allowed
        }

        public void Shuffle()
        {
            for (int i = 0; i < NumDominos; i++)
            {
                int rnd = generator.Next(0, NumDominos);
                Domino d = dominos[rnd];
                dominos[rnd] = dominos[i];
                dominos[i] = d;
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (Domino d in dominos)
            {
                output += (d.ToString() + "\n");
            }
            return output;
        }
    }
}