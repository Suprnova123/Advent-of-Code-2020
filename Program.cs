using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day11();
        }

        private static void Day11()
        {
            var seating = File.ReadAllLines("###\\Advent of Code\\Day11.txt");
            bool changed = true;
            int currentIteration = 1;
            StringBuilder sb = new StringBuilder(1000000);
            do
            {
                sb = new StringBuilder(1000000);
                int currentRow = 0;
                changed = false;
                foreach (string row in seating)
                {    
                    int currentSpace = 0;
                    foreach (char space in row)
                    {
                        if (space == '.')
                        {
                            sb.Append('.');
                            currentSpace++;
                            continue;
                        }
                        if (currentRow == 0)
                        {
                            if (currentSpace == 0)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace + 1] != '#' && seating[currentRow + 1][currentSpace] != '#' && seating[currentRow + 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace + 1]).Append(seating[currentRow + 1][currentSpace]).Append(seating[currentRow + 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else if (currentSpace >= row.Length - 1)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && seating[currentRow + 1][currentSpace - 1] != '#' && seating[currentRow + 1][currentSpace] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(seating[currentRow + 1][currentSpace - 1]).Append(seating[currentRow + 1][currentSpace]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && row[currentSpace + 1] != '#' && seating[currentRow + 1][currentSpace - 1] != '#' && seating[currentRow + 1][currentSpace] != '#' && seating[currentRow + 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(row[currentSpace + 1]).Append(seating[currentRow + 1][currentSpace - 1]).Append(seating[currentRow + 1][currentSpace]).Append(seating[currentRow + 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                        }
                        else if (currentRow >= seating.Length - 1)
                        {
                            if (currentSpace == 0)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace + 1] != '#' && seating[currentRow - 1][currentSpace] != '#' && seating[currentRow - 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace + 1]).Append(seating[currentRow - 1][currentSpace]).Append(seating[currentRow - 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else if (currentSpace >= row.Length - 1)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(seating[currentRow - 1][currentSpace - 1]).Append(seating[currentRow - 1][currentSpace]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && row[currentSpace + 1] != '#' && seating[currentRow - 1][currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace] != '#' && seating[currentRow - 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(row[currentSpace + 1]).Append(seating[currentRow - 1][currentSpace - 1]).Append(seating[currentRow - 1][currentSpace]).Append(seating[currentRow - 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (currentSpace == 0)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace + 1] != '#' && seating[currentRow - 1][currentSpace] != '#' && seating[currentRow - 1][currentSpace + 1] != '#' && seating[currentRow + 1][currentSpace] != '#' && seating[currentRow + 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace + 1]).Append(seating[currentRow - 1][currentSpace]).Append(seating[currentRow - 1][currentSpace + 1]).Append(seating[currentRow + 1][currentSpace]).Append(seating[currentRow + 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else if (currentSpace >= row.Length - 1)
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace] != '#' && seating[currentRow + 1][currentSpace - 1] != '#' && seating[currentRow + 1][currentSpace] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(seating[currentRow - 1][currentSpace - 1]).Append(seating[currentRow - 1][currentSpace]).Append(seating[currentRow + 1][currentSpace - 1]).Append(seating[currentRow + 1][currentSpace]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                            else
                            {
                                if (space == 'L')
                                {
                                    if (row[currentSpace - 1] != '#' && row[currentSpace + 1] != '#' && seating[currentRow - 1][currentSpace - 1] != '#' && seating[currentRow - 1][currentSpace] != '#' && seating[currentRow - 1][currentSpace + 1] != '#' && seating[currentRow + 1][currentSpace - 1] != '#' && seating[currentRow + 1][currentSpace] != '#' && seating[currentRow + 1][currentSpace + 1] != '#')
                                    {
                                        sb.Append('#');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('L');
                                    }
                                }
                                else if (space == '#')
                                {
                                    StringBuilder sb2 = new StringBuilder();
                                    int i = 0;
                                    sb2.Append(row[currentSpace - 1]).Append(row[currentSpace + 1]).Append(seating[currentRow - 1][currentSpace - 1]).Append(seating[currentRow - 1][currentSpace]).Append(seating[currentRow - 1][currentSpace + 1]).Append(seating[currentRow + 1][currentSpace - 1]).Append(seating[currentRow + 1][currentSpace]).Append(seating[currentRow + 1][currentSpace + 1]);
                                    foreach (char character in sb2.ToString())
                                    {
                                        if (character == '#')
                                        {
                                            i++;
                                        }
                                    }
                                    if (i >= 4)
                                    {
                                        sb.Append('L');
                                        changed = true;
                                    }
                                    else
                                    {
                                        sb.Append('#');
                                    }
                                }
                            }
                        }
                        currentSpace++;
                    }
                    if (currentRow < seating.Length - 1)
                        sb.Append("\n");
                    currentRow++;
                }
                foreach (string row in sb.ToString().Split(Environment.NewLine.ToCharArray()))
                    Console.WriteLine(row);
                Console.WriteLine();
                Console.WriteLine($"Iteration {currentIteration} complete!");
                Console.WriteLine();
                currentIteration++;
                seating = sb.ToString().Split(Environment.NewLine.ToCharArray());
            }
            while (changed);
            int count = 0;
            foreach(string line in seating)
            {
                foreach(char character in line)
                {
                    if (character == '#')
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine($"There are {count} occupied chairs.");
            Console.ReadLine();
            
        }

        private static void Day10()
        {
            var adapters = File.ReadAllLines("###\\Advent of Code\\Day10.txt");
            List<int> differences = new List<int>();
            List<int> paths = new List<int>();
            List<int> distinctWays = new List<int>();
#pragma warning disable CS0219
            int ones = 0;
            int threes = 0;
#pragma warning restore CS0219
            int baseJolt = 0;
            paths.Add(baseJolt);
            int i = 1;
        /*do
        {
            if (adapters.Contains((baseJolt + i).ToString()))
            {
                baseJolt = baseJolt + i;
                differences.Add(i);
                i = 1;
                Console.WriteLine(baseJolt);
            }
            else
            {
                i++;
            }
        }
        while (differences.Count != 106);
        foreach (int difference in differences)
        {
            if (difference == 1)
            {
                ones++;
            }
            else
            {
                threes++;
            }
        }
        threes++;
        Console.WriteLine($"There are {ones} 1 volt differences and {threes} 3 volt differences.");
        Console.ReadLine();*/
        restart:
            List<int> pathsTemp = new List<int>();
            foreach (int path in paths)
            {
                do
                {
                    if (adapters.Contains((path + i).ToString()))
                    {
                        pathsTemp.Add(path + i);
                    }
                    i++;
                }
                while (i != 4);
                i = 1;
            }
            foreach(int pathTemp in pathsTemp)
            {
                if (pathTemp == 168)
                {
                    distinctWays.Add(pathTemp);
                    pathsTemp.Remove(pathTemp);
                }
                if (pathTemp > 168)
                {
                    pathsTemp.Remove(pathTemp);
                }
            }
            paths = pathsTemp;
            Console.WriteLine(paths.Max(path => path));
            if (paths.Count != 0)
            {
                goto restart;
            }
            Console.WriteLine($"There are {distinctWays.Count} distinct ways to arrange the adapters.");
            Console.ReadLine();
        }

        private static void Day9()
        {
            var preamble = File.ReadAllLines("###\\Advent of Code\\Day9.txt");
            int startingLine = 0;
            int brokenNum = 0;
            do
            {
                List<long> values = new List<long>();
                List<long> sums = new List<long>();
                int i = startingLine;
                Console.WriteLine(startingLine);
                do
                {
                    values.Add(long.Parse(preamble[i]));
                    i++;
                }
                while (values.Count != 25);
                foreach (int value in values)
                {
                    foreach (int value2 in values)
                    {
                        if (value2 == value)
                            continue;
                        sums.Add(value + value2);
                    }
                }
                foreach (int sum in sums)
                {
                    if (sum != Int64.Parse(preamble[startingLine + values.Count]))
                    {
                        brokenNum = startingLine + 25;
                    }
                    else
                    {
                        brokenNum = 0;
                        break;
                    }
                }
                values.Clear();
                startingLine++;
            }
            while (brokenNum == 0);
            int currentLine = 0;
            int i2 = 0;
            long min = 0;
            long max = 0;
            foreach(string line in preamble)
            {
                Console.WriteLine($"Calculating from line {currentLine}");
                List<long> selections = new List<long>();
                i2 = 0;
                foreach (string line2 in preamble)
                {
                    if (currentLine >= i2)
                    {
                        i2++;
                        continue;
                    }
                    selections.Add(Int64.Parse(line2));
                    if (selections.Sum() == Int64.Parse(preamble[brokenNum]))
                    {
                        min = selections.Min(selections => selections);
                        max = selections.Max(selections => selections);
                        goto finish;
                    }
                    i2++;
                }
                currentLine++;
            }
        finish:
            Console.WriteLine($"The broken number is line {brokenNum}, with a value of {preamble[brokenNum]}.");
            Console.WriteLine($"The encryption weakness is {min + max}");
            Console.ReadLine();
        }

        private static void Day8()
        {
            var instructions = File.ReadAllLines("###\\Advent of Code\\Day8.txt");
            int replacedLine = 0;
            restart:
            List<int> visitedLines = new List<int>();
            int acc = 0;
            int currentLine = 0;
            int ten = 12;
            do
            {
                if (string.IsNullOrWhiteSpace(instructions[currentLine]))
                {
                    goto executionfinished;
                }
                if (visitedLines.Contains(currentLine))
                {
                    break;
                }
                else
                {
                    visitedLines.Add(currentLine);
                }
                string line;
                if (replacedLine == currentLine)
                {
                    if (instructions[currentLine].StartsWith("jmp"))
                    {
                        line = "nop";
                    }
                    else
                    {
                        line = instructions[currentLine].Replace("nop", "jmp");
                    }
                }
                else
                {
                    line = instructions[currentLine];
                }
                
                if (line.StartsWith("acc"))
                {
                    if (line.Contains('+'))
                    {
                        acc = acc + Int32.Parse(line.Split('+')[1]);
                    }
                    else if (line.Contains('-'))
                    {
                        acc = acc - Int32.Parse(line.Split('-')[1]);
                    }
                    currentLine++;
                }
                else if (line.StartsWith("jmp"))
                {
                    if (line.Contains('+'))
                    {
                        currentLine = currentLine + Int32.Parse(line.Split('+')[1]);
                    }
                    else if (line.Contains('-'))
                    {
                        currentLine = currentLine - Int32.Parse(line.Split('-')[1]);
                    }
                }
                else if (line.StartsWith("nop"))
                {
                    currentLine++;
                }
            }
            while (9 + ten == 21); //i am a very serious programmer
            do
            {
                replacedLine++;
            }
            while (!instructions[replacedLine].StartsWith("jmp") && (!instructions[replacedLine].StartsWith("nop")));
            goto restart;
            executionfinished:
            //Console.WriteLine($"The accumulator has a value of {acc} when an infinite loop happens.");
            Console.WriteLine($"The accumulator has a value of {acc} when execution happens.");
            Console.WriteLine($"Line {replacedLine} is the corrupt line.");
            Console.ReadLine();
        }

        private static void Day7()
        {
            //unfinished, only part 1
            var rules = File.ReadAllLines("###\\Advent of Code\\Day7.txt");
            List<string> holders = new List<string>();
            holders.Add("shiny gold");
            redo:
            int initialCount = holders.Count;
            foreach (string rule in rules)
            {
                if (holders.Any(rule.Substring(rule.IndexOf(' ')).Contains) && !holders.Contains($"{rule.Split(' ')[0]} {rule.Split(' ')[1]}"))
                {
                    holders.Add($"{rule.Split(' ')[0]} {rule.Split(' ')[1]}");
                }
            }
            if (holders.Count != initialCount)
            {
                goto redo;
            }
            Console.WriteLine($"{initialCount - 1} bags can hold shiny gold bags.");
            Console.ReadLine();
        }

        private static void Day6()
        {
            List<char> finalChars = new List<char>();
            List<char> characters = new List<char>();
            var answers = File.ReadAllLines("###\\Advent of Code\\Day6.txt");
            /*foreach (string line in answers)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    foreach (char character in characters)
                    {
                        finalChars.Add(character);
                    }
                    characters.Clear();
                }
                else
                {
                    foreach (char question in line)
                    {
                        if (!characters.Contains(question))
                        {
                            characters.Add(question);
                        }
                    }
                }
            }
            foreach (char character in characters)
            {
                finalChars.Add(character);
            }
            Console.WriteLine($"The amount of \"Yes\" answers in the data is {finalChars.Count}");
            Console.ReadLine();*/
            List<string> lines = new List<string>();
            int i = 0;
            foreach (string line in answers)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    foreach (char character in lines[0])
                    {
                        foreach (string letters in lines)
                        {
                            if (letters.Contains(character))
                            {
                                i++;
                            }
                        }
                        if (i == lines.Count)
                        {
                            finalChars.Add(character);
                        }
                        i = 0;
                    }
                    lines.Clear();
                }
                else
                {
                    lines.Add(line);
                }
            }
            foreach (char character in lines[0])
            {
                foreach (string letters in lines)
                {
                    if (letters.Contains(character))
                    {
                        i++;
                    }
                }
                if (i == lines.Count)
                {
                    finalChars.Add(character);
                }
                i = 0;
            }
            Console.WriteLine($"The amount of times everyone answered \"Yes\" in the data is {finalChars.Count}");
            Console.ReadLine();
        }

        private static void Day5()
        {
            List<int> seatIDs = new List<int>();
            var passes = File.ReadAllLines("###\\Advent of Code\\Day5.txt");
            foreach (string line in passes)
            {
                string pass = line.Replace('F', '0').Replace('B', '1').Replace("L", "").Replace("R", "");
                int row = Convert.ToInt32(pass, 2);
                pass = line.Replace("F", "").Replace("B", "").Replace("L", "0").Replace("R", "1");
                int column = Convert.ToInt32(pass, 2);
                seatIDs.Add(row * 8 + column);
            }
            Console.WriteLine($"The largest seat ID is {seatIDs.Max()}");
            List<int> seatIDsSorted = seatIDs.OrderBy(number => number).ToList();
            foreach (int id in seatIDsSorted)
                Console.WriteLine(id);
        }

        private static void Day4()
        {
            var passports = File.ReadAllLines("###\\Advent of Code\\Day4.txt");
            List<string> info = new List<string>();
            int valids = 0;
            foreach (string line in passports)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    bool byr = false;
                    bool iyr = false;
                    bool eyr = false;
                    bool hgt = false;
                    bool hcl = false;
                    bool ecl = false;
                    bool pid = false;
                    foreach (string infoLine in info)
                    {
                        if (infoLine.Contains("byr"))
                        {
                            try
                            {
                                if (Int32.Parse(infoLine.Substring(infoLine.IndexOf("byr:"), 4)) >= 1920 && Int32.Parse(infoLine.Substring(infoLine.IndexOf("byr:"), 4)) <= 2002)
                                {
                                    byr = true;
                                }
                                else
                                {
                                    byr = false;
                                }
                            }
                            catch
                            {
                                byr = false;
                            }
                            
                        }
                        if (infoLine.Contains("iyr"))
                        {
                            try
                            {
                                if (Int32.Parse(infoLine.Substring(infoLine.IndexOf("iyr:"), 4)) >= 2010 && Int32.Parse(infoLine.Substring(infoLine.IndexOf("iyr:"), 4)) <= 2020)
                                {
                                    iyr = true;
                                }
                                else
                                {
                                    iyr = false;
                                }
                            }
                            catch
                            {
                                iyr = false;
                            }
                        }
                        if (infoLine.Contains("eyr"))
                        {
                            try
                            {
                                if (Int32.Parse(infoLine.Substring(infoLine.IndexOf("eyr:"), 4)) >= 2020 || Int32.Parse(infoLine.Substring(infoLine.IndexOf("eyr:"), 4)) <= 2030)
                                {
                                    eyr = true;
                                }
                                else
                                {
                                    eyr = false;
                                }
                            }
                            catch
                            {
                                eyr = false;
                            }
                        }
                        if (infoLine.Contains("hgt"))
                        {
                            if (infoLine.Substring(infoLine.IndexOf("hgt:")).Contains("cm"))
                            {
                                try
                                {
                                    if (Int32.Parse(infoLine.Substring(infoLine.IndexOf("hgt:"), infoLine.IndexOf("cm"))) >= 150 && Int32.Parse(infoLine.Substring(infoLine.IndexOf("hgt:"), infoLine.IndexOf("cm"))) <= 193)
                                    {
                                        hgt = true;
                                    }
                                    else
                                    {
                                        hgt = false;
                                    }
                                }
                                catch
                                {
                                    hgt = false;
                                }                               
                            }
                            else if (infoLine.Substring(infoLine.IndexOf("hgt:")).Contains("in"))
                            {
                                try
                                {
                                    if (Int32.Parse(infoLine.Substring(infoLine.IndexOf("hgt:"), infoLine.IndexOf("in"))) >= 59 && Int32.Parse(infoLine.Substring(infoLine.IndexOf("hgt:"), infoLine.IndexOf("in"))) <= 76)
                                    {
                                        hgt = true;
                                    }
                                    else
                                    {
                                        hgt = false;
                                    }
                                }
                                catch
                                {
                                    hgt = false;
                                }
                            }
                            else
                            {
                                hgt = false;
                            }
                        }
                        if (infoLine.Contains("hcl"))
                        {
                            if (infoLine.Substring(infoLine.IndexOf("hcl")).Split(':')[1][0] == '#')
                            {
                                try
                                {
                                    if (Regex.IsMatch(infoLine.Split('#')[1].Remove(6), @"^[g-z]+$"))
                                    {
                                        hcl = false;
                                    }
                                    else
                                    {
                                        hcl = true;
                                    }
                                }
                                catch
                                {
                                    if (Regex.IsMatch(infoLine.Split('#')[1], @"^[g-z]+$"))
                                    {
                                        hcl = false;
                                    }
                                    else
                                    {
                                        hcl = true;
                                    }
                                }
                            }
                            else
                            {
                                hcl = false;
                            }
                        }
                        if (infoLine.Contains("ecl"))
                        {
                            string color = infoLine.Substring(infoLine.IndexOf("ecl")).Split(':')[1];
                            if (color.Contains("amb") || color.Contains("blu") || color.Contains("brn") || color.Contains("gry") || color.Contains("grn") || color.Contains("hzl") || color.Contains("oth"))
                            {
                                ecl = true;
                            }
                            else
                            {
                                ecl = false;
                            }
                        }
                        if (infoLine.Contains("pid"))
                        {
                            string id = infoLine.Substring(infoLine.IndexOf("pid")).Split(':')[1];
                            if (Regex.IsMatch(id, @"^[a-zA-Z]+$"))
                            {
                                pid = true;
                            }
                            else
                            {
                                pid = false;
                            }
                        }
                    }
                    if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                    {
                        valids++;
                    }
                    info.Clear();
                }
                else
                {
                    info.Add(line);
                }
            }
            Console.WriteLine($"There are {valids} valid passports.");
        }

        private static void Day3()
        {
            int trees = 0;
            var map = File.ReadAllLines("###//Advent of Code//Day3.txt");
            int currentX = 0;
            int currentY = 0;
            do
            {
                Console.WriteLine(map[currentY][currentX]);
                if (map[currentY][currentX] == '#')
                {
                    trees++;
                    Console.WriteLine("Hit tree.");
                }
                else
                {
                    Console.WriteLine("Didn't hit tree.");
                }
                if (map[currentY].Length <= currentX + 1)
                {
                    currentX = currentX + 1 - map[currentY].Length;
                    currentY = currentY + 2;
                }
                else
                {
                    currentX = currentX + 1;
                    currentY = currentY + 2;
                }
            }
            while (currentY < 323);
            Console.WriteLine($"I hit {trees} trees.");
            Console.ReadLine();

            /*List<int> allTrees = new List<int>();
            int right = 1;
            int down = 1;
            restart:
            int trees = 0;
            var map = File.ReadAllLines("###//Advent of Code//Day3.txt");
            int currentX = 0;
            int currentY = 0;
            do
            {
                Console.WriteLine(map[currentY][currentX]);
                if (map[currentY][currentX] == '#')
                {
                    trees++;
                    Console.WriteLine("Hit tree.");
                }
                else
                {
                    Console.WriteLine("Didn't hit tree.");
                }
                if (map[currentY].Length <= currentX + right)
                {
                    currentX = currentX + right - map[currentY].Length;
                    currentY = currentY + down;
                }
                else
                {
                    currentX = currentX + right;
                    currentY = currentY + down;
                }
            }
            while (currentY < 323);
            allTrees.Add(trees);
            if (right == 7)
            {
                right = 1;
                down = 2;
                goto restart;
            }
            else if (down != 2)
            {
                right = right + 2;
                down++;
                goto restart;
            }
            Console.WriteLine($"The product of the amount of trees encountered on each slope is {allTrees[0] * allTrees[1] * allTrees[2] * allTrees[3] * allTrees[4]}");
            Console.WriteLine();*/
        }

        private static void Day2()
        {
            var passwords = File.ReadAllLines("###\\Advent of Code\\day2.txt");
            List<string> valids = new List<string>();
            foreach (string password in passwords)
            {
                /*int min = Int32.Parse(password.Split('-')[0]);
                int max = Int32.Parse(password.Split(' ')[0].Replace($"{min}-", string.Empty));
                char character = char.Parse(password.Split(':')[0].Replace($"{min}-{max} ", string.Empty));
                int count = password.Count(x => x == character) - 1;
                if (count >= min && count <= max)
                {
                    valids.Add(password);
                    Console.WriteLine($"{password} is a valid password.");
                }
                else
                {
                    Console.WriteLine($"{password} is not a valid password.");
                }*/

            int pos1 = Int32.Parse(password.Split('-')[0]) - 1;
                int pos2 = Int32.Parse(password.Split(' ')[0].Replace($"{pos1 + 1}-", string.Empty)) - 1;
                char character = char.Parse(password.Split(':')[0].Replace($"{pos1 + 1}-{pos2 + 1} ", string.Empty));
                string pass = password.Split(':')[1].Trim();
                try
                {
                    if (pass[pos1] == character ^ pass[pos2] == character)
                    {
                        valids.Add(pass);
                        Console.WriteLine($"{pass} is a valid password.");
                    }
                    else
                    {
                        Console.WriteLine($"{pass} is not a valid password.");
                    }
                }
                catch
                {
                    try
                    {
                        if (pass[pos1] == character)
                        {
                            valids.Add(pass);
                            Console.WriteLine($"{pass} is a valid password.");
                        }
                        else
                        {
                            Console.WriteLine($"{pass} is not a valid password.");
                        }
                    }
                    catch
                    {
                        Console.WriteLine($"{pass} is not a valid password.");
                    }
                }
            }
            Console.WriteLine($"There are {valids.Count} valid passwords.");
            Console.ReadLine();
        }

        private static void Day1()
        {
            int[] expenses = { 16614 };
            foreach (int expense in expenses)
            {
                foreach (int expense2 in expenses)
                {
                    foreach (int expense3 in expenses)
                    {
                        if (expense + expense2 + expense3 == 2020)
                        {
                            Console.WriteLine($"The two expenses that sum to 2020 is {expense}, {expense2}, and {expense3}.");
                            Console.WriteLine($"{expense} multiplied by {expense2} equals {expense * expense2 * expense3}");
                            Console.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
