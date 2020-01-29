using System;
using System.Threading;
using Autofac;

namespace Chippo.Core.Component
{
    public interface IComponent
    {
        ApplicationState Update(TimeSpan delta);
    }
}