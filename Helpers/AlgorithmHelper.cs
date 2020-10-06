using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlasticIdentifier.Helpers
{
    class AlgorithmHelper
    {
        private static readonly string APP_DATA = @"~/Python/";

        /*
         * This function will ensure that the Python file
         * is always accessible to the solution, no matter
         * on which system it is currently running.
         * 
         * IN: n/a
         * OUT: the path to the Python folder
         */

        public static string getStorageFolder()
        {
            try
            {
                bool app_dataExists = Directory.Exists(APP_DATA);
                while (!app_dataExists)
                {
                    Directory.SetCurrentDirectory(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString());
                    app_dataExists = Directory.Exists(APP_DATA);
                }
                return APP_DATA;
            }
            catch (Exception ex)
            {
                Console.WriteLine((ex.ToString()));
                return null;
            }
        }


        public static string PatchParameter(string parameter, int serviceid)
        {
            var engine = Python.CreateEngine(); // Extract Python language engine from their grasp

            var scope = engine.CreateScope(); // Introduce Python namespace (scope)

            var d = new Dictionary<string, object>
            {
                { "serviceid", serviceid},
                { "parameter", parameter}
            }; // Add some sample parameters. Notice that there is no need in specifically setting the object type, interpreter will do that part for us in the script properly with high probability

            scope.SetVariable("params", d); // This will be the name of the dictionary in python script, initialized with previously created .NET Dictionary

            ScriptSource source = engine.CreateScriptSourceFromFile("C:\\Users\\Duane de Villiers\\Documents\\Visual Studio 2015\\Projects\\PlasticIdentifier\\Python\\Vectorize.py"); // Load the script
            object result = source.Execute(scope);

            //parameter = scope.GetVariable<string>("func"); // To get the finally set variable 'parameter' from the python script
            
            return parameter;
        }

        /*
         * A function to initialise all of the algorithms scripts
         */

        /*
         * Run single instance of genetic algorithm, i.e. for one image
         */

        /*
         * Run multiple instances of genetic algorithm, i.e. for multiple image
         */

        /*
         * Run single instance of simulated annealing algorithm, i.e. for one image
         */

        /*
         * Run multiple instances of simulated annealing, i.e. for multiple image
         */
    }
}
