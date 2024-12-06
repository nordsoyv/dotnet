using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AOC2024;
using Xunit.Abstractions;

namespace Tests;

public class Fixture(ITestOutputHelper testOutputHelper)
{
    public Day Prepare<T>() where T : Day, new()
    {
        var day =  new T
        {
            WriteLine = testOutputHelper.WriteLine
        };
        return day;
    }

    public string GetTestFile(string name)
    {
        var fullName = $"Tests.Inputs.{name}";
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullName);
        Assert.NotNull(stream);
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        return streamReader.ReadToEnd();
    }
    public List<string> GetTestFileLines(string name)
    {
        var fullName = $"Tests.Inputs.{name}";
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullName);
        Assert.NotNull(stream);
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        var content = streamReader.ReadToEnd();
        return content.Split("\n").ToList();
    }
}
