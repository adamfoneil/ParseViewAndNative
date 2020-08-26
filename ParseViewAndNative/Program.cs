using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParseViewAndNative
{
    static class Program
    {
        public static string[] Extensions = new string[] { ".pdf", ".dwg", ".rvt", ".xod", ".jpg", ".jpeg", ".pptx", ".docx", ".doc", ".xlsx" };

        static void Main(string[] args)
        {            
            var result1 = ParseViewAndNative(new string[] { "file.doc", "file.dwg", "file.doc", "file.rvt", "file.sketch" });
            var result2 = ParseViewAndNative(new string[] { "apple.sd", "apple.af", "apple.xlsx", "apple.doc", "apple.j" });
            var result3 = ParseViewAndNative(new string[] { "cats.doc", "cats.pdf", "cats.cats", "cats.doc", "cats.rvt", "cats.sketch" });
            var result4 = ParseViewAndNative(new string[] { "banana.doc", "banana.dwg", "banana.pdf", "banana.pdf", "banana.doc", "banana.rvt", "banana.sketch" });
            var result5 = ParseViewAndNative(new string[] { "file.doc" });
            var result6 = ParseViewAndNative(new string[] { "file.sketch", "file.txt", "file.doc" });
            var result7 = ParseViewAndNative(new string[] { "file.sketch", "file.doc", "file.txt" });
        }

        public static (string view, string native) ParseViewAndNative(IEnumerable<string> fileNames)
        {
            if (fileNames.Count() == 1) return (fileNames.First(), fileNames.First());

            var view = findFileInExtList(0, fileNames);
            var native = findFileInExtList(view.index + 1, fileNames);

            return (view.fileName, native.fileName);

            (int index, string fileName) findFileInExtList(int startIndex, IEnumerable<string> fileNames)
            {
                for (int i = startIndex; i < Extensions.Length; i++)
                {
                    string result = fileNames.FirstOrDefault(fileName => Path.GetExtension(fileName).Equals(Extensions[i]));
                    if (!string.IsNullOrEmpty(result)) return (i, result);
                }

                return (0, fileNames.First());
            }            
        }        
    }
}
