using UnityEngine;

namespace Extensions
{
    public static class RandomExtension
    {
        private static readonly Color[] AcceptableColors = 
        {
            Color.yellow,
            Color.blue,
            Color.green,
            Color.red,
            Color.magenta
        };

        public static Color RandomizeColor(this System.Random randomizer) 
            => AcceptableColors[randomizer.Next(AcceptableColors.Length)];
    }
}