using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
// Jesse Tines Introduction To Programming Final Game Milestone 4 5/4/2020


// <summary> This solution is an adventure game of sorts. It mainly involved exploring areas and gathering items.
// The game can only be one by gathering certain things within the context of each explorable area.
//Additionally, certain choices must be made in order to win the game.

namespace Explorable_Areas
{
    class Game
    {
        private string username;
        private string npcname;
        private string NPC1;
        private string input = "";
        private bool hastItem1;
        private bool hasItem2;
        private bool hasAdvice;
        private Maze newMaze;
        private Kingdom newKingdom;
        private MoveablePlayer newmoveableplayer;
        private int loadingscreentime = 0;
        private Cave newCave;
        private int locationtrigger;
        private bool hasspecialcoin;
        private bool item1bool;
       
        


        // This is the beginning of the game. The bool isopening gets changed to false once the intro is complete.
        public Game(bool isopening)
        {
            
            if (isopening)
            {
                
                Displaymainmenu();
            }
            



        }
        // This is a method that creates a loading screen effect.
        public void loadingscreen()
        {
            string[] loadingscreen1 = { "Loading", ".", "..", "...", "....", "....." };
            do //(loadingscreentime < 2)
            {
                
                for (int loading = 0; loading < loadingscreen1.Length; loading++)
                {
                    
                    if (loading == loadingscreen1.Length)
                    {
                       // System.Threading.Thread.Sleep(100);
                        Clear();
                        loadingscreentime++;
                        loadingscreen();
                    }
                    Write(loadingscreen1[loading]);
                    loadingscreentime++;
                    System.Threading.Thread.Sleep(500);

                }
            }while (loadingscreentime < 2) ; //if (loadingscreentime > 500)
            {
                Clear();
                loadingscreentime= loadingscreentime - 2;
                NpcLines("Loading Process Complete!", false, true);
                
                Clear();
            }
           
            
            
        }
        // This method displays the main menu. Players can either choose to play the game or exit the game. 
        //Choosing to play the game initiates a method that creates an explorable area tutorial.
        public void Displaymainmenu()
        {
            Title = "Jesse's Adventure Game";
            CursorVisible = false;

            string prompt = "Welcome to Jesse's Adventure Game!\r\n\r\n This is the main menu!\r\n\r\n How would you like to proceed?\r\n\r\n";
            string[] choices = {"Play The Game","Exit The Game" };
            Menu themainmenu = new Menu(choices, prompt);
            int chosenindex = themainmenu.Run();
            if (chosenindex == 0)
            {
                Clear();
                loadingscreen();
                tutorial();
                NpcLines("Excellent! You are now ready to begin the game!",false,true);

                loadingscreen();
                Intro();
            }else if (chosenindex == 1)
            {
                Clear();
                exitthegame();
            }

            ReadKey();
            
            
        }
        
        private void exitthegame()
        {
            WriteLine("Goodbye.");
            Environment.Exit(0);
        }



        // This method creates an explorable area tutorial
        private void tutorial()
        {
            NpcLines("Greetings! Before you begin the game, you'll have to complete this tutorial which is based on explorable areas.",false,false,true,"Explorable Area");
            NpcLines("Important Information:\r\n\r\n- Doors/exits may look different in different exploreable areas but they will always be green.\r\n\r\n- Npc characters may look different in different explorable areas but they will always be blue.\r\n\r\n- Items may look different in different explorable areas but they will always be yellow.\r\n\r\n", false, false, true, "Explorable Area");
            NpcLines("Important Information:\r\n\r\n- Use your arrow keys to navigate throughout explorable areas.\r\n\r\n- In order to interract with an item or door, walk onto the space that it resides on. This method works for npc characters as well.\r\n\r\n", false, false, true, "Explorable Area");
            NpcLines("Lastly, you will be represented by this: ^ (in cyan)\r\n\r\n", false, false, true, "Explorable Area");
            NpcLines("In order to complete this tutorial, you must utilize some of the basic functions that you have just learned to naviagte through an explorable area.", false, false, true, "Explorable Area");
            string[,] tutorial = {
            {"*","*","*"," "," "," "," "," "," "," "," "," "," "," "," ","*","*","*"},
            {"*","*","*"," "," "," ","*","*"," ","*","*","*"," ","*","*"," "," ","*"},
            {" "," "," "," "," "," ","*","*"," ","*","*","*"," "," ","*"," "," ","*"},
            {"*","*","*","*","*","*","*","*"," "," ","*","*"," "," "," "," "," ","*"},
            {"*","*","*","*","*","*","*","*"," "," ","*","*"," ","*","*",""," ","[-]"},
            {"*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*","*"}


            };
            newMaze = new Maze(tutorial);
            newmoveableplayer = new MoveablePlayer(0, 2);
            
            explore(newMaze,newmoveableplayer);

        }


        // createarea() is a method that draws exlorable areas and spawns characters in them.
        public void createarea(Maze themaze1, MoveablePlayer themoveableplayer1)
        {
            Clear();
            themaze1.Create();
           themoveableplayer1.Spawn();
        }

        // The playermovements method handles all of the player's movements in explorable areas.
        public void playermovements(Maze themaze2, MoveablePlayer themoveableplayer2)
        {
            ConsoleKey TheKey;
            do
            {
                ConsoleKeyInfo thekey = ReadKey(true);
                TheKey = thekey.Key;
            } while (KeyAvailable);
            
            //ConsoleKeyInfo thekey = ReadKey(true);
            //ConsoleKey TheKey = thekey.Key;
            switch (TheKey)
            {
                case ConsoleKey.UpArrow:
                    if (themaze2.ispositionwalkable(themoveableplayer2.x, themoveableplayer2.y - 1))
                    {
                        themoveableplayer2.y -= 1;
                    }
                    
                    break;
                case ConsoleKey.DownArrow:
                    if (themaze2.ispositionwalkable(themoveableplayer2.x, themoveableplayer2.y + 1))
                    {
                        themoveableplayer2.y += 1;
                    }
                        
                    break;
                case ConsoleKey.LeftArrow:
                    if (themaze2.ispositionwalkable(themoveableplayer2.x - 1, themoveableplayer2.y))
                    {
                        themoveableplayer2.x -= 1;
                    }
                        
                    break;
                case ConsoleKey.RightArrow:
                    if (themaze2.ispositionwalkable(themoveableplayer2.x + 1, themoveableplayer2.y))
                    {
                        themoveableplayer2.x += 1;
                    }
                        
                    break;
                default:
                    break;
            }
        }
        

        // This method intiates an introduction sequence.
        // Three kinds of objects are instantiated in this method: 1 NPC, 1 Player, and 4 ExtraImportantItems.
        public  void Intro()
        {
            
            NpcLines("After walking for what has felt like an eternity, you spot a house in the distance.", false, true);
            NpcLines("Upon entering the house, you are immediately approached by an ancient being.", false, true);
            //WriteLine("Three clear choices present themselves to you...You begin to ponder upon what your \r\n choice may be but before you can form a complete thought,\r\nyou are approached by an anicent being.");
            
            NPC TalthoriustheWise = new NPC("Talthorius the Wise", "It is time for you to choose your fate...", "Remember traveler....the third strike, though seemingly meaningless, will always be the key to victory.", true);
            NPC1 = TalthoriustheWise.Name;
            //WriteLine($"{TalthoriustheWise.Name}: Greetings once again traveler, my name is {TalthoriustheWise.Name}.");
            NpcLines("Greetings once again traveler, my name is Talthorius the Wise.",true);
            WriteLine("You: Greetings, my name is ....... \r\nEnter your character's name below and press the enter key...");
            bool thetrueone = true;
            bool thefalseone = false;
            Player newplayer = new Player("", thetrueone, thefalseone, thefalseone, thefalseone,true,false,false,false,true,true,true,true,false);
            newplayer.Name = Console.ReadLine();
            Clear();

            
            username = newplayer.Name;
            //newplayer.hasitem1 = hastItem1;
            newplayer.hasitem1 = false;
            newplayer.hasitem2 = false;
            newplayer.hasadvice = false;
            hastItem1 = newplayer.hasitem1;             
            hasItem2 = newplayer.hasitem2;
            hasAdvice = newplayer.hasadvice;
           // WriteLine($"{newplayer.Name}: Greetings my name is {newplayer.Name}.\r\n");
            PlayerLines($"Greetings my name is {newplayer.Name}.");
            NpcLines("Ah yes the mighty {newplayer.Name}, how wonderful it is to see you again. What brings you here this time?!",true);
            //WriteLine($"{TalthoriustheWise.Name}: Ah yes the mighty {newplayer.Name}, how wonderful it is to see you again. What brings you here this time?!\r\n");
            PlayerLines("I'm not sure. For some reason I can't even seem to remember how I got here.\r\n And what do you mean by see you again? I've never seen you a day in my life!");
           // WriteLine($"{newplayer.Name}: I'm not sure. For some reason I can't even seem to remember how I got here.\r\n And what do you mean by see you again? I've never seen you a day in my life!");
           // WriteLine($"{TalthoriustheWise.Name}: Oh rest assured traveler, though you may not remember me, we have met many times.\r\n One may even say that we've always known eachother!");
            NpcLines("Oh rest assured traveler, though you may not remember me, we have met many times.\r\n One may even say that we've always known eachother!", true);
            //WriteLine($"{newplayer.Name}:I have no idea what you're talking about! You're crazy! \r\nWhy can't I remember how I got here! I need answers now!!");
            PlayerLines("I have no idea what you're talking about! You're crazy! \r\nWhy can't I remember how I got here! I need answers now!!");
            NpcLines($"Worry not dear traveler, all will be revealed in due time. For now, resign your questions. {TalthoriustheWise.message}",true);
            PlayerLines($"It's time for me to choose my fate?? What are you talking about?!");
            NpcLines("I have 3 items. You are going to choose one of those items.\r\n The item that you choose will have a direct effect on the end of your journey.\r\n C'mon traveler. Don't you know that we've done this dance many times before!",true);
            PlayerLines("Again, I promise you. I have no idea what you are talking about!");
            NpcLines("Again, I promise YOU traveler! You do indeed know of what I speak.",true);
            PlayerLines("I just want to get out of here! Can't you just let me leave? Must we do this again Talthorius!\r\n Wait what?!? You've tricked me into believing your twisted stories!");
            NpcLines("And now you see traveler, your fate is inescapable... As is mine...\r\n I know not of what you must do in order to complete your journey.\r\n What I do know is this, you must try something!",true);
            PlayerLines("Perhaps you are right Talthorius. What do you suggest?");
            NpcLines("Well, you could begin by oh I don't know....Quitting your joking and taking one of these three items!", true);
            PlayerLines("Fine. I guess I'll play this game if you think that's the best option.");
            NpcLines("Finally! Well, without further ado, here are your 3 choices...",true);
            List<ExtraImportantItem> TalthoriusInventory = new List<ExtraImportantItem>();
            ExtraImportantItem Compass = new ExtraImportantItem("a compass", "Legendary", "balanced", "truthful", "metallic");
            ExtraImportantItem FathersShield = new ExtraImportantItem("a father's shield", "Legendary", "somewhat unpleasant", "vengeful", "metallic");
            ExtraImportantItem AsimpleHelmet = new ExtraImportantItem("a simple helmet", "Legendary", "pleasant", "positive", "cloth");
            ExtraImportantItem RareCoin = new ExtraImportantItem("a rare coin", "Legendary", "n/a", "n/a", "metallic");
            TalthoriusInventory.Add(Compass);
            TalthoriusInventory.Add(FathersShield);
            TalthoriusInventory.Add(AsimpleHelmet);
            TalthoriusInventory.Add(RareCoin);
            // The first three items above trigger three different endings respectively.

            Compass.Present(1);
            WriteLine($"(1)\r\n This is {Compass.name}! \r\n Level: {Compass.modifier}\r\n Material: {Compass.material} \r\n This item posseses a {Compass.focus} focus!\r\n Consequetly, it will yield a {Compass.outcome} outcome.\r\n");
            FathersShield.Present(2);
            WriteLine($"(2)\r\n This is {FathersShield.name}! \r\n Level: {FathersShield.modifier}\r\n Material: {FathersShield.material} \r\n This item posseses a {FathersShield.focus} focus!\r\n Consequetly, it will yield a {FathersShield.outcome} outcome.\r\n");
            AsimpleHelmet.Present(3);
            WriteLine($"(3)\r\n This is {AsimpleHelmet.name}! \r\n Level: {AsimpleHelmet.modifier}\r\n Material: {AsimpleHelmet.material} \r\n This item posseses a {AsimpleHelmet.focus} focus!\r\n Consequetly, it will yield a {AsimpleHelmet.outcome} outcome.\r\n");
            //foreach (ExtraImportantItem e in TalthoriusInventory)
            //{

            //    int extra = 1;
            //    //extra++;
            //    int placement = 1;
            //   // placement++;
            //    e.Present(extra++);
            //    WriteLine($"({placement++})\r\n This is {e.name}! \r\n Level: {e.modifier}\r\n Material: {e.material} \r\n This item posseses a {e.focus} focus!\r\n Consequetly, it will yield a {e.outcome} outcome.");
                 
            //}

            NpcLines($"So, {newplayer.Name} what will you choose this time?", true);
            WriteLine("Your options: 1,2 or 3\r\nType your choice in the space below and press the enter key...");
            // This is where the user chooses their ending by choosing an item.
            input = Console.ReadLine();
            Clear();
            switch (input)
            {
                case "1":
                    Compass.Present(1);
                    newplayer.ReceiveItem(Compass);
                    newplayer.hascompass = true;
                    WriteLine("Excellent! You have selected the compass!\r\n\r\n *A compass has been inserted into your inventory.*\r\n Press the enter key to continue...");
                    ReadKey();
                    Clear();
                    break;
                case "2":
                    FathersShield.Present(2);
                    newplayer.ReceiveItem(FathersShield);
                    newplayer.hasshield = true;
                    WriteLine("Excellent! You have selected a father's shield!\r\n\r\n *A father's shield has been inserted into your inventory.*\r\n Press the enter key to continue...");
                    ReadKey();
                    Clear();
                    break;
                case "3":
                    AsimpleHelmet.Present(3);
                    newplayer.ReceiveItem(AsimpleHelmet);
                    newplayer.hashelmet = true;
                    WriteLine("Excellent! You have selected a simple helmet!\r\n\r\n *A simple helmet has been inserted into your inventory.*\r\n Press the enter key to continue...");
                    ReadKey();
                    Clear();
                    break;

            }
            NpcLines($"Good job {newplayer.Name}! You have succeeded in making a choice! Now for the next part...", true);
            PlayerLines("The next part!? What do you mean the next part!?\r\nI thought that making a decision was the only thing that I had to do!");
            NpcLines("You know that we both know that that is not the case traveler.\r\nMaking a decision is only a part of the journey!\r\n You must also follow through on your decision!",true);
            PlayerLines("Well...now that I know that useful piece of information, I don't feel very confident about my choice.\r\nCan I change it?");
            NpcLines("Nope! You've made a decision. You must now stick with it!",true);
            PlayerLines("Well..it seems like my only option is to trust my decision.");
            NpcLines("Correct!", true);
            PlayerLines("Thanks Talthorius!");
            NpcLines($"No problem {newplayer.Name}!\r\n{TalthoriustheWise.ImportantMessage}",true);
            PlayerLines("Indeed!");
            NpcLines("Also, one last thing...", true);
            PlayerLines($"Oh no.");
            NpcLines("Oh relax! It's not even that big of a deal.",true);
            PlayerLines("What is it?");
            NpcLines("Well.....you're going to have to make another choice.",true);
            PlayerLines("Oh come on!");
            NpcLines("I promise that this will be the last one...or at least one of the last ones",true);
            PlayerLines("Well..I guess I don't have much of a choice.");
            NpcLines("That is also true! Now that you're done pouting, we can get on with the show.\r\n Your next decision will meet you outside.\r\n You will have to decide where you would like to go.",true);
            PlayerLines("What are my options?");
            NpcLines("You will have two options: a cave and a kingdom.",true);
            PlayerLines("Why do I feel like there's something that you're not telling me?");
            NpcLines($"I'm not sure why you feel that way {newplayer.Name}. That sounds like a personal problem lol.",true);
            PlayerLines("Did you just say lol?");
            NpcLines("No matter! The time for talk has passed. It is time for you to play the game!",true);
            PlayerLines("Fine...See you soon I guess.");
            NpcLines("Indeed you will traveler.....indeed you will. One last last thing, take this rare coin as a symbol of our eternal friendship.",true);
            PlayerLines("Sweet. Thanks.\r\n\r\n*A rare coin has been added to your inventory.*");
            newplayer.ReceiveItem(RareCoin);
           
            NpcLines("Upon exiting the house through its back door, the three choices that you were told about present themselves to you.",false,true);
            locationtrigger++;
            SecondMenu(newplayer);



            
            



        }
        // The SecondMenu method serves as an entry point for both of the explorable areas within the game.
        // It can be revisited only through the use of the cave.
        // Once the player enters the kingdom, the SecondMenu method can no longer be revisited.
        public void SecondMenu(Player theplayer)
        {
            string prompt = "Location Menu";
            string[] choices = { "A Cave", "A Kingdom"};
            Menu secondmenu = new Menu(choices,prompt);
           int selection = secondmenu.Run();
            switch (selection)
            {
                case 0:
                    TheCave(theplayer);
                    break;
                case 1:
                    TheKingdom(theplayer);
                    break;
                default:
                    break;



            }
        }
        // This is an earlier version of the method below.
        public void explore(Maze themaze3, MoveablePlayer themoveableplayer3)
        {

            while (true)
            {
                createarea(themaze3, themoveableplayer3);
                playermovements(themaze3, themoveableplayer3);
                string playerposition = themaze3.gatherposition(themoveableplayer3.x, themoveableplayer3.y);
                if (playerposition == "[-]")
                {
                    Clear();
                    break;

                }
                else if (playerposition == "~")
                {
                    Clear();
                    // WriteLine("Test");
                    //ReadKey();

                    

                }
                //switch (playerposition)
                {
                    //case "[-]":
                    // break;
                    //    break;
                }
                System.Threading.Thread.Sleep(20);
            }


        }
        // Th explore method serves as the operating mechanism behind the all of the game's explorable areas.
        // It calls all of the necessary methods and triggers all of the reactions that happen as a result of the player's actions.

        public void explore(Maze themaze3, MoveablePlayer themoveableplayer3, Player exploreplayer, AdventureGameItem item1, AdventureGameItem item2, AdventureGameItem item3)
        {

            while (true)
            {
                createarea(themaze3, themoveableplayer3);
                playermovements(themaze3, themoveableplayer3);
                string playerposition = themaze3.gatherposition(themoveableplayer3.x, themoveableplayer3.y);
                if (playerposition == "[-]")
                {
                    Clear();
                    break;

                }
                else if (playerposition == "~")
                {
                    Clear();
                    // WriteLine("Test");
                    //ReadKey();
                    if (exploreplayer.firstitem)
                    {
                        exploreplayer.ReceiveItem(item2);
                        NpcLines($"*{item2.name} has been added into your inventory. Level: {item2.modifier}*", false, true);
                        exploreplayer.firstitem = false;

                    }
                    else
                    {
                        NpcLines("*This item has already been added into your inventory.*", false, true);
                    }


                    Cave secondcave = new Cave("A Cave", 1, exploreplayer);




                }else if (playerposition == "$")
                {
                    Clear();
                    if (exploreplayer.seconditem)
                    {
                        exploreplayer.ReceiveItem(item1);
                        NpcLines($"*{item1.name} has been added into your inventory. Level: {item1.modifier}*", false, true);
                        exploreplayer.seconditem = false;
                    }else
                    {
                        NpcLines("*This item has already been added into your inventory.*", false, true);
                    }
                    Cave secondcave = new Cave("A Cave", 1, exploreplayer);

                }else if (playerposition == "o")
                {
                    Clear();
                    if (exploreplayer.thirditem)
                    {
                        caveconversation(exploreplayer,item3);
                    }
                    else
                    {
                        NpcLines("You have already completed this conversation.", false, true);
                        Cave secondcave = new Cave("A Cave", 1, exploreplayer);
                    }
                    
                }else if (playerposition == "=")
                {
                    Clear();
                    SecondMenu(exploreplayer);
                }else if (playerposition == "{")
                {
                    Clear();
                    if (exploreplayer.hasitem2 == false)
                    {
                        exploreplayer.ReceiveItem(item1);
                        exploreplayer.hasitem2 = true;
                        NpcLines($"*{item1.name} has been added into your inventory. Level: {item1.modifier}*", false, true);


                    }
                    else
                    {
                        NpcLines("*This item has already been added into your inventory.*", false, true);
                    }
                    Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);


                }else if (playerposition == "O")
                {
                    Clear();
                    if (exploreplayer.fourthitem)
                    {
                        adviceconvo(exploreplayer,item2);
                    }
                    else
                    {
                        NpcLines("You have already completed this conversation.", false, true);
                        Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);
                    }
                }else if (playerposition == "0")
                {
                    Clear();
                    if (exploreplayer.hasitem1 == true && exploreplayer.hasitem2==true&&exploreplayer.hasadvice==true)
                    {
                        if (exploreplayer.hasrarecoin)
                        {
                            exploreplayer.gameover = true;
                            
                            NpcLines("Greetings once again traveler.", true);
                            PlayerLines("Talthorius?? What are you doing here?", exploreplayer);
                            NpcLines("You have passed the test traveler! You succeeded in not losing sight of what was given to you!", true);
                            PlayerLines("Are you talking about that coin that you gave me?", exploreplayer);
                            NpcLines("Yup. In order to celebrate your accomplishment, we've decided to share something with you.",true);
                            PlayerLines("Who is we?", exploreplayer);
                            NpcLines("Worry not traveler. All will be revealed soon.",true);
                            PlayerLines("Ok.", exploreplayer);
                            NpcLines("Now, for the news that we have for you..Actually, you know what. Would you like some lemonade first?",true);
                            string drinkchoice = "What is your decision?";
                            string[] lastdecision = {"No","Yes" };
                            Menu thirdmenu = new Menu(lastdecision, drinkchoice);
                            int drinkselection = thirdmenu.Run();
                            if (drinkselection == 0)
                            {
                                NpcLines("Excellent! You have passed the final test!", true);
                                PlayerLines("Sweet.", exploreplayer);
                                if (exploreplayer.hascompass)
                                {
                                    NpcLines("At the beginning of the game, you chose the compass.",true);
                                    NpcLines("That compass was given to you by your mother. She enchanted it with love and magical energy. If you follow it you will never be lost.",true);
                                    PlayerLines("You're right! I remember now!....Wait why can't I remember anything about the other items?",exploreplayer);
                                    NpcLines("As I have said, all will be revealed in due time traveler. There is always more to learn.",true);
                                    PlayerLines("Ok I think I finally understand. What am I supposed to do now?", exploreplayer);
                                    NpcLines("You must do the only thing that there is to do traveler: move forward... Specifically, towards the door that's behind me.",true);
                                    PlayerLines("What's behind the door?", exploreplayer);
                                    NpcLines("I don't know traveler, I guess you'll just have to find out.",true);
                                    PlayerLines("Ok I think I'm ready.", exploreplayer);
                                    NpcLines("I think you're ready too traveler. Goodbye for now.",true);
                                    exploreplayer.hasitem2 = false;
                                    Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);

                                }
                                else if (exploreplayer.hashelmet)
                                {
                                    NpcLines("At the beginning of the game, you chose the helmet.", true);
                                    NpcLines("That helmet was previosuly owned by a very good friend of yours. He crafted it with the finest metals known to man. It will completely protect you from any kind of enemy. ", true);
                                    PlayerLines("You're right! I remember now!....Wait why can't I remember anything about the other items?", exploreplayer);
                                    NpcLines("As I have said, all will be revealed in due time traveler. There is always more to learn.", true);
                                    PlayerLines("Ok I think I finally understand. What am I supposed to do now?", exploreplayer);
                                    NpcLines("You must do the only thing that there is to do traveler: move forward... Specifically, towards the door that's behind me.", true);
                                    PlayerLines("What's behind the door?", exploreplayer);
                                    NpcLines("I don't know traveler, I guess you'll just have to find out.", true);
                                    PlayerLines("Ok I think I'm ready.", exploreplayer);
                                    NpcLines("I think you're ready too traveler. Goodbye for now.", true);
                                    exploreplayer.hasitem2 = false;
                                    Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);
                                }else if (exploreplayer.hasshield)
                                {
                                    NpcLines("At the beginning of the game, you chose the shield.", true);
                                    NpcLines("That shield was given to you by your. The front of it bares the symbol of the resistance. Upon being raised to the sky, it will send a signal to every resistance member, alive or dead.", true);
                                    PlayerLines("You're right! I remember now!....Wait why can't I remember anything about the other items? ", exploreplayer);
                                    NpcLines("As I have said, all will be revealed in due time traveler. There is always more to learn.", true);
                                    PlayerLines("Ok I think I finally understand. What am I supposed to do now?", exploreplayer);
                                    NpcLines("You must do the only thing that there is to do traveler: move forward... Specifically, towards the door that's behind me.", true);
                                    PlayerLines("What's behind the door?", exploreplayer);
                                    NpcLines("I don't know traveler, I guess you'll just have to find out.", true);
                                    PlayerLines("Ok I think I'm ready.", exploreplayer);
                                    NpcLines("I think you're ready too traveler. Goodbye for now.", true);
                                    exploreplayer.hasitem2 = false;
                                    Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);
                                }
                            }else if (drinkselection == 1)
                            {
                                NpcLines("Unfortunately, you have failed the final test. Goodbye.",false,true);
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            NpcLines("Greetings once again traveler.", true);
                            PlayerLines("Talthorius?? What are you doing here?",exploreplayer);
                            NpcLines("Why'd you have to do it traveler? Why?",true);
                            PlayerLines("What are you talking about?", exploreplayer);
                            NpcLines("You lost sight of what was given to you.", true);
                            PlayerLines("Wait are you talking about that coin?",exploreplayer);
                            NpcLines("I tried to talk them out of it but the rules are the rules.",true);
                            PlayerLines("What are you talking about?", exploreplayer);
                            NpcLines("Until next time traveler...", true);
                            PlayerLines("Noooooooooo",exploreplayer);
                            Environment.Exit(0);
                        }
                    }else
                    {
                        NpcLines("You don't have all of the items that you need in order to interract with this npc.", false, true);
                        NpcLines("If you have not already visited the Cave. You need to restart the game and try again.", false, true);
                        NpcLines("On the other hand, you may have finished the game. Try to exit through the green door in this level and see if the game allows you to leave.",false,true);

                        Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);

                    }
                }else if (playerposition == "%")
                {
                    if (exploreplayer.gameover)
                    {
                        Clear();
                        string theend = "Congratulations! You have completed the game!";
                        string[] lastchoices = { "Credits", "End the game" };
                        Menu lastmenu = new Menu(lastchoices,theend);
                        int lastchoice = lastmenu.Run();
                        if (lastchoice == 0)
                        {
                            Clear();
                            WriteLine("Credits:\r\n");
                            WriteLine(@"The Compass: https://ascii.co.uk/art/compass");
                            WriteLine(@"The Helmet: https://ascii.co.uk/art/helmet");
                            WriteLine(@"The Shield: https://www.asciiart.eu/weapons/shields");
                            ReadKey();
                            Environment.Exit(0);
                        }else if (lastchoice == 1)
                        {
                            Clear();
                            WriteLine("Goodbye.");
                            Environment.Exit(0);
                        }

                    }else
                    {
                        NpcLines("You have not met all of the requirements that are needed in order to end the game.", false, true);
                        NpcLines("If you have not already visited the Cave. You need to restart the game and try again.", false, true);
                        Kingdom secondKingdom = new Kingdom("A Kingdom", 1, exploreplayer);
                    }
                }
                
                //switch (playerposition)
               // /{
                    //case "[-]":
                    // break;
                    //    break;
               // }
                System.Threading.Thread.Sleep(20);
            }



        }
        // The caveconversation method is called by the explore method when certain conditions are met.
        // Once initiated, the caveconversation method gives the player a chance to gain a shield (a hero's shield).
        // The hero's shield is one of the items that is required to win the game.
        private void caveconversation(Player theplayercaveconvo, AdventureGameItem theshield)
        {

            NpcLines("Marcus", "Hi.");
            PlayerLines("Hello",theplayercaveconvo);
            NpcLines("Marcus","Would you like a shield?");
            PlayerLines("Why would I need a shield?",theplayercaveconvo);
            NpcLines("Marcus", "You never know man, life is crazy.");
            PlayerLines("That is true.",theplayercaveconvo);
            string prompt = "Do you want the shield?";
            string[] choices = {"Yes","No" };
            Menu caveconvo = new Menu(choices, prompt);
            int selection = caveconvo.Run();
            if (selection == 0)
            {
                Clear();
                NpcLines("Marcus", "Cool. All you have to do is fill in the blank of the following sentence.");
                string prompt1 = "The ______ strike, though seemingly meaningless, will always be the key to victory.";
                string[] answers = {"first","third","last" }; 
                Menu convoquestion = new Menu(answers,prompt1);
                int answer = convoquestion.Run();
                if (answer == 0)
                {
                    NpcLines("Marcus","I'm sorry that's the wrong answer.");
                    PlayerLines("Aw man.",theplayercaveconvo);
                    NpcLines("Marcus","If you still want the shield, you can have it. I just can't give it to you for free.");
                    PlayerLines("Could I maybe try to answer some other question for it?",theplayercaveconvo);
                    NpcLines("Marcus","No.");
                    PlayerLines("Why not?",theplayercaveconvo);
                    NpcLines("Marcus", "Those are the rules.");
                    PlayerLines("Ok I guess. Well...I don't have a lot of money. What's your price?",theplayercaveconvo);
                    NpcLines("Marcus", "Do you happen to have a rare coin?");
                    PlayerLines("Well, yeah but my friend Talthorius gave it to me.",theplayercaveconvo);
                    NpcLines("Marcus", "I'll accept that as a payment.");
                    PlayerLines("That's an oddly specific request. What if I need it later?",theplayercaveconvo);
                    NpcLines("Marcus","That sounds like a you problem.Lol.");
                    PlayerLines("Did you just say lol? Wait a minute! Is that you Talthorius?!",theplayercaveconvo);
                    NpcLines("Marcus", "Nope, I'm definitely not Talthorius pretending to be someone else right now. My name is Marcus.\r\n\r\nDo you want the shield or not?\r\n");
                    string prompt2 = "What is your decision?";
                    string[] finalchoices = { "Lose your rare coin", "Lose your chance at obtaining the shield" };
                    Menu thedecision = new Menu(finalchoices, prompt2);
                    int finalselection = thedecision.Run();
                    if (finalselection == 0)
                    {
                        theplayercaveconvo.RemoveItem(1);
                        theplayercaveconvo.ReceiveItem(theshield);
                        theplayercaveconvo.hasitem1 = true;
                        theplayercaveconvo.thirditem = false;
                        theplayercaveconvo.hasrarecoin = false;
                        NpcLines("Marcus", "Sweet. Thanks. Here you go. Bye bye now.\r\n\r\n*A hero's shield has been added into your inventory.*\r\n\r\nA rare coin has been removed from your inventory.*\r\n");
                        Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
                    } else if (finalselection == 1)
                    {
                        NpcLines("Marcus", "Ok bye.");
                        theplayercaveconvo.thirditem = false;
                        Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
                    }

                }else if (answer == 1)
                {
                    
                    theplayercaveconvo.ReceiveItem(theshield);
                    theplayercaveconvo.thirditem = false;
                    theplayercaveconvo.hasitem1 = true;
                    NpcLines("Marcus", "Nice. That's the right answer. Here you go. Bye bye now.\r\n\r\n*A hero's shield has been added into your inventory.*\r\n");
                    Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
                }else if (answer == 2)

                {
                    NpcLines("Marcus", "I'm sorry that's the wrong answer.");
                    PlayerLines("Aw man.",theplayercaveconvo);
                    NpcLines("Marcus", "If you still want the shield, you can have it. I just can't give it to you for free.");
                    PlayerLines("Could I maybe try to answer some other question for it?",theplayercaveconvo);
                    NpcLines("Marcus", "No.");
                    PlayerLines("Why not?",theplayercaveconvo);
                    NpcLines("Marcus", "Those are the rules.");
                    PlayerLines("Ok I guess. Well...I don't have a lot of money. What's your price?",theplayercaveconvo);
                    NpcLines("Marcus", "Do you happen to have a rare coin?");
                    PlayerLines("Well, yeah but my friend Talthorius gave it to me.",theplayercaveconvo);
                    NpcLines("Marcus", "I'll accept that as a payment.");
                    PlayerLines("That's an oddly specific request. What if I need it later?",theplayercaveconvo);
                    NpcLines("Marcus", "That sounds like a you problem.Lol.");
                    PlayerLines("Did you just say lol? Wait a minute! Is that you Talthorius?!",theplayercaveconvo);
                    NpcLines("Marcus", "Nope, I'm definitely not Talthorius pretending to be someone else right now. My name is Marcus.\r\n\r\nDo you want the shield or not?\r\n");
                    string prompt2 = "What is your decision?";
                    string[] finalchoices = { "Lose your rare coin", "Lose your chance at obtaining the shield" };
                    Menu thedecision = new Menu(finalchoices, prompt2);
                    int finalselection1 = thedecision.Run();
                    if (finalselection1 == 0)
                    {
                        theplayercaveconvo.RemoveItem(1);
                        theplayercaveconvo.ReceiveItem(theshield);
                        theplayercaveconvo.hasitem1 = true;
                        theplayercaveconvo.thirditem = false;
                        theplayercaveconvo.hasrarecoin = false;
                        NpcLines("Marcus", "Sweet. Thanks. Here you go. Bye bye now.\r\n\r\n*A hero's shield has been added into your inventory.*\r\n\r\nA rare coin has been removed from your inventory.*\r\n");
                        Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
                    }
                    else if (finalselection1 == 1)
                    {
                        NpcLines("Marcus", "Ok bye.");
                        theplayercaveconvo.thirditem = false;
                        Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
                    }
                }
            }
            else if (selection == 1)
            {
                Clear();
                NpcLines("Marcus", "Ok bye");

                Cave secondcave = new Cave("A Cave", 1, theplayercaveconvo);
            }
        }
        // This method initiates the drawing of the kindom explorable area.
        public void TheKingdom(Player theplayer2)
        {
            newKingdom = new Kingdom("A Kingdom", 1, theplayer2);
        }
        // The adviceconvo method gives the player a chance to obtain useful advice.
        // It is called by the explore method when certain conditions are met.
        public void adviceconvo(Player theplayer3, AdventureGameItem theadvice)
        {
            NpcLines("Aaron","Greetings.");
            PlayerLines("Hello", theplayer3);
            NpcLines("Aaron", "Would you like some advice?");
            PlayerLines("Sure, why not. What oddly specific thing would you like in return for this advice?",theplayer3);
            NpcLines("Aaron", "The advice is free friend. All you must do is choose to accept it.");
            string adviceprompt = "What is your choice?";
            string[] decisions = { "Accept the advice","Deny the advice" };
            Menu advicemenu = new Menu(decisions, adviceprompt);
            int advicedecision = advicemenu.Run();

            if (advicedecision == 0)
            {
                Clear();
                theplayer3.fourthitem = false;
                theplayer3.hasadvice = true;
                theplayer3.ReceiveItem(theadvice);
                NpcLines("Aaron", "Cool. Here's the advice: the lemonade in this kingdom is not very good.");
                NpcLines("*Advice has been added into your inventory.*",false,true);
                PlayerLines("Thank you. That is very useful information.", theplayer3);
                NpcLines("Aaron", "Yup. No problem. Bye bye now. Have a nice day.");
                PlayerLines("Thank you",theplayer3);
                Kingdom secondkingdom = new Kingdom("A Kingdom", 1, theplayer3);
            }
            else if (advicedecision == 1)
            {
                Clear();
                theplayer3.fourthitem = false;
                NpcLines("Aaron", "Ok bye.");
                Kingdom secondkingdom = new Kingdom("A Kingdom", 1, theplayer3);

            }
        }
        // This method does the same thing that the kingdom method does.
        // The only difference is that it draws a cave explorable area.
        public void TheCave(Player theplayer1)
        {
            newCave = new Cave("The Cave", 1, theplayer1);


        }
        // The NpcLines method handles all of the writeline statements for npc characters and narration situations.
        // The NpcLines method also features three overloads.

        public void NpcLines(string message1, bool isTalthorius, bool isNarration, bool isTutorial, string tutorialname)
        {
            WriteLine($"{tutorialname} Tutorial:\r\n\r\n");
            WriteLine($"{message1}\r\n\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();

        }
        public void NpcLines(string message1, bool isTalthorius, bool isNarration)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"{message1}\r\n\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();
        }
        public  void NpcLines(string message1, bool isTalthorius)
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine($"Talthorius the Wise: {message1}\r\n\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();
            
        }
        public void NpcLines(string npcname ,string message1)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"{npcname}: {message1}\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();
            
        }
        // All PlayerLines methods handle all of the player's writeline statements.
        public void PlayerLines(string message1)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"{username}: {message1}\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();
        }public void PlayerLines(string message1, Player playername)
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine($"{playername.Name}: {message1}\r\n");
            WriteLine("Press the enter key to continue...\r\n");
            ReadKey();
            ResetColor();
            Clear();
        }
        
    }
}
