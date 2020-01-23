using Chippo.Actions;
using Chippo.Actions.System;
using Chippo.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using static SFML.Window.Keyboard;

namespace Chippo.Input
{
    class InputMapper : IInputMapper
    {
        private readonly IMediator<Guid, string> mediator;
        private readonly IKeyboardEventFactory<Guid,string> keyboardEventFactory;

        public InputMapper(IMediator<Guid, string> mediator, IKeyboardEventFactory<Guid,string> keyboardEventFactory)
        {
            this.mediator = mediator;
            this.keyboardEventFactory = keyboardEventFactory;
        }
        public void HandleMove(MouseMoveEventArgs s)
        {
            //nothing right now
        }

        public void HandlePressed(KeyEventArgs s)
        {
            var ev = keyboardEventFactory.Create(s);
            if(ev != null)
            {
                mediator.Publish(ev);
            }
        }

        public void HandlePressed(MouseButtonEventArgs s)
        {
            //nothing right now
        }

        public void HandleReleased(KeyEventArgs s)
        {
            //nothing right now
        }

        public void HandleReleased(MouseButtonEventArgs s)
        {
            //nothing right now
        }

        public void HandleWheel(MouseWheelScrollEventArgs s)
        {
            //nothing right now
        }
    }
}
