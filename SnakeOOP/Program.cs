using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Point snakeTail = new Point(15, 15, '0');
            Snake snake = new Snake(snakeTail, 5, Direction.RIGHT);
            snake.Draw();

            FoodGenerator foodGenerator2 = new FoodGenerator(80, 25, '/');
            Point food2 = foodGenerator2.GenerateFood();
            food2.Draw();

            FoodGenerator foodGenerator = new FoodGenerator(80, 25, '1');
            Point food = foodGenerator.GenerateFood();
            food.Draw();
            Console.ForegroundColor = ConsoleColor.Yellow;
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score++;
                    Console.Beep();
                }
                if (snake.Eat(food2))
                {
                    food = foodGenerator.GenerateFood();
                    food.Draw();
                    score--;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    snake.Move();
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKeys(key.Key);
                }
                Thread.Sleep(300);

            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();

            
        }
       

        public static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("========================", xOffset, yOffset++);
            WriteText("       Mäng Läbi :)       ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText($" Sinu skoor: {score} punkti", xOffset + 2, yOffset++);
            WriteText("", xOffset + 1, yOffset++);
            WriteText("=========================", xOffset, yOffset++);
        }


        public static void WriteText(string text, int xOffset, int YOffset)
        {
            Console.SetCursorPosition(xOffset, YOffset);
            Console.WriteLine(text);
        }
    }
}
