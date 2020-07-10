using PewPew.Engine.Drawable;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PewPew.Engine.Structures
{
	public struct AnimationStructure : IEquatable<AnimationStructure>
	{
		private Dictionary<string, Animation> Animations;
		private bool IsInitialized;
		private int CurrentIndex;
		private string AnimationKey;
		private bool Animate;

		public int Index
		{
			get
			{
				CurrentIndex = Animate ? Animations[AnimationKey].FrameIndex : CurrentIndex;
				return CurrentIndex;
			}
		}

		public AnimationStructure(Animation animation)
		{
			Animations = new Dictionary<string, Animation>();
			CurrentIndex = 0;
			AnimationKey = animation.Name;
			Animations[AnimationKey] = animation;
			Animate = false;

			IsInitialized = true;
		}
		public AnimationStructure(Dictionary<string, Animation> animations)
		{
			Animations = new Dictionary<string, Animation>();
			CurrentIndex = 0;
			for (int i = 0; i < animations.Count; i++)
			{
				AnimationKey = animations.Keys.ElementAt(i);
				Animations[AnimationKey] = animations.Values.ElementAt(i);
			}

			Animate = false;
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

		public void StopAnimation() => Animate = false;

		public void StartAnimation(string name)
		{
			AnimationKey = name ?? throw
				new Exception($"An attempt to change the Animation Key failed " +
							  $"because the string name provided was null.");
			Animate = true;
		}

		public Animation GetAnimation(int index) => Animations[Animations.Keys.ElementAt(index)];

		public Dictionary<string, Animation> GetAllAnimations => Animations;

		#region Overrides

		public override bool Equals(object obj)
			=> obj is AnimationStructure @object
			   && AnimationKey == @object.AnimationKey
			   && Animate == @object.Animate
			   && Animations.Equals(@object.Animations);

		public bool Equals(AnimationStructure other)
			=> AnimationKey == other.AnimationKey
			   && Animate == other.Animate
			   && Animations.Equals(other.Animations);

		public override int GetHashCode()
		{
			int hashCode = 639375060;
			hashCode = hashCode * -1529434295 + AnimationKey.GetHashCode();
			hashCode = hashCode * -1529434295 + Animate.GetHashCode();
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