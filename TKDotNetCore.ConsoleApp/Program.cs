﻿// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using TKDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");


AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
/*adoDotNetExample.Read();*/
/*adoDotNetExample.Create("Title2", "Author2", "Content2");*/
adoDotNetExample.Update(6, "Title6", "Author6", "Content6");

Console.ReadLine();
