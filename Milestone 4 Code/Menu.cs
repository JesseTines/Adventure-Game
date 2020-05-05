using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Explorable_Areas
{
    class Menu
    {
        private int selectedindex;
        private string[] choices;
        private string message;

        public Menu(string [] Choices,string Message)
        {
            
            choices = Choices;
            message = Message;
            selectedindex = 0;
        } 
        // This method creates menus.
        private void DisplayChoices()
        {
            WriteLine(message);
            for (int i = 0; i < choices.Length; i++)
            {
                string selectedoption = choices[i];
                string prefix;
                if (i== selectedindex)
                {
                    prefix = "-";
                    ForegroundColor = ConsoleColor.Magenta;
                    BackgroundColor = ConsoleColor.DarkBlue;

                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.DarkBlue;
                }
                WriteLine($"{prefix}<^**^>{selectedoption}<^**^>\r\n");
            }
            ResetColor();
        }
        // The Run method ultimately returns an integer (the index of the player's selection) that is used to trigger if statements.
        public int Run()
        {
            ConsoleKey keypressed;
            do
            {
                Clear();
                DisplayChoices();
                ConsoleKeyInfo keyinfo = ReadKey(true);
                keypressed = keyinfo.Key;
                if (keypressed == ConsoleKey.UpArrow)
                {
                    selectedindex--;
                    if (selectedindex == -1)
                    {
                        selectedindex = choices.Length - 1;
                    }
                }else if (keypressed == ConsoleKey.DownArrow)
                {
                    selectedindex++;
                    if (selectedindex == choices.Length)
                    {
                        selectedindex = 0;
                    }
                }

            } while (keypressed != ConsoleKey.Enter);
            return selectedindex;
        }
    }
}
