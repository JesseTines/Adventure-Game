using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Explorable_Areas
{
    class MoveablePlayer
    {
        public int x { get; set; }
        public int y { get; set; }
        private string character;
        private ConsoleColor charactercolor;

        public MoveablePlayer(int initialx, int initialy)
        {
            x = initialx;
            y = initialy;
            character = "^";
            charactercolor = ConsoleColor.Cyan;
        }
        // This method spawns characters in explorable areas.
        public void Spawn()
        {
            ForegroundColor = charactercolor;
            SetCursorPosition(x, y);
            Write(character);
            ResetColor();
        }
    }
}
