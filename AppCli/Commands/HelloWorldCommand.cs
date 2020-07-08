using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace AppCli.Commands
{
    [Command("hello-world", Description = "Prints hello world out")]
    public class HelloWorldCommand : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Hello world!");

            // Return empty task because our command executes synchronously
            return default;
        }
    }
}