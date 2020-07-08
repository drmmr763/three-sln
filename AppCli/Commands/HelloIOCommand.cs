using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using AppShared.Entities;

namespace AppCli.Commands
{
    [Command("hello-io", Description = "A command which takes an input param and prints it back out")]
    public class HelloIOCommand : ICommand
    {
        [CommandOption("input", 'i', Description = "The test input value for reprinting", IsRequired = true)]
        public string TestInput { get; set; }
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            var appEntity = new AppEntity();
            
            console.Output.WriteLine($"You entered: {this.TestInput} {appEntity.testValue}");
            return default;
        }
    }
}