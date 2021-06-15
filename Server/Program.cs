using System;
using MagicOnion.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace MagicOnionServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await MagicOnionHost.CreateDefaultBuilder()
                .UseMagicOnion()
                .RunConsoleAsync();
        }
    }
}
