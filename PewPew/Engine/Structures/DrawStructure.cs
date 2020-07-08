using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PewPew.Engine.Drawable;

namespace PewPew.Engine.Structures
{
    public struct DrawStructure : System.IEquatable<DrawStructure>
    {
        public DrawStructure(Vector2 scale, float layerDepth, Color tint, SpriteEffects effects, float scaleModifer)
        {
            Scale = scale;
            LayerDepth = layerDepth;
            Tint = tint;
            Effects = effects;
            ScaleModifer = scaleModifer;
        }

        public Vector2 Scale { get; set; }
        public float LayerDepth { get; set; }
        public Color Tint { get; set; }
        public SpriteEffects Effects { get; set; }
        public float ScaleModifer { get; set; }


        #region Equatable
        public bool Equals(DrawStructure other)
            => Scale.Equals(other.Scale)
               && ScaleModifer.Equals(other.ScaleModifer)
               && LayerDepth == other.LayerDepth
               && Tint.Equals(other.Tint)
               && Effects == other.Effects;
        public override bool Equals(object obj)
            => obj is DrawStructure @object
               && Scale.Equals(@object.Scale)
               && LayerDepth == @object.LayerDepth
               && Tint.Equals(@object.Tint)
               && ScaleModifer.Equals(@object.ScaleModifer)
               && Effects == @object.Effects;
        public override int GetHashCode()
        {
            int hashCode = 639965060;
            hashCode = hashCode * -1522753295 + Scale.GetHashCode();
            hashCode = hashCode * -1522753295 + ScaleModifer.GetHashCode();
            hashCode = hashCode * -1522753295 + LayerDepth.GetHashCode();
            hashCode = hashCode * -1522753295 + Tint.GetHashCode();
            hashCode = hashCode * -1522753295 + Effects.GetHashCode();
            hashCode = hashCode * -1522753295 + ScaleModifer.GetHashCode();
            return hashCode;
        }
        public static bool operator ==(DrawStructure left, DrawStructure right)
            => left.Equals(right);
        public static bool operator !=(DrawStructure left, DrawStructure right)
            => !(left == right);
        #endregion
    }
}
