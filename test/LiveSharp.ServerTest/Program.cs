using LiveSharp.Runtime;
using System;
using System.IO;
using System.Threading;

namespace LiveSharp.ServerTest
{
    public class Program
    {
        public static void Main()
        {
            using var serverProcess = ServerProcess.Instance;

            serverProcess.DoAndWaitForOutput(() => serverProcess.Start(), "Welcome to LiveSharp!", 15000);
            
            var solutionPath = "C:\\!Hive\\LiveSharp\\LiveSharp.sln";
            var buildPath = "C:\\!Hive\\LiveSharp\\build";
            var projectDir = "C:\\!Hive\\LiveSharp\\test\\LiveSharp.BlazorTest.App";

            LiveSharpRuntime.Start("127.0.0.1", solutionPath, "LiveSharp.BlazorTest.App", projectDir, "", buildPath);
            // ServerProcess.Instance.DoAndWaitForOutput(
            //     () => , 
            //     "LiveSharp.BlazorTest.App", 3000);
            
            Thread.Sleep(10000);
        }
    }
}