using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class MexicanTrain : Train
    {
        //Constructors
        public MexicanTrain() : base() { }

        public MexicanTrain(int engineValue) : base(engineValue) { }

        //Abstract IsPlayable method
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;

            //Train is empty, first domino played must match the engine value.
            if (IsEmpty)
            {
                if (d.Side1 == EngineValue)
                {
                    return true;
                }
                else if (d.Side2 == EngineValue)
                {
                    mustFlip = true;
                    return true;
                }
                return false;
            }
            //Train is not empty
            else
            {
                //Playable if either side matches the PlayableValue
                if (d.Side1 == PlayableValue)
                {
                    return true;
                }
                else if (d.Side2 == PlayableValue)
                {
                    mustFlip = true;
                    return true;
                }
                return false;
            }
        }
    }
}