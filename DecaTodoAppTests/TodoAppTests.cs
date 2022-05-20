using DecaTodoApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DecaTodoAppTests
{
    [TestClass]
    public class TodoAppTests
    {
        [TestMethod()]
        public void AddAndPrintTest()
        {
            TodoApp todoApp = new TodoApp();
            todoApp.UseTestEnvironment();

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                todoApp.Add("This is a test");
                string expected = "#1 This is a test\r\n";

                Assert.AreEqual(expected, sw.ToString());
            }

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                todoApp.Add("Another item");
                string expectedPrint = "#2 Another item\r\n#1 This is a test\r\n#2 Another item\r\n";
                todoApp.Print();

                Assert.AreEqual(expectedPrint, sw.ToString());
            }
        }

        [TestMethod()]
        public void DoTest()
        {
            TodoApp todoApp = new TodoApp();
            todoApp.UseTestEnvironment();
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            todoApp.Add("This is a test");
            todoApp.Add("Another string");
            todoApp.Do(1);
            string expected = "#1 This is a test\r\n#2 Another string\r\nCompleted #1 This is a test\r\n";

            Assert.AreEqual(expected, sw.ToString());
        }
    }
}
