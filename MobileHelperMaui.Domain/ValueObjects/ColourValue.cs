using MobileHelperMaui.Domain.Exceptions;
using MobileHelperMaui.Domain.Share;

namespace MobileHelperMaui.Domain.ValueObjects
{
    public class ColourValue : ValueObject
    {
        static ColourValue()
        {
        }

        private ColourValue()
        {
        }

        private ColourValue(string code)
        {
            this.Code = code;
        }

        public static ColourValue From(string code)
        {
            ColourValue colour = new() { Code = code };

            return !SupportedColours.Contains(colour) ? throw new UnsupportedColourValueException(code) : colour;
        }

        public static ColourValue Black => new("#000000");

        public static ColourValue Red => new("#FF5733");

        public static ColourValue Orange => new("#FFC300");

        public static ColourValue Yellow => new("#FFFF66");

        public static ColourValue Green => new("#CCFF99");

        public static ColourValue Blue => new("#6666FF");

        public static ColourValue Purple => new("#9966CC");

        public static ColourValue Gray => new("#999999");

        public string Code { get; private set; } = "#000000";

        public static implicit operator string(ColourValue colour)
        {
            return colour.ToString();
        }

        public static explicit operator ColourValue(string code)
        {
            return From(code);
        }

        public override string ToString()
        {
            return this.Code;
        }

        protected static IEnumerable<ColourValue> SupportedColours
        {
            get
            {
                yield return Black;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Gray;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Code;
        }
    }
}
