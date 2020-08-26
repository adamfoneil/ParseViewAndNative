using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace ParseViewAndNative.Tests
{
    [TestClass]
    public class FileExtParsing
    {       
        [TestMethod]
        public void SampleCases()
        {
            var cases = new[]
            {
                new
                {
                    input = new string[] { "file.doc", "file.dwg", "file.doc", "file.rvt", "file.sketch" } ,
                    output = ("file.dwg", "file.rvt")
                },
                new
                {
                    input = new string[] { "apple.sd", "apple.af", "apple.xlsx", "apple.doc", "apple.j" },
                    output = ("apple.doc", "apple.xlsx")
                },
                new
                {
                    input = new string[] { "cats.doc", "cats.pdf", "cats.cats", "cats.doc", "cats.rvt", "cats.sketch" },
                    output = ("cats.pdf", "cats.rvt")
                },
                new
                {
                    input = new string[] { "banana.doc", "banana.dwg", "banana.pdf", "banana.pdf", "banana.doc", "banana.rvt", "banana.sketch" },
                    output = ("banana.pdf", "banana.dwg")
                },
                new
                {
                    input = new string[] { "file.doc" },
                    output = ("file.doc", "file.doc")
                },
                new
                {
                    input = new string[] { "file.sketch", "file.txt", "file.doc" },
                    output = ("file.doc", "file.sketch")
                },
                new
                {
                    input = new string[] { "file.sketch", "file.doc", "file.txt" },
                    output= ("file.doc", "file.sketch")                    
                }
            };

            Assert.IsTrue(cases.All(c => Program.ParseViewAndNative(c.input).Equals(c.output)));
        }
    }
}
