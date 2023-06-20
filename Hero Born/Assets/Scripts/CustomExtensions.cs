using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// This namespace will hold all class extension and class extension methods
namespace CustomExtensions
{
    // A static class for a particular type of extension
    public static class StringExtensions
    {
        /* A class extension method
         * string is the class being extended
         * str is a local reference for the existing class
         *  (i.e. the value it has)
         */
        public static void FancyDebug(this string str)
        {
            Debug.Log($"This string contains {str.Length} characters");
        }
    }
}