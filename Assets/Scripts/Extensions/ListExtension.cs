using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ListExtension
    {
        private static readonly Random Randomizer = new ();
        
        public static T PopRandom<T>(this List<T> source)
        {
            var indexOfTheElement = Randomizer.Next(source.Count);
            return source.Pop(indexOfTheElement);
        }
        
        public static T Pop<T>(this List<T> source, int index)
        {
            var item = source[index];
            source.RemoveAt(index);
            return item;
        }
    }    
}


