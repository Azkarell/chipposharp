﻿using Chippo.Input.Axis;

namespace Chippo.Input.Mouses
{
    public abstract class WheelDirection: IDirection
    {
        private float value = 0;
        private bool isActive = true;

        public WheelDirection(ILoop loop)
        {
            loop.Ticked += (sender, args) => { value = 0; };
        }
        public float GetValue()
        {
            return value;
        }

        protected void UpdateValue(float val)
        {
            if (isActive)
            {
                value += val;
            }
        }


    }
}