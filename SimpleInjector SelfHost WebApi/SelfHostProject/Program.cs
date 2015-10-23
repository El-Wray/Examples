using System;
using Microsoft.Owin.Hosting;

namespace SelfHostProject
{
    internal class Program
    {
        static void Main()
        {
            const string baseAddress = "http://localhost:44301";

            //  WebApp class located in Microsoft.Owin.Hosting package.
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine($"Server started at {baseAddress}");
                Console.ReadLine();
            }
        }
    }
}