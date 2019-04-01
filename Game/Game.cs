using StateStuff;
using System.Collections.Generic;
using UnityEngine;

public class Game
{

    Player player;
    bool playing;

    public static Parser parser;

    public Item Item;
    public Weapon weapon = new Weapon();
    public Item item = new Item();

    public CommandWords CommandWords;

    public List<Ability> npcAbilities = new List<Ability>();
    //public static event Action<State<Game>> ChangeParser;
    public bool switchState = false;
    public StateMachine<Game> StateMachine { get; set; }
    public State<Game> State;
    public Game(GameOutput gameIO)
    {
        playing = false;

        parser = new Parser(new CommandWords());
        player = new Player(createWorld(), gameIO);

    }

    public void start()
    {
        playing = true;
        StateMachine = new StateMachine<Game>(this);
        StateMachine.changeState(MainMenuState.Instance);
        player.outputMessage(MainMenuState.Instance.enterState(this));

        Command[] menuCommands = { new HelpCommand(), new QuitCommand(), new NewGameCommand(), new LoadGameCommand() };
        parser = new Parser(new CommandWords());
        Parser(menuCommands);
       
    }
    public void Parser(Command[] commands)
    {
        parser = new Parser(new CommandWords(commands));

        string commandList = "";
        foreach (var i in commands)
        {
            commandList += i + " ";
        }
        Debug.Log(commandList);
    }
    public Room createWorld()
    {
        #region CREATE ROOMS

        Room townSquare = new Room("Assets/RoomScripts/townsquare intro.txt", "town square");
        Room dragonInn = new Room("Assets/RoomScripts/dragonInn intro.txt", "dragon inn");
        Room innBasement = new Room("Assets/RoomScripts/innBasement intro.txt", "inn basement");
        Room lostWoods = new Room("Assets/RoomScripts/lostWoods intro.txt", "lost woods");
		Room tunnels = new Room("Assets/RoomScripts/tunnels intro.txt", "tunnels");
        Room market = new Room("Assets/RoomScripts/market intro.txt", "market");
        Room impasseOfLostSteps = new Room("Assets/RoomScripts/impasseOfLostSteps intro.txt", "impasse of lost steps");
        Room oldDocks = new Room("Assets/RoomScripts/oldDocks intro.txt", "old docks");
        Room castlePlaza = new Room("Assets/RoomScripts/castlePlaza intro.txt", "castle plaza");
        Room library = new Room("Assets/RoomScripts/library intro.txt", "library");
        Room archives = new Room("Assets/RoomScripts/archives intro.txt", "archives");
        Room guardRoom = new Room("Assets/RoomScripts/guardRoom intro.txt", "guard room");
        Room banquetHall = new Room("Assets/RoomScripts/banquetHall intro.txt", "banquet hall");
        Room throneRoom = new Room("Assets/RoomScripts/throneRoom intro.txt", "throne room");

		townSquare.setExit("east", dragonInn);
		townSquare.setExit("west", market);

		market.setExit("north", oldDocks);
		market.setExit("south", impasseOfLostSteps);
		market.setExit("east", townSquare);

		impasseOfLostSteps.setExit("north", market);
		impasseOfLostSteps.setExit("south", castlePlaza);

		oldDocks.setExit("south", market);

		dragonInn.setExit("west", townSquare);
		dragonInn.setExit("south", innBasement);
		dragonInn.setExit("east", lostWoods);

		innBasement.setExit("north", dragonInn);

		lostWoods.setExit("north", tunnels);
		lostWoods.setExit("west", dragonInn);

		tunnels.setExit("south", lostWoods);
		tunnels.setExit ("west", castlePlaza);

		castlePlaza.setExit ("east", guardRoom);
		castlePlaza.setExit ("west", library);

		guardRoom.setExit ("north", throneRoom);
		guardRoom.setExit ("west", castlePlaza);

		throneRoom.setExit ("south", guardRoom);
		throneRoom.setExit ("west", castlePlaza);

		library.setExit ("east", castlePlaza);
		library.setExit ("north", archives);

		archives.setExit ("south", library);
		archives.setExit ("east", banquetHall);

		banquetHall.setExit ("west", archives);
		banquetHall.setExit ("south", guardRoom);



        #endregion

        #region ITEMS

		var walesUnderwear = new Item("Rare Artifact", "cheetah print drawers");


        var hulkingSword = new Weapon("Hulking Sword", "weapon");
        var bronzeSword = new Weapon("Bronze Sword", "weapon");
        var needsNerfSword = new Weapon("The Biggoron Sword", "weapon");
        var enchantedStaff = new Weapon("Enchanted Staff", "weapon");
		var swordOfTruths = new Weapon("Sword of 1000 Truths", "weapon");
		var dragonSword = new Weapon("Dragon Sword", "weapon");
		var crueltySword = new Weapon("Cruelty Sword", "weapon");
		var harbringer = new Weapon("Harbringer", "weapon");
		var diamondsword = new Weapon("Diamond Sword", "weapon");
		var kingerSlayer = new Weapon("King Slayer", "weapon");
		var thanosGuantlet = new Weapon("Thanos's Guantlet", "weapon");
		var rapier = new Weapon("Rapier", "weapon");
		var ironSword = new Weapon("Iron Sword", "weapon");

        var tigerHelm = new Armor("Helmet of the Tiger", "helmet");
        var bearHelm = new Armor("Helmet of the Bear", "helmet");
		var wolfHelm = new Armor("Helmet of the Wolf", "helmet");
		var bronzeHelm = new Armor("Bronze Helmet", "helmet");
		var ironHelm = new Armor("Iron Helmet", "helmet");
		var dragonHelm = new Armor("Dragon Helmet", "helmet");
		var thanosHelm = new Armor("Thanos's Helmet", "helmet");

        var bearChest = new Armor("Chest of the Bear", "chest piece");
        var tigerChest = new Armor("Chest of the Tiger", "chest piece");
		var wolfChest = new Armor("Chest of the Wolf", "chest piece");
		var bronzeChest = new Armor("Bronze Chest", "chest piece");
		var ironChest = new Armor("Iron Chest", "chest piece");
		var dragonChest = new Armor("Dragon Chest", "chest piece");
		var thanosChest = new Armor("Thanos's Chest", "chest piece");

        var bearShield = new Armor("Shield of the Bear", "shield");
        var tigerShield = new Armor("Shield of the Tiger", "shield");
		var wolfShield = new Armor("shield of the Wolf", "shield");
		var bronzeShield = new Armor("Bronze Shield", "shield");
		var ironShield = new Armor("Iron Shield", "shield");
		var dragonShield = new Armor("Dragon Shield", "shield");
		var thanosShield = new Armor("Thanos's Shield", "shield");

        Potion healthPotion0 = new Potion("Weaker Health Potion", "health potion");
		Potion healthPotion1 = new Potion("Average Health Potion", "health potion");
		Potion healthPotion2 = new Potion("Major Health Potion", "health potion");
		Potion healthPotion3 = new Potion("Minor Health Potion", "health potion");
		Potion healthPotion4 = new Potion("Weak Health Potion", "health potion");
		Potion healthPotion5 = new Potion("Weakest Health Potion", "health potion");
		Potion healthPotion6 = new Potion("Strong Health Potion", "health potion");
		Potion healthPotion7 = new Potion("Stronger Health Potion", "health potion");
		Potion healthPotion8 = new Potion("Strongest Health Potion", "health potion");
		Potion healthPotion9 = new Potion("Typical Health Potion", "health potion");
		Potion healthPotion10 = new Potion("Super Health Potion", "health potion");
        #endregion

        #region CHEST

        //instantiating the chest
        //Chest goldChest = new Chest("There sits a GOLD CHEST glittering in the corner");


        Chest brokenChest = new Chest("There sits a BROKEN CHEST laying on the ground, must have fallen off a cart.");
        brokenChest.setItem("Bronze Sword", bronzeSword);
        brokenChest.setItem("Shield of the Bear", bearShield);
        brokenChest.setItem("Helmet of the Bear", bearHelm);
		brokenChest.setItem("Chest of the Bear", bearChest);
		brokenChest.setItem("Weaker Health Potion", healthPotion0);

		Chest goldChest = new Chest("You see a gold chest GLITTERING in the corner.");
		goldChest.setItem("Thanos's Guantlet", thanosGuantlet);
		goldChest.setItem("Thanos's Shield", thanosShield);
		goldChest.setItem("Thanos's Chest", thanosChest);
		goldChest.setItem("Thanos's Helmet", thanosHelm);
		goldChest.setItem("Minor Health Potion", healthPotion3);

		Chest pirateChest = new Chest("Beneath the dock you see a sunken chest.");
		pirateChest.setItem("Rapier", rapier);
		pirateChest.setItem("Average Health Potion", healthPotion1);
		pirateChest.setItem("Iron Chest", ironChest);
		pirateChest.setItem("Iron Helm", ironHelm);
		pirateChest.setItem("Iron Shield", ironShield);

		Chest weapingChest = new Chest("You hear a weaping cry flow from the chest as it slowly fills the room with water.");
		weapingChest.setItem("The Biggoron Sword", needsNerfSword);
		weapingChest.setItem("Weak Health Potion", healthPotion4);
		weapingChest.setItem("Dragon Shield", dragonShield);

		Chest silverChest = new Chest("You see a silver chest GLITTERING in the corner.");
		silverChest.setItem("Cruelty", crueltySword);
		silverChest.setItem("Weakest Health Potion", healthPotion5);
		silverChest.setItem("Dragon Chest", dragonChest);

		Chest trollChest = new Chest("You see a chest sitting there in the trolls cave.");
		trollChest.setItem("King Slayer", kingerSlayer);
		trollChest.setItem("Strong Health Potion", healthPotion6);
		trollChest.setItem("Dragon Helmet", dragonHelm);

		Chest secretChest = new Chest("There is a secret chest.");
		secretChest.setItem("Rapier", rapier);
		secretChest.setItem("Stronger Health Potion", healthPotion7);
		secretChest.setItem("Helmet of the Wolf", wolfHelm);
		secretChest.setItem("Chest of the Wolf", wolfChest);
		secretChest.setItem("Shield of the Wolf", wolfShield);


		//set chests
        townSquare.setChest("Broken Chest", brokenChest);
		lostWoods.setChest("Troll Chest", trollChest);
		innBasement.setChest("Weaping Chest", weapingChest);
		library.setChest("Gold Chest", goldChest);
		impasseOfLostSteps.setChest("Silver Chest", silverChest);
		oldDocks.setChest("Pirates Chest", pirateChest);
		archives.setChest("Secret Chest", secretChest);



        #endregion

        #region NPCS

        //setting NPC
        // string name, string tag, int hp, int ad, int def, bool attackable? , bool merchant?

        NPC king1 = new NPC("Mad King", "You will not prevail... ", 80, 20, 20, true, false);
        throneRoom.setNpc("Mad King", king1);

		NPC troll = new NPC("Troll", "You will not prevail... ", 80, 20, 20, true, false);
        lostWoods.setNpc("Troll", troll);

		NPC skeletons = new NPC("Skeletons", "GARRRGHHHH", 30, 10, 10, true, false);
		tunnels.setNpc("Skeletons", skeletons);

		NPC gang = new NPC("Crooked Gang", "What do we have here?!", 50, 20, 20, true, false);
		impasseOfLostSteps.setNpc("Crooked Gang", gang);

        NPC weaponVendor = new NPC("Weapon Vendor",
            " HELLOOOOOO TRAVELER! You look like an adventurer, maybe interested in some weapons?!", 200, 200, 200,
            false, true);
        market.setNpc("Weapon Vendor", weaponVendor);
		weaponVendor.setItem("Sword of 1000 Truths", swordOfTruths);
        weaponVendor.setItem("Diamond Sword", diamondsword);
		weaponVendor.setItem("Enchanted Staff", enchantedStaff);
		weaponVendor.setItem("Harbringer", harbringer);

		NPC khajit = new NPC("Khajit", " Meow", 10, 10, 10, false, true);
		market.setNpc("Khajit", khajit);
		khajit.setItem("Major Health Potion", healthPotion2);
		khajit.setItem("Strongest Health Potion", healthPotion8);
		khajit.setItem("Typical Health Potion", healthPotion9);
		khajit.setItem("Super Health Potion", healthPotion10);

		NPC itemVendor = new NPC("Item Vendor", " Hrrrmmmmm, I am a little lost, but I have some wares for sale if you would like to see?", 20, 20, 20,
			false, true);
		tunnels.setNpc("Item Vendor", itemVendor);
		itemVendor.setItem("Iron Sword", ironSword);
		itemVendor.setItem("Hulking Sword", hulkingSword);

		NPC bartender = new NPC("Bartender",
			"Hello! I have an item you may enjoy! It is very rare and only cost a small amount of gold.", 50, 50,
			50, false, true);
		dragonInn.setNpc("Bartender", bartender);
		bartender.setItem("Rare Artifact", walesUnderwear);


        #endregion

        return townSquare;
    }



    public void Update()
    {
        StateMachine.update();


        // Debug.Log(this.StateMachine.currentState);


    }
		

    public void end()
    {
        playing = false;
        player.outputMessage(GameOverState.Instance.enterState(this));
    }



    public bool execute(string commandString)
    {
        bool finished = false;


        if (playing)
        {

            player.outputMessage("\n>" + commandString);
            Command command = parser.parseCommand(commandString);
            if (command != null)
            {
                finished = command.execute(player);
            }
            else
            {
                player.outputMessage("\nI don't understand what you mean by '<b>" + commandString + "</b>'");
            }


        }
        return finished;
    }


}

