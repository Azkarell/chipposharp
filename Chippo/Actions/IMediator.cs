﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chippo.Actions
{

    interface IMediator
    {
        Task Publish(IEvent @event);
        void Subscribe(IEventHandler eventHandler);
    }
}