using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace Explorable_Areas
{
    class Maze
    {
        private string[,] grid;
        private int rows;
        private int columns;

        public Maze(string [,] Grid)
        {
            grid = Grid;
            rows = grid.GetLength(0);
            columns = grid.GetLength(1);
        }

        // This method creates explorable areas by drawing 2 dimensional arrays.
        public void Create()
        {
            for (int y = 0; y < rows; y++)
            {
                for(int x = 0; x < columns; x++)
                {
                    string element = grid[y, x];
                    SetCursorPosition(x, y);
                    switch (element)
                    {
                        case "[-]":
                            ForegroundColor = ConsoleColor.Green;
                            
                            break;
                        case "[":
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        case "]":
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        case "%":
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        case "-" :
                            ForegroundColor = ConsoleColor.DarkMagenta;
                            break;
                       // case "*":
                         //   ForegroundColor = ConsoleColor.Yellow;
                           // break;
                        case "o":
                            ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "O":
                            ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "0":
                            ForegroundColor = ConsoleColor.Blue;
                            break;
                        case "$":
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "~":
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "{":
                            ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "=":
                            ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            break;
                    }
                  //  if (element == "[-]")
                   // {
                    //    ForegroundColor = ConsoleColor.Green;
                   // }
                    WriteLine(element);
                    ResetColor();
                }
            }
        }
         // This method also creates explorable areas through the use of arrays.
         // The main difference between this method and the one above is that this one
         // reads in external files that serve as its arrays.
        public static string [,] areacreator (string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            string initialline = lines[0];
            int rows = lines.Length;
            int columns = initialline.Length;
            string[,] themaze = new string[rows, columns];
            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < columns; x++)
                {
                    char thecharacter = line[x];
                    themaze[y, x] = thecharacter.ToString();

                }
            }




            return themaze;
        }


        // This method allows the player to walk within explorable areas while also prohibiting the player from walking within other areas.
        public bool ispositionwalkable(int x, int y)
        {
            if (x<0 || y<0 || x>= columns|| y>= rows)
            {
                return false;
            }
            return grid[y, x] == " " || grid[y, x] == "[-]"||grid[y,x]=="["||grid[y,x] == "]"||grid[y,x] == "="||grid[y,x] == "o"||grid[y,x] == "~"||grid[y,x] == "$"||grid[y,x]=="%"||grid[y,x]=="O"||grid[y,x] == "0"||grid[y,x] == "{";
        }

        // This method retrieves the player's current position.
        public string gatherposition(int x, int y)
        {
            return grid[y, x];
        }
    }
}
