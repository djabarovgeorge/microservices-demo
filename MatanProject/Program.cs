using MatanProject.Services;
using System.Threading.Tasks;

namespace MatanProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var userMain = new UserMain();

            await userMain.Execute();

        }
    }
}