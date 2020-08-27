using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace ParseViewAndNative
{
    public static class Program
    {
        public static string[] Extensions = new string[] { ".pdf", ".dwg", ".rvt", ".xod", ".jpg", ".jpeg", ".pptx", ".docx", ".doc", ".xlsx" };

        static void Main(string[] args)
        {
            // problem: given an array return the top two files according to the priority (left to right of the extension array above)
            // the first file returned should be farther left than the second
            // the first file is the view file , the second is the native file
            // if there is only one file it should be both the view and the native file
            // if there is a view file but no native according to the extension list -> the native should be the first file in the array that is not the view file
            // if neither a view file or native file is present according to the priority list. the view file and native file need to be the first two files in the list
            // you can cheat by looking at the current solutions in solutions.cs

            // Steps to play
            // Place your code in the method below
            // uncomment code at end of file in ParseViewAndNative.Tests/FileExtParsing.cs
            // open a terminal 
            // cd into ParseViewAndNative.Tests
            // run "dotnet test"
            // the terminal will decide

        }

        public static (string view, string native) ParseViewAndNative3(string[] array)
        {
            // only change code below 👇 . you can also change string[] to IEnumerable<string>
            return ("hello", "world");

        }





    }
}
