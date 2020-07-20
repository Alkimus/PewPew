using PewPew.Engine.Drawable;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PewPew.Engine.Structures
{
	/// <summary>
	/// This Structure holds all the aspects of the Animation. Mainly a sequencer for cycling frames.
	/// Index is the main output, should be used as the frames index.
	/// </summary>
	public struct AnimationStructure : IEquatable<AnimationStructure>
	{
		private Dictionary<string, Animation> Animations;
		private bool IsInitialized; // bool value indicates the structure is initialized
		private int CurrentIndex; // This is the output of the animation structure
		private string AnimationKey; // string index used asthe dictionary key
		private bool Active; // bool indicating Animation is active

		public int Index
		{
			get
			{
				CurrentIndex = Active ? Animations[AnimationKey].FrameIndex : CurrentIndex;
				return CurrentIndex;
			}
		}


		/// <summary>
		/// Constructor for the Animations Structure
		/// </summary>
		/// <param name="animation">the first Animation for the Dictionary, it gets the key from the animation.</param>
		public AnimationStructure(Animation animation)
		{
			Animations = new Dictionary<string, Animation>();
			CurrentIndex = animation.FrameIndex;
			AnimationKey = animation.Name;
			Animations[AnimationKey] = animation;
			Active = false;

			IsInitialized = true;
		}

		/// <summary>
		/// Cnstructor for the Animation Structure with ability to pass a dictionary to it 
		/// </summary>
		/// <param name="animations">A dictionary to pass in</param>
		public AnimationStructure(Dictionary<string, Animation> animations)
		{
			Animations = new Dictionary<string, Animation>();
			CurrentIndex = 0;
			for (int i = 0; i < animations.Count; i++)
			{
				AnimationKey = animations.Keys.ElementAt(i);
				Animations[AnimationKey] = animations.Values.ElementAt(i);
			}

			Active = false;
			AnimationKey = animations.Keys.ElementAt(0);
			IsInitialized = true;
		}
		private void Initialize()
		{
			Animations = new Dictionary<string, Animation>();
			IsInitialized = true;
		}

		public void AddAnimation(Animation animation)
		{
			if (!IsInitialized) Initialize();
			Animations.Add(animation.Name, animation);
		}

		public void RemoveAnimation(string name)
		{
			if (!IsInitialized)
			{
				throw new Exception($"Animation Structure failed to remove Animation:{name} " +
									$"because the Structure has not been initialized.");
			}
			else { Animations.Remove(name); }
		}

		public void StopAnimation() => Active = false;

		public void StartAnimation() => Active = true;

		public void ActivateAnimation(string name)
		{
			AnimationKey = name ?? throw
				new Exception($"An attempt to change the Animation Key failed " +
							  $"because the string name provided was null.");
			Active = true;
		}

		public void SwitchAnimation(string name)
		{
			AnimationKey = name ?? throw
				new Exception($"An attempt to change the Animation Key failed " +
							  $"because the string name provided was null.");
		}

		public Animation GetAnimation(int index)
		{
			if (!IsInitialized)
			{
				throw new Exception($"Animation Structure failed to retrieve the current Animation," +
									$"because the Structure has not been initialized.");
			}
			return Animations[Animations.Keys.ElementAt(index)];
		}

		public Animation GetAnimation() => Animations[AnimationKey];
		public Dictionary<string, Animation> GetAllAnimations => Animations;

		#region Overrides

		public override bool Equals(object obj)
			=> obj is AnimationStructure @object
			   && AnimationKey == @object.AnimationKey
			   && Active == @object.Active
			   && Animations.Equals(@object.Animations);

		public bool Equals(AnimationStructure other)
			=> AnimationKey == other.AnimationKey
			   && Active == other.Active
			   && Animations.Equals(other.Animations);

		public override int GetHashCode()
		{
			int hashCode = 639375060;
			hashCode = hashCode * -1529434295 + AnimationKey.GetHashCode();
			hashCode = hashCode * -1529434295 + Active.GetHashCode();
			hashCode = hashCode * -1529434295 + Animations.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(AnimationStructure left, AnimationStructure right)
			=> left.Equals(right);

		public static bool operator !=(AnimationStructure left, AnimationStructure right)
			=> !(left == right);

		#endregion Overrides
	}
}