using System;

namespace AntiLag
{
    internal class Intro
    {
        public static void PrintIntro()
        {
            ConsoleColor originalBackColour;

            originalBackColour = Console.BackgroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" AntiLag Minitaka Initiated - GeckGlobal Updates.");
            Console.BackgroundColor = originalBackColour;
        }
    }
}