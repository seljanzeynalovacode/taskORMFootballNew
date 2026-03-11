using FootbolLigasORM.UI;
using System.Threading.Tasks;

namespace FootbolLigasORM.UI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Run the console menu
            var menu = new MenuOperation();
            menu.Run();

            await Task.CompletedTask;
        }
    }
}
