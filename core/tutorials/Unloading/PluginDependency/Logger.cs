using System;
using System.IO;
using Newtonsoft.Json;

namespace PluginDependency
{
    // This is a simple class to write message to console. It is present to demostrate
    // how a dependency of the plugin gets loaded into the HostAssemblyLoadContext
    public class Logger
    {
        public class CustomLogMessage
        {
            public string LogMessage { get; set; }
        }

        public static void LogMessage(string msg)
        {
            var logMsg = JsonConvert.SerializeObject(new CustomLogMessage {LogMessage = msg});
            Console.WriteLine(logMsg);
        }
    }
}
