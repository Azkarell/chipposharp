namespace Chippo.Math
{
    public struct Radians
    {
        public double Value { get; }

        public Radians(double value)
        {
            Value = value;
        }

        public Degree ToDegree()
        {
            return new Degree(Value / System.Math.PI * 180);
        }

    }
}