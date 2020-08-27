using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParseViewAndNative
{
    public static class Solutions
    {
        public static string[] Extensions = new string[] { ".pdf", ".dwg", ".rvt", ".xod", ".jpg", ".jpeg", ".pptx", ".docx", ".doc", ".xlsx" };

        // solution by adam o
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

        // solution by nick s
        public static (string view, string native) ParseViewAndNative2(string[] array)
        {
            if (array.Length == 1) return (array[0], array[0]);

            var viewIndex = 0;
            string viewFile = null;
            var nativeIndex = 1;
            string nativeFile = null;

            while (viewFile == null || nativeFile == null)
            {
                // view file must be set first
                if (viewFile == null)
                {
                    // index out of range exception handler
                    if (viewIndex > Extensions.Length - 1)
                        viewFile = array[0];
                    else
                    {

                        viewFile = array.FirstOrDefault(x => x.Contains(Extensions[viewIndex]));
                        if (viewFile == null)
                        {
                            viewIndex++;
                            nativeIndex++;
                        }
                    }
                }
                else
                {
                    // index out of range exception handler
                    if (nativeIndex > Extensions.Length - 1)
                    {
                        nativeFile = array.FirstOrDefault(x => x != viewFile);
                        break;
                    }

                    nativeFile = array.FirstOrDefault(x => x.Contains(Extensions[nativeIndex]));
                    nativeIndex++;
                };

            };

            return (viewFile, nativeFile);
        }

    }
}