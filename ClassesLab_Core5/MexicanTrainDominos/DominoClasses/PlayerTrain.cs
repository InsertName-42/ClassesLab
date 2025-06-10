using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public class PlayerTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        //Constructors
        //Player train starts closed
        public PlayerTrain(Hand h) : base()
        {
            hand = h;
            isOpen = false;
        }

        public PlayerTrain(Hand h, int engineValue) : base(engineValue)
        {
            hand = h;
            isOpen = false;
        }

        //Properties
        public bool IsOpen
        {
            get { return isOpen; }
        }

        //Methods
        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        //Abstract IsPlayable
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;

            //Open or first domino played.
            if (this.hand == h || IsOpen)
            {
                //If empty, the first domino played must match the engine value.
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
                    //Side matches the PlayableValue?
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
            return false;
        }
    }
}