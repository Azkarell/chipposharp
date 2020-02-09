using System;
using System.Collections.Generic;

namespace Chippo.Core.Input.Axis
{
    class AxisProvider: IAxisProvider
    {
        private readonly IAxisFactory factory;
        private readonly Dictionary<string,IAxis2D> axis2Ds = new Dictionary<string, IAxis2D>();

        public AxisProvider(IAxisFactory factory)
        {
            this.factory = factory;
        }


        public void Register(string name, Axis2DConfiguration configuration)
        {
            Register(name,factory.CreateAxis2D(configuration));
        }

        public void Register(string name, IAxis2D axis2D)
        {
            axis2Ds[name] = axis2D;
        }

        public IAxis2D GetAxis2D(string name)
        {
            if (axis2Ds.TryGetValue(name, out var axis))
            {
                return axis;
            }
            throw new ArgumentException($"Axis not found: {name}");
        }
    }
}