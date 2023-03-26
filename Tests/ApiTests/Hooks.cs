using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTestingFramework.Tests.ApiTests
{
    internal class Hooks
    {

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test started");
        }
    }
}
