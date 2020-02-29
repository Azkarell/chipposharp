using Chippo.Core.Input;
using Chippo.Core.Input.Axis;
using Chippo.Core.Input.Axis.Interface;
using Chippo.Core.Interfaces;

namespace Chippo.GameObjects
{
    public class AxisSwitcher: StaticObject
    {

        private readonly Axis2DProxy axisProxy;
        private readonly IAxis2D[] axis2Ds;
        private uint cur = 0;
        private readonly ISubscription subscription;
        public AxisSwitcher(IInput input, Axis2DProxy axisProxy, IAxis2D[] axis2Ds)
        {
            this.axisProxy = axisProxy;
            this.axis2Ds = axis2Ds;
            subscription = input.SubscribeOnPressed(KeyboardKey.R, OnPress);
        }

        private void OnPress()
        {
            axisProxy.SwitchImplementation(axis2Ds[cur++ % axis2Ds.Length]);
        }

        public override void OnRemove()
        {
            subscription.Unsubscribe();
        }
    }
}