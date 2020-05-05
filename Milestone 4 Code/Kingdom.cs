using System;
using System.Collections.Generic;
using System.Text;

namespace Explorable_Areas
{
    class Kingdom : Location
    {
        // private string explorablearea1;
        // private string explorablearea2;
        // private string explorablearea3;
        // private int numberofbuildings;
        private Game newgame;
        private Maze newmaze;
        private MoveablePlayer newmoveableplayer;
        private Player theplayer;

        // This constructor instantiates three items and passes
        //them to the explore method which places them within a corresponding explorable area.
        public Kingdom(string name,  int expn, Player ThePlayer)
            : base (name, expn)
        {
            AdventureGameItem aherossword = new AdventureGameItem("A hero's sword", "Legendary");
            AdventureGameItem advice = new AdventureGameItem("Advice", "Legendary");
            theplayer = ThePlayer;
            string[,] kingdomarea = Maze.areacreator("Kingdomarea.txt");
            newmaze = new Maze(kingdomarea);
            newmoveableplayer = new MoveablePlayer(31,2);
            newgame = new Game(false);
            newgame.explore(newmaze, newmoveableplayer, theplayer, aherossword, advice, advice);    
        }
    }
}
