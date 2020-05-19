using System;
using Fivet.ZeroIce.model;
using Ice;

namespace Fivet.ZeroIce
{
    /**
    * Implementation of Interface TheSystem
    */
    class TheSystemImpl : TheSystemDisp_ {
         public override long getDelay(long clientTime, Ice.Current current)
        {
            return DateTime.Now.Ticks - clientTime;
        }
    }
    class Program
    {
        private static readonly int PORT = 8080;
        public static void Main(string[] args)
        {  
            Console.WriteLine("Starting the server ...");           
            
            /**
            * Server waiting connections 
            */
           
            using(var communicator = BuildCommunicator())
            {   
                var theAdapter = communicator.createObjectAdapterWithEndpoints("TheAdapter","tcp -z -t 15000 -p "+ PORT);
                
                TheSystem theSystem = new TheSystemImpl();
                theAdapter.add(theSystem, Util.stringToIdentity("TheSystem"));
                theAdapter.activate();
                communicator.waitForShutdown();
            }
            
        } 

        /// <summary>
        /// The Communicator
        /// </summary>
        private static Communicator BuildCommunicator() {

            // Console.WriteLine("[*] Building The Communicator ..");

            // ZeroC properties
            Properties properties = Util.createProperties();
            // https://doc.zeroc.com/ice/latest/property-reference/ice-trace
            properties.setProperty("Ice.Trace.Admin.Properties", "1");
            properties.setProperty("Ice.Trace.Locator", "2");
            properties.setProperty("Ice.Trace.Network", "3");
            properties.setProperty("Ice.Trace.Protocol", "1");
            properties.setProperty("Ice.Trace.Slicing", "1");
            properties.setProperty("Ice.Trace.ThreadPool", "1");
            properties.setProperty("Ice.Compression.Level", "9");

            // The ZeroC framework!
            InitializationData initializationData = new InitializationData();
            initializationData.properties = properties;

            var communicator = Ice.Util.initialize(initializationData);

            return communicator;

        }
    }
}

    