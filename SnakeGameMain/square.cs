using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameMain
{
    public class Square
    {

        static void Main(string[] args)
        {

            bool finished = false;
            Square canvas = new Square();

            while (!finished)
            {

                canvas.Draw();
                Console.Read();

            }


        }
        public int Height { get; set; }
        public int Width { get; set; }

        public Square()
        {

            Height = 50;
            Width = 50;

        }


        public void Draw()
        {

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("#");
            }

            for (int i = 0; i < Height; i++)
            {
                Console.SetCursorPosition(i, Height);
                Console.WriteLine("#");
            }
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("#");
            }
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(Width, i);
                Console.WriteLine("#");

            }


            List<int> buildSnakeXArrow = new List<int>();
            List<int> buildSnakeYArrow = new List<int>();
            List<string> LengthSnake = new List<string>();
            LengthSnake.Add("o");
            string arrayJoin = string.Join(" ", LengthSnake); //converterar list (LengthSnake) till string
            buildSnakeXArrow.Add(11);
            buildSnakeYArrow.Add(11);
            int LastNumberInX = buildSnakeXArrow[buildSnakeXArrow.Count - 1];
            int LastNumberInY = buildSnakeYArrow[buildSnakeYArrow.Count - 1];
            // !!!!FÖRSTA PROBLEM kan inte returnera LastNumberIn Y/X, eftersom värde måste returneras till listan buildSnake Y/X arro

            int DownArrow(List<int> buildSnakeXArrow, List<int> buildSnakeYArrow)
            {
                if (LastNumberInX > 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY + 2);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(arrayJoin);
                    LastNumberInY++;
                }
                else if (LastNumberInX < 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY + 2);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(arrayJoin);
                    LastNumberInY++;
                }
                return LastNumberInY;
            }

            int UpArrow(List<int> buildSnakeXArrow, List<int> buildSnakeYArrow)
            {
                if (LastNumberInX > 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(arrayJoin);
                    LastNumberInY--;
                }
                else if (LastNumberInX < 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(arrayJoin);
                    LastNumberInY--;
                }
                return LastNumberInY;
            }

            int LeftArrow(List<int> buildSnakeXArrow, List<int> buildSnakeYArrow)
            {
                if (LastNumberInY > 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(arrayJoin);
                    LastNumberInX--;
                }
                else if (LastNumberInY < 10)
                {
                    Console.SetCursorPosition(LastNumberInX, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(arrayJoin);
                    LastNumberInX--;
                }
                return LastNumberInX;
            }

            int RightArrow(List<int> buildSnakeXArrow, List<int> buildSnakeYArrow)
            {
                if (LastNumberInY > 10)
                {
                    Console.SetCursorPosition(LastNumberInX + 2, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(arrayJoin);
                    LastNumberInX++;
                }
                else if (LastNumberInY < 10)
                {
                    Console.SetCursorPosition(LastNumberInX + 2, LastNumberInY);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write(arrayJoin);
                    LastNumberInX++;
                }
                return LastNumberInX;
            }

            int numOfApples = 1;
            object ApplePlacing(int LastNumberInX, int LastNumberInY, List<string> LengthSnake, int numOfApples)
            {
                Random random = new Random();
                int PositionX = random.Next(2, 49);
                int PositionY = random.Next(2, 49);

                // !!!!!PROBLEM jag antar, att man kommer aldrig till den funktionen, eftersom värdena i LastNumberIn Y/X ändras alldrig på grund av första problemet 
                if (LastNumberInX == PositionX && LastNumberInY == PositionY)
                {
                    Console.SetCursorPosition(PositionX, PositionY);
                    Console.WriteLine(" ");
                    LengthSnake.Add("o");
                    numOfApples = 0;
                    return numOfApples;

                }

                else if (LastNumberInX != PositionX && LastNumberInY != PositionY)
                {
                    Console.SetCursorPosition(PositionX, PositionY);
                    Console.WriteLine("@");
                    Console.SetCursorPosition(30, 30);
                    Console.WriteLine(numOfApples);
                    Console.SetCursorPosition(31, 31);
                    Console.WriteLine(arrayJoin);
                    Console.SetCursorPosition(32, 32);
                    Console.WriteLine(LastNumberInY);
                }
                else
                    return numOfApples;

                return LengthSnake;
            }
            // positionen där spelet startas
            for (int i = 0; i < 10000000; i++)
            {
                Console.SetCursorPosition(10, 10);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                // Positionen till höger är y-axel och positionen till vänster är x
                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    UpArrow(buildSnakeXArrow, buildSnakeYArrow);
                    if (numOfApples > 1)
                    {
                        numOfApples++;
                    }
                    else
                    {
                        ApplePlacing(LastNumberInX, LastNumberInY, LengthSnake, numOfApples);
                        numOfApples++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    DownArrow(buildSnakeXArrow, buildSnakeYArrow);
                    if (numOfApples > 1)
                    {
                        numOfApples++;
                    }
                    else
                    {
                        ApplePlacing(LastNumberInX, LastNumberInY, LengthSnake, numOfApples);
                        numOfApples++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    LeftArrow(buildSnakeXArrow, buildSnakeYArrow);
                    if (numOfApples > 1)
                    {
                        numOfApples++;
                    }
                    else
                    {
                        ApplePlacing(LastNumberInX, LastNumberInY, LengthSnake, numOfApples);
                        numOfApples++;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.RightArrow)
                {
                    RightArrow(buildSnakeXArrow, buildSnakeYArrow);
                    if (numOfApples > 1)
                    {
                        numOfApples++;
                    }
                    else
                    {
                        ApplePlacing(LastNumberInX, LastNumberInY, LengthSnake, numOfApples);
                        numOfApples++;
                    }
                }
            }
        }
    }
}
