using Microsoft.Xna.Framework;

using System;

namespace PewPew.Engine.Structures
{
	public struct MotionStructure : System.IEquatable<MotionStructure>
	{
		private const float GravityConst = 6.67e-11f;
		// Gravity is Gravity const(6.67 X 10^-11) times the Mass of object1 times mass of object2 divided by distance between objects squared

		private Vector2 GravitationForce { get; set; }

		public Vector2 CurrentPosition { get; private set; }
		public float Thrust { get; private set; }
		public float Mass { get; private set; }

		private Vector2 PreviousPosition { get; set; }
		private Vector2 Propulsion { get; set; }
		private float PreviousSpeed { get; set; }
		private DateTime LastUpdate { get; set; }

		private Vector2 VelocityVector { get => Vector2.Subtract(PreviousPosition, CurrentPosition); } // use current and previous Positions to get, also can use other objects
		private float TravelDistance { get => Vector2.Distance(PreviousPosition, CurrentPosition); }
		private TimeSpan ElapsedTime { get => DateTime.Now - LastUpdate; }
		private float MilisecondsPassed { get => (float)ElapsedTime.TotalMilliseconds; }
		private float CurrentSpeed { get => TravelDistance * MilisecondsPassed; }
		private float Acceleration { get => CurrentSpeed - PreviousSpeed; } // positive increases speed, negative decreases speed

		//float AngularDisplacement; // = angle of change between previous and current.
		//float AngularVelocity; // = radians / time;
		//float AngularAcceleration; // = NetTorque / RotationalInertia;
		//float NetTorque; // = RotationalInertia * AngularAccelertion;
		//float RotationalInertia;

		public MotionStructure(Vector2 currentPosition, float mass) : this()
		{
			CurrentPosition = currentPosition;
			PreviousPosition  = currentPosition;

			Mass = mass;
			LastUpdate = DateTime.Now;
		}

		public void Update()
		{
			// logic needed for movement and Rotation
		}

		#region Equatable

		public override bool Equals(object obj)
			=> obj is MotionStructure @object
			&& CurrentPosition == @object.CurrentPosition
			&& PreviousPosition == @object.PreviousPosition
			&& TravelDistance == @object.TravelDistance
			&& Propulsion == @object.Propulsion
			&& Thrust == @object.Thrust
			&& Acceleration == @object.Acceleration
			&& PreviousSpeed == @object.PreviousSpeed
			&& CurrentSpeed == @object.CurrentSpeed
			&& VelocityVector == @object.VelocityVector
			&& Mass == @object.Mass
			&& LastUpdate == @object.LastUpdate
			&& ElapsedTime == @object.ElapsedTime
			&& MilisecondsPassed == @object.MilisecondsPassed;

		public bool Equals(MotionStructure other)
			=> CurrentPosition == other.CurrentPosition
			&& PreviousPosition == other.PreviousPosition
			&& TravelDistance == other.TravelDistance
			&& Propulsion == other.Propulsion
			&& Thrust == other.Thrust
			&& Acceleration == other.Acceleration
			&& PreviousSpeed == other.PreviousSpeed
			&& CurrentSpeed == other.CurrentSpeed
			&& VelocityVector == other.VelocityVector
			&& Mass == other.Mass
			&& LastUpdate == other.LastUpdate
			&& ElapsedTime == other.ElapsedTime
			&& MilisecondsPassed == other.MilisecondsPassed;

		public override int GetHashCode()
		{
			int hashCode = 639005060;
			hashCode = hashCode * -1529135295 + CurrentPosition.GetHashCode();
			hashCode = hashCode * -1529135295 + PreviousPosition.GetHashCode();
			hashCode = hashCode * -1529135295 + TravelDistance.GetHashCode();
			hashCode = hashCode * -1529135295 + Propulsion.GetHashCode();
			hashCode = hashCode * -1529135295 + Thrust.GetHashCode();
			hashCode = hashCode * -1529135295 + Acceleration.GetHashCode();
			hashCode = hashCode * -1529135295 + PreviousSpeed.GetHashCode();
			hashCode = hashCode * -1529135295 + CurrentSpeed.GetHashCode();
			hashCode = hashCode * -1529135295 + VelocityVector.GetHashCode();
			hashCode = hashCode * -1529135295 + Mass.GetHashCode();
			hashCode = hashCode * -1529135295 + LastUpdate.GetHashCode();
			hashCode = hashCode * -1529135295 + ElapsedTime.GetHashCode();
			hashCode = hashCode * -1529135295 + MilisecondsPassed.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(MotionStructure left, MotionStructure right)
			=> left.Equals(right);

		public static bool operator !=(MotionStructure left, MotionStructure right)
			=> !(left == right);

		#endregion Equatable
	}
}