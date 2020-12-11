﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using System.Linq;

namespace Advent_of_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1();
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