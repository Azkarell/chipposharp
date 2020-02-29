namespace Chippo.Math
{
    public struct Degree
    {
        public double Value { get; }


        public Degree(double value)
        {
            Value = value;
        }

        public Radians ToRadians()
        {
            return new Radians(Value / 180 * System.Math.PI);
        }
    }
}