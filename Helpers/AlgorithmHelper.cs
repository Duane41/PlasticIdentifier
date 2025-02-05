﻿using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        public static void PatchParameter(string parameter, int serviceid)
        {
            var engine = Python.CreateEngine();

            var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\VectorizePixel.py";

            var paths = engine.GetSearchPaths();

            paths.Add(@"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Lib\site-packages\");

            engine.SetSearchPaths(paths);

            var source = engine.CreateScriptSourceFromFile(script);

            var argv = new List<string>();

            argv.Add("");

            argv.Add("Success!!");

            engine.GetSysModule().SetVariable("argv", argv);

            var s_IO = engine.Runtime.IO;

            var errors = new MemoryStream();

            s_IO.SetErrorOutput(errors, Encoding.Default);

            var outputs = new MemoryStream();

            s_IO.SetOutput(outputs, Encoding.Default);

            var scope = engine.CreateScope();
            source.Execute(scope);

            string str(byte[] x) => Encoding.Default.GetString(x);

            PrintEAndR(str(errors.ToArray()), str(outputs.ToArray()));
        }

        public static void PatchParameterProcess(string parameter, int serviceid)
        {
            var psi = new ProcessStartInfo();

            psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

            var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\VectorizePixel.py";

            var arg_1 = "Success!";

            psi.Arguments = $"\"{script}\" \"{arg_1}";

            psi.UseShellExecute = false;

            psi.CreateNoWindow = true;

            psi.RedirectStandardOutput = true;

            psi.RedirectStandardError = true;

            string errors = "";

            string results = "";

            using (var process = Process.Start(psi))
            {

                errors = process.StandardError.ReadToEnd();

                results = process.StandardOutput.ReadToEnd();

            }

            PrintEAndR(errors, results);
        }

        public static void TrainDataSetAvgVec(string file_location, string file_name)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\VectorizePixel.py";

                psi.Arguments = $"\"{script}\" \"{file_location}\" \"{file_name}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void TrainDataSetAvgVecHist(string file_location, string file_name)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\VectorizeHist.py";

                psi.Arguments = $"\"{script}\" \"{file_location}\" \"{file_name}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static bool IDPixelVecEuclid(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyPixelEuclid.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                } else
                {
                    return false;
                }

                
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
            
        }

        public static bool IDPixelManhattan(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyPixelManhattan.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }

        public static bool IDPixelCosine(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyPixelCosine.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }
        public static bool IDHistVecEuclid(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyHistEuclid.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }
        public static bool IDHistManhattan(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyHistManhattan.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }

        public static bool IDHistCosine(string dataset_location, string dataset_name, string selected_image)
        {
            try
            {
                var psi = new ProcessStartInfo();

                psi.FileName = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\env\Scripts\python.exe";

                var script = @"C:\Users\Duane de Villiers\Documents\Visual Studio 2015\Projects\PlasticIdentifier\PlastiIdentifier2.0\IdentifyHistCosine.py";

                psi.Arguments = $"\"{script}\" \"{dataset_location}\" \"{dataset_name}\" \"{selected_image}\"";

                psi.UseShellExecute = false;

                psi.CreateNoWindow = true;

                psi.RedirectStandardOutput = true;

                psi.RedirectStandardError = true;

                string errors = "";

                string results = "";

                using (var process = Process.Start(psi))
                {

                    errors = process.StandardError.ReadToEnd();

                    results = process.StandardOutput.ReadToEnd();

                }

                PrintEAndR(errors, results);

                if (results.Contains("True"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }

        }

        private static void PrintEAndR(string errors, string results)
        {
            Console.WriteLine("Errors:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);
        }
        
    }
}
