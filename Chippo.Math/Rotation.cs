namespace Chippo.Math
{
    public class Rotation
    {

        public Rotation(Degree degree)
        {
            InRadians = degree.ToRadians();
        }

        public Rotation(Radians radians)
        {
            InRadians = radians;
        }

        public Radians InRadians { get;  }
        public Degree InDegree => InRadians.ToDegree();

        public Rotation Add(Rotation rotation)
        {
            return new Rotation(new Radians(InRadians.Value + rotation.InRadians.Value));
        }

        public static Rotation Zero { get; } = new Rotation(new Radians(0));
        public static Rotation D90 { get; } = new Rotation(new Degree(90));
        public static Rotation D180 { get; } = new Rotation(new Degree(180));
        public static Rotation D270 { get; } = new Rotation(new Degree(270));

        public static Rotation FromDegree(double value)
        {
            return new Rotation(new Degree(value));
        }

        public static Rotation FromRadians(double value)
        {
            return new Rotation(new Radians(value));
        }
    }
}