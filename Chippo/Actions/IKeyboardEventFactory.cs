using Chippo.Common;
using SFML.Window;
using System;

namespace Chippo.Actions
{
    interface IKeyboardEventFactory: 
        IFactory<KeyEventArgs,IEvent>

    {
        IEvent? Create(KeyEventArgs s);
    }
}