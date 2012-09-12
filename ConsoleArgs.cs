using System.Collections.Generic;
using System.Dynamic;
namespace ConsoleArgs 
{
    public class ConsoleArguments
    {
        public dynamic Arguments;

        public ConsoleArguments(string[] arguments)
        {
            Arguments = new ExpandoObject();
            var argumentDictionary = Arguments as IDictionary<string, object>;
            FillArguments(arguments, argumentDictionary, ':');
        }

        public ConsoleArguments(string[] arguments, char separator)
        {
            Arguments = new ExpandoObject();
            var argumentDictionary = Arguments as IDictionary<string, object>;
            FillArguments(arguments, argumentDictionary, separator);
        }

        private void FillArguments(string[] arguments, IDictionary<string, object> argumentDictionary, char separator)
        {
            var undefinedCounter = 1;
            foreach (var argument in arguments)
            {
                var name = string.Empty;
                var value = string.Empty;
                if (argument.Contains(separator.ToString()))
                {
                    var firstInstancePosition = argument.IndexOf(separator, 0);
                    name = argument.Substring(0, firstInstancePosition);
                    value = argument.Substring(firstInstancePosition + 1);
                }
                else
                {
                    name = "UndefinedArgument" + undefinedCounter;
                    value = argument;
                }
                argumentDictionary.Add(name, value);
            }
        }
    }
}