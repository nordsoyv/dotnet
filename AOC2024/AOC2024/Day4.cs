using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AOC2024;

public class Day4(Action<string> writeLine) : Day(writeLine)
{
    public Day4() : this(s => { })
    {
    }

    public override int SolvePart1(List<string> input)
    {
        var map = new CharMap();

        var sum = 0;
        input.ForEach(line =>
        {
            var chars = line.ToCharArray();
            map.AddRow(chars);
        });
        List<MapTraverser> traversers =
        [
            new MapTraverser(1, 0, map),
            new MapTraverser(-1, 0, map),
            new MapTraverser(0, 1, map),
            new MapTraverser(0, -1, map),
            new MapTraverser(1, 1, map),
            new MapTraverser(1, -1, map),
            new MapTraverser(-1, 1, map),
            new MapTraverser(-1, -1, map),
        ];
        for (int x = 0; x < map.NumColumns(); x++)
        {
            for (int y = 0; y < map.NumRows(); y++)
            {
                traversers.ForEach(t =>
                {
                    if (t.LookForString("XMAS", x, y))
                    {
                        sum++;
                    }
                });
            }
        }

        return sum;
    }

    public override int SolvePart2(List<string> input)
    {
        var map = new CharMap();

        var sum = 0;
        input.ForEach(line =>
        {
            var chars = line.ToCharArray();
            map.AddRow(chars);
        });
        var checker = new XChecker(map);
        for (int x = 0; x < map.NumColumns(); x++)
        {
            for (int y = 0; y < map.NumRows(); y++)
            {
                if (checker.CheckForX(x, y))
                {
                    sum++;
                }
            }
        }

        return sum;
    }
}

internal class CharMap
{
    private List<char[]> _rows = [];

    public void AddRow(char[] row)
    {
        _rows.Add(row);
    }

    public int NumRows()
    {
        return _rows.Count;
    }

    public int NumColumns()
    {
        return _rows[0].Length;
    }

    public char GetChar(int x, int y)
    {
        if (y < 0) return ' ';
        if (y >= _rows.Count) return ' ';
        var row = _rows[y];
        if (x < 0) return ' ';
        if (x >= row.Length) return ' ';
        return row[x];
    }
}

internal class MapTraverser
{
    private int _xPos;
    private int _yPos;
    private int _xDiff;
    private int _yDiff;
    private readonly CharMap _map;

    public MapTraverser(int xDiff, int yDiff, CharMap map)
    {
        _xDiff = xDiff;
        _yDiff = yDiff;
        _map = map;
    }

    public bool LookForString(string target, int x, int y)
    {
        _xPos = x;
        _yPos = y;
        foreach (var c in target.ToCharArray())
        {
            var p = _map.GetChar(_xPos, _yPos);
            if (p == c)
            {
                _xPos += _xDiff;
                _yPos += _yDiff;
                continue;
            }

            return false;
        }

        return true;
    }
}

internal class XChecker
{
    private readonly int _xPos;
    private readonly int _yPos;
    private readonly CharMap _map;

    public XChecker(CharMap map)
    {
        _map = map;
    }

    public bool CheckForX(int xPos, int yPos)
    {
        if (_map.GetChar(xPos, yPos) != 'A')
        {
            return false;
        }

        var diagonal1 = false;
        var diagonal2 = false;
        if (_map.GetChar(xPos - 1, yPos - 1) == 'M' && _map.GetChar(xPos + 1, yPos + 1) == 'S')
        {
            diagonal1 = true;
        }
        else if (_map.GetChar(xPos - 1, yPos - 1) == 'S' && _map.GetChar(xPos + 1, yPos + 1) == 'M')
        {
            diagonal1 = true;
        }
        if (_map.GetChar(xPos - 1, yPos + 1) == 'M' && _map.GetChar(xPos + 1, yPos - 1) == 'S')
        {
            diagonal2 = true;
        }
        else if (_map.GetChar(xPos - 1, yPos + 1) == 'S' && _map.GetChar(xPos + 1, yPos - 1) == 'M')
        {
            diagonal2 = true;
        }

        return diagonal2 && diagonal1;

    }
}