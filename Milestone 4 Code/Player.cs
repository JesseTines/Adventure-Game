using System;
using System.Collections.Generic;
using System.Text;

namespace Explorable_Areas
{
    class Player : Person
    {
        public bool hasitem1;
        public bool hasitem2;
        public bool hasadvice;
        public bool firstitem;
        public bool hascompass;
        public bool hasshield;
        public bool hashelmet;
        public bool seconditem;
        public bool thirditem;
        public bool gameover;
        public bool fourthitem;
        public bool hasrarecoin;
        List<AdventureGameItem> Inventory = new List<AdventureGameItem>();

        public Player (string Name, bool isplayer, bool Hasitem1, bool Hasitem2, bool Hasadvice,bool Firstitem,bool HasCompass,bool HasShield, bool HasHelmet, bool SecondItem, bool ThirdItem,bool FourthItem, bool HasRareCoin,bool GameOver)
            : base(Name, isplayer)
        {
            hasitem1 = Hasitem1;
            hasitem2 = Hasitem2;
            hasadvice = Hasadvice;
            firstitem = Firstitem;
            hascompass = HasCompass;
            hasshield = HasShield;
            hashelmet = HasHelmet;
            seconditem = SecondItem;
            thirditem = ThirdItem;
            fourthitem = FourthItem;
            hasrarecoin = HasRareCoin;
            gameover = GameOver;
        }
        // The ReceiveItem method adds intems to the player's inventory.
        public void ReceiveItem(object newitem)
        {
            Inventory.Add(newitem as AdventureGameItem);
        }

        // The RemoveItem method removes an item from the player's inventory that is at an index that is passed to the method.
        public void RemoveItem (int index)
        {
            Inventory.RemoveAt(index);
            
        }


        
    }
}
