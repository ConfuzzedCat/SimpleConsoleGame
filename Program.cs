using System;
using System.Collections.Generic;
using System.Threading;

namespace SimpleConsoleGame
{
    class Program
    {

        private static void Grid(int x, int y, int playerx, int playery)
        {
            for (int iGridLength = 0; iGridLength < y; iGridLength++)
            {
                Console.WriteLine("\n");
                for (int iGridWidth = 0; iGridWidth < x; iGridWidth++)
                {
                    if (iGridWidth == playerx && iGridLength == playery)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" 0");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" +");
                    }
                }
            }
            Console.WriteLine($"\nx:{playerx+1} y:{y-playery}");
        }
        
        static void Main(string[] args)
        {
            //Varibles
            int gameWidth;
            int gameLength;
            int input;
            bool isInt;
            int playerPosX; 
            int playerPosY;
            Random randomPlayerStartPos = new Random();


            //Welcomes and ask for width, and checks for int as answer.
            Console.Title = "A small and simple game!";
            Console.WriteLine("Hello and welcome!\nPress any key to start the game!");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("We need to make a grid. \nWhat will the width be?");
            isInt = int.TryParse(Console.ReadLine(), out input);

            while (isInt == false)
            {
                Console.Clear();
                Console.WriteLine("We need to make a grid. \nWhat will the width be? \nHint: type a number");
                isInt = int.TryParse(Console.ReadLine(), out input);
            }

            gameWidth = Convert.ToInt32(input);


            //asks for length
            Console.Clear();
            Console.WriteLine("Alright, now we need a length of the grid. \nWhat will the length be?");
            isInt = int.TryParse(Console.ReadLine(), out input);

            while (isInt == false)
            {
                Console.Clear();
                Console.WriteLine("We need to make a grid. \nWhat will the length be? \nHint: type a number");
                isInt = int.TryParse(Console.ReadLine(), out input);
            }

            gameLength = Convert.ToInt32(input);
            playerPosX = randomPlayerStartPos.Next(0, gameWidth);
            playerPosY = randomPlayerStartPos.Next(0, gameLength);
            Console.WriteLine($"So the grid is {gameWidth} wide and {gameLength} long, and has {gameWidth * gameLength} spaces. \nWill draw grid in 5 seconds.");
            Thread.Sleep(5000);

            for (int steps = 0; steps < 10; steps++)
            {
                Console.Clear();
                Console.WriteLine($"Move with WASD \nYou have {10 - steps} step(s) left!");
                Grid(gameWidth, gameLength,playerPosX, playerPosY);
                char keyPressed = Console.ReadKey().KeyChar;
                switch (keyPressed)
                {
                    case 'w':
                        playerPosY--;
                        break;
                    case 'a':
                        playerPosX--;
                        break;
                    case 's':
                        playerPosY++;
                        break;
                    case 'd':
                        playerPosX++;
                        break;
                    default:
                        Console.WriteLine("Invaild key!");
                        steps++;
                        Console.ReadLine();
                        break;

                }
            }
            Console.Clear();
            Grid(gameWidth, gameLength, playerPosX, playerPosY);
        }
    }
}
