using Microsoft.Xna.Framework;

using System;

namespace PewPew.Engine.Structures
{
    public struct MotionStructure : System.IEquatable<MotionStructure>
    {
        private const float GravityConst = 6.67e-11f;
        private Vector2 CurrentPosition;
        private Vector2 PreviousPosition;
        private Vector2 Propulsion;
        private float Thrust;
        private Vector2 VelocityVector { get => Vector2.Subtract(PreviousPosition, CurrentPosition); } // use current and previous Positions to get, also can use other objects
        private float TravelDistance { get => Vector2.Distance(PreviousPosition, CurrentPosition); }

        private DateTime LastUpdate; //CurrentTime after final Update;
        private TimeSpan ElapsedTime { get => DateTime.Now - LastUpdate; } // LastUpdate - DateTime.Now;
        private float MilisecondsPassed { get => (float)ElapsedTime.TotalMilliseconds; }
        private float CurrentSpeed { get => TravelDistance * MilisecondsPassed; } // Distance over time;
        private float PerviousSpeed;
        private Vector2 Acceleration{ get =>  // positive increases speed, negative decreases speed

        public float Mass { get; private set; } // weight of object - used in calculations
        
        // Gravity is Gravity const(6.67 X 10^-11) times Mass of object 1 times mass of object 2 divided by distance between objects squared
        // Object 1 mass: 100,  Object2 mass: 10 
        //float AngularDisplacement; // = angle of change between start and finish.
        //float AngularVelocity; // = radians / time;
        //float AngularAcceleration; // = NetTorque / RotationalInertia;
        //float NetTorque; // = RotationalInertia * AngularAccelertion;
        //float RotationalInertia;

        public MotionStructure(Vector2 currentPosition, float mass) : this()
        {
            ElapsedMiliseconds = DateTime.Now.Millisecond - LastUpdate.Millisecond;
            CurrentPosition = currentPosition;
            PreviousPosition = currentPosition;

            Mass = mass;
            LastUpdate = DateTime.Now;
        }














        #region Equatable
        public override bool Equals(object obj)
            => obj is MotionStructure @object;
        


        public bool Equals(MotionStructure other)
            => LinearForce == other.LinearForce
               && Position.Equals(other.Position)
               && LinearMomentum == other.LinearMomentum
               && LinearVelocity == other.LinearVelocity
               && LinearModifer == other.LinearModifer
               && RotationalForce == other.RotationalForce
               && RotationalModifer.Equals(other.RotationalModifer)
               && Rotation == other.Rotation
               && RotationalVelocity == other.RotationalVelocity;
        public override int GetHashCode()
        {
            int hashCode = 639005060;
            hashCode = hashCode * -1521134295 + Position.GetHashCode();
            hashCode = hashCode * -1521134295 + LinearVelocity.GetHashCode();
            hashCode = hashCode * -1521134295 + LinearMomentum.GetHashCode();
            hashCode = hashCode * -1521134295 + LinearForce.GetHashCode();
            hashCode = hashCode * -1521134295 + LinearModifer.GetHashCode();
            hashCode = hashCode * -1521134295 + RotationalVelocity.GetHashCode();
            hashCode = hashCode * -1521134295 + RotationalForce.GetHashCode();
            hashCode = hashCode * -1521134295 + Rotation.GetHashCode();
            hashCode = hashCode * -1521134295 + RotationalModifer.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(MotionStructure left, MotionStructure right)
            => left.Equals(right);
        public static bool operator !=(MotionStructure left, MotionStructure right)
            => !(left == right);
        #endregion
    }
}
