using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Explorable_Areas
{
    class Cave : Location
    {
        //private string explorablearea1;
       // private string explorablearea2;
       // private string explorablearea3;
        private Game newgame;
        private Maze newmaze;
        private MoveablePlayer newmoveableplayer;
       private Player theplayer;
        private AdventureGameItem item1;
        private AdventureGameItem item2;
        private NPC newnpc;
        private bool item1bool;
       // private bool isnotsecondtime;


            // This constructor instantiates three items and passes
        //them to the explore method which places them within a corresponding explorable area.
        public Cave(string name, int ExpareaNumber,Player ThePlayer)
            : base(name, ExpareaNumber )
        {
           
            AdventureGameItem firstitem = new AdventureGameItem("A silver coin", "common");
            AdventureGameItem watch = new AdventureGameItem("An old watch", "common");
            AdventureGameItem Aherosshield = new AdventureGameItem("A hero's shield", "Legendary");
            item1 = firstitem;
            theplayer = ThePlayer;
            string[,] cavearea = Maze.areacreator("TheCave.txt");
            newmaze = new Maze(cavearea);
            newmoveableplayer = new MoveablePlayer(2, 15);
            newgame = new Game(false);
            newgame.explore(newmaze, newmoveableplayer, theplayer,item1,watch,Aherosshield);
            //ExploreTheCave(theplayer);
           
            
            
            


             


        }

        public void Item1(Player ThePlayerItem)
        {
            if (item1bool)
            {
                ThePlayerItem.ReceiveItem(item1);
                newgame.NpcLines($"*{item1.name} has been added into your inventory. Level{item1.modifier}", false, true);
                // WriteLine("A silver coin had been added into your inventory. Level: Common\r\n\r\nPress the enter key to contine...");
                //Console.ReadKey();
                item1bool = false;
                Clear();
                



            }
            else if (item1bool == false)
            {
                newgame.NpcLines("*This item has already been added into your inventory.*", false, true);
                Clear();
               


            }


        }
       // public Player retrievetheplayer()
       // {
       //     return theplayer;
      //  }

       // public void ExploreTheCave(Player exploreplayer)
       // {
            
       // }
        
        

    }
}
