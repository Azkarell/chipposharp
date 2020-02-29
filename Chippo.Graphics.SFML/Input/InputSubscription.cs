using System;
using Chippo.Core.Interfaces;

namespace Chippo.Graphics.SFML.Input
{
    public class InputSubscription : ISubscription
    {
        private readonly Action unsubscribe;
        private bool unsubscribed;

        public InputSubscription(Action unsubscribe)
        {
            this.unsubscribe = unsubscribe;
        }

        public void Unsubscribe()
        {
            if (unsubscribed) return;
            unsubscribe();
            unsubscribed = true;
        }


    }
}