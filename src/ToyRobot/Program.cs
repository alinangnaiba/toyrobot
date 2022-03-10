// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Reflection;
using ToyRobot.Core;

var builder = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true);
var config = builder.Build();
var filePath = config["FilePath"];
var reader = new FileCommandReader(filePath);
var simulator = new Simulator(reader);
simulator.Run();
