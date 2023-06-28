using Newtonsoft.Json;
using System.Diagnostics;
namespace CalculatorLibrary
{
    public class Calculator
    {
        //Write log entires to json file
        JsonWriter writer;
        public Calculator()
        {
            //writing log file
            //StreamWriter logFile = File.CreateText("calculator_traces.log");
            //Trace.Listeners.Add(new TextWriterTraceListener(logFile));
            //Trace.AutoFlush = true;
            //Trace.WriteLine("Calculator log...");
            //Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));

            StreamWriter logFile = File.CreateText("calculator.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();

        }
        public void calculation(double ip1, double ip2, string iop)
        {
            double output = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Value1");
            writer.WriteValue(ip1);
            writer.WritePropertyName("Value2");
            writer.WriteValue(ip2);
            writer.WritePropertyName("Operation");
            writer.WriteValue(iop);
            //performing calculation
            switch (iop)
            {
                case "a":
                    Console.WriteLine($"Your result : {ip1} + {ip2} = " + (ip1 + ip2));
                    writer.WritePropertyName("Result");
                    writer.WriteValue($"Your result : {ip1} + {ip2} = " + (ip1 + ip2));
                    break;
                case "s":
                    Console.WriteLine($"Your result : {ip1} - {ip2} = " + (ip1 - ip2));
                    writer.WritePropertyName("Result");
                    writer.WriteValue($"Your result : {ip1} - {ip2} = " + (ip1 - ip2));
                    break;
                case "m":
                    Console.WriteLine($"Your result : {ip1} * {ip2} = " + (ip1 * ip2));
                    writer.WritePropertyName("Result");
                    writer.WriteValue($"Your result : {ip1} * {ip2} = " + (ip1 * ip2));
                    break;
                case "d":
                    if (ip2 != 0)
                    {
                        Console.WriteLine($"Your result : {ip1} / {ip2} = " + (ip1 / ip2));
                        writer.WritePropertyName("Result");
                        writer.WriteValue($"Your result : {ip1} / {ip2} = " + (ip1 / ip2));
                    }
                    break;
                default:
                    Console.WriteLine($"{iop} option not available");
                    writer.WritePropertyName("Result");
                    writer.WriteValue($"{iop} option not available");
                    break;
            }
            writer.WriteEndObject();
        }
        //finidh json syntax after the end of the opertion
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}