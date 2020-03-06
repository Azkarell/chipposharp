namespace Chippo.Math
{
    public class RotationAngle
    {

        public RotationAngle(Degree degree)
        {
            InRadians = degree.ToRadians();
        }

        public RotationAngle(Radians radians)
        {
            InRadians = radians;
        }

        public Radians InRadians { get;  }
        public Degree InDegree => InRadians.ToDegree();

        public RotationAngle Add(RotationAngle rotationAngle)
        {
            return new RotationAngle(new Radians(InRadians.Value + rotationAngle.InRadians.Value));
        }

        public static RotationAngle Zero { get; } = new RotationAngle(new Radians(0));
        public static RotationAngle D90 { get; } = new RotationAngle(new Degree(90));
        public static RotationAngle D180 { get; } = new RotationAngle(new Degree(180));
        public static RotationAngle D270 { get; } = new RotationAngle(new Degree(270));

        public static RotationAngle FromDegree(double value)
        {
            return new RotationAngle(new Degree(value));
        }

        public static RotationAngle FromRadians(double value)
        {
            return new RotationAngle(new Radians(value));
        }
    }
}