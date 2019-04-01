using StateStuff;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Player
{
    public Armor armor;
    public Item item;
    public Parser Parser;
    public System.Random randomPlayer = new System.Random();
    public State<Game> currentState;
    public static event Action<Dictionary<string, Room>> playerEnteredRoom;
    public static event Action<string> changeDifficulty;
    public static event Action<string> UnlockAchievement;
    public NPC npc;
    public Potion potion;
    public Weapon weapon;

    private int _charWeightCarried;
    public int charWeightCarried
    {
        get { return _charWeightCarried; }
        set { _charWeightCarried = value; }


    }
    public Weapon primaryWeapon;
    public Armor helmet;
    public Armor shield;
    public Armor chestPiece;

    private string _playerName;
    public string playerName
    {
        get { return _playerName; }
        set { _playerName = value; }
    }

    bool usedpotion = true;
    bool equipedweapon = true;
    bool openedchest = true;

    AchievementsManager achievementManager = new AchievementsManager();


    private GameOutput gameIO;
    private CharacterClass _currentClass;
    private Ability abilities;
    public Game game;
    public Player player;
    public Mage mage = new Mage();
    public Paladin pally = new Paladin();
    public Witcher witcher = new Witcher();
    public Room room;


    private Item _thisItem = null;
    public Item thisItem
    {
        get { return _thisItem; }
        set { _thisItem = value; }
    }

    public List<Ability> attackBook = new List<Ability>();
    public List<Spells> spellBook = new List<Spells>();
    List<Item> inventory = new List<Item>();

    List<Item> chestInventory1 = new List<Item>();
	List<Room> haveBeen = new List<Room> ();
	List<Room> forBack = new List<Room> ();

    //this is neccessary because player has to have a chest initialized inorder for inspect to work
    private Chest _thisChest = null;
    public Chest thisChest
    {
        get { return _thisChest; }
        set { _thisChest = value; }
    }
    private NPC _thisNpc = null;
    public NPC thisNpc
    {
        get { return _thisNpc; }
        set { _thisNpc = value; }
    }

    private Room _currentRoom = null;
    public Room currentRoom
    {
        get
        {
            return _currentRoom;
        }
        set
        {
            _currentRoom = value;
        }
    }
    private GameOutput _io = null;



    public Player(Room room, GameOutput output)
    {
        _currentRoom = room;
        _io = output;

    }

    public CharacterClass setCurrentClass
    {
        set { _currentClass = value; }
        get { return _currentClass; }

    }


    public void itemOutputMessage(Item item)
    {
        string message;
        if (item.quality == "Epic")
        {
            message = string.Format("<color=purple>{0}</color>", item.itemName);
            _io.sendLine(message);

        }
        else if (item.quality == "Rare")
        {
            message = string.Format("<color=blue>{0}</color>", item.itemName);
            _io.sendLine(message);

        }
        else if (item.quality == "Common")
        {
            message = string.Format("<color=green>{0}</color>", item.itemName);
            _io.sendLine(message);

        }
        else
        {
            message = item.itemName;
            _io.sendLine(message);
        }




    }

    public void outputMessage(string message)
	{
        _io.sendLine(message);
    }

    public void levelUp()
    {
        if (setCurrentClass.currentXP >= setCurrentClass.currentLevel * 100)
        {
            setCurrentClass.currentLevel += 1;
            setCurrentClass.currentXP = 0;
            setCurrentClass.defenseRating += 3;
            setCurrentClass.maxHitPoints += 15;
            setCurrentClass.attackDamage += 5;
            setCurrentClass.magicDamage += 5;
            setCurrentClass.gold += 22;

            outputMessage("\nWoah You leveled up!!! you can use 'show stats' to see your new stats ");
        }


    }

    public string txtReader(string filepath)
    {
        StreamReader reader = new StreamReader(filepath);
        outputMessage("\n" + reader.ReadToEnd());
        reader.Close();

        return " ";


    }



    #region COMMANDS FOR PLAYER


    public void SaveGame()
    {
        GameInformation.playerName = playerName;
        GameInformation.defenseRating = setCurrentClass.defenseRating;
        GameInformation.maxHitPoints = setCurrentClass.maxHitPoints;
        GameInformation.attackDamage = setCurrentClass.attackDamage;
        GameInformation.magicDamage = setCurrentClass.magicDamage;
        GameInformation.currentHitPoints = setCurrentClass.currentHitPoints;
        GameInformation.currentLevel = setCurrentClass.currentLevel;
        GameInformation.currentXP = setCurrentClass.currentXP;

        Debug.Log("name: " + playerName);
        Debug.Log("Defense: " + setCurrentClass.defenseRating);
        Debug.Log("max hp: " + setCurrentClass.maxHitPoints);
        Debug.Log("Attack damage: " + setCurrentClass.attackDamage);
        Debug.Log("Magic Damage: " + setCurrentClass.magicDamage);
        Debug.Log("Current hp: " + setCurrentClass.currentHitPoints);
        Debug.Log("Current Level: " + setCurrentClass.currentLevel);
        Debug.Log("Current Xp: " + setCurrentClass.currentXP);
        outputMessage("\nSave Successful");

    }


    public void LoadGame()
    {
        LoadInformation.LoadAllInformation();

        Debug.Log("name: " + playerName);
        Debug.Log("Defense: " + setCurrentClass.defenseRating);
        Debug.Log("max hp: " + setCurrentClass.maxHitPoints);
        Debug.Log("Attack damage: " + setCurrentClass.attackDamage);
        Debug.Log("Magic Damage: " + setCurrentClass.magicDamage);
        Debug.Log("Current hp: " + setCurrentClass.currentHitPoints);
        Debug.Log("Current Level: " + setCurrentClass.currentLevel);
        Debug.Log("Current Xp: " + setCurrentClass.currentXP);
        outputMessage("\nLoad Successful");

    }

	public void quit(){
		game.end();
	}


		
	public void fastTravel(string room){
		for (int i = 0; i < haveBeen.Count; i++) {
			Room room1 = haveBeen [i];
			string elName = room1.nameOf;
			if (room == elName) {
				_io.clear();
				currentRoom = room1;
				this.outputMessage (txtReader (currentRoom.tag) + "\n" + this._currentRoom.description ());
				thisNpc = null;
			}
		}
	}

	

    public void NewGame()
    {
        _io.clear();
        this.outputMessage(WelcomeState.Instance.enterState(this.game));
        Command[] welcomeCommands = { new HelpCommand(), new QuitCommand(), new NextCommand(), };

        if (game == null)
        {
            game = new Game(gameIO);

        }

        game.Parser(welcomeCommands);

    }

    //inspect method to inspect the chest and grab its description
    //would like to make it so you can inspect anything, hence why i have 'item' as the parameter
    public void interact(string someThing)
    {
        NPC theNpc = this._currentRoom.getNpc(someThing);

        if (theNpc != null)
        {
            if (theNpc.IsMerchant)
            {
                this._thisNpc = theNpc;
				this.outputMessage ("\n" + this.thisNpc.description () + "\n" + this._thisNpc.getItems());
                Debug.Log("Why");
            }

            else if (theNpc.WillAttack)
            {
                Debug.Log("Why");
                this.outputMessage(BattleState.Instance.enterState(this.game));
                Command[] battleCommands = { new HelpCommand(), new QuitCommand(), new AttackCommand(), new CastCommand(), new ShowCommand() };

                if (game == null)
                {
                    game = new Game(gameIO);

                }
                game.Parser(battleCommands);
                this._thisNpc = theNpc;
                //theNpc.dealDamage (setCurrentClass);

            }
            //theNpc.dealDamage (setCurrentClass);
        }

        if (theNpc == null)
        {
            this.outputMessage("\n There is no " + someThing + " to interact with.\n");
        }

    }

    public bool playerHasAttacked = false;// making sure player hits before NPC (player gets the first turn)

    public void attack(string attackType)//attacking function that gets called by the attack command
    {
        if (attackType.Equals(attackBook[0].AbilityName))
        {
            _thisNpc.npcHitPoints -= this.attackSystem(attackBook[0].AbilityDamage) + attackBook[0].AbilityDamage;
        }

        else if (attackType.Equals(attackBook[1].AbilityName))
        {
            _thisNpc.npcHitPoints -= this.attackSystem(attackBook[1].AbilityDamage) + attackBook[1].AbilityDamage;
        }


    }

    // this function handles player and NPC attacks and switches to the game over state if the character dies
    public int attackSystem(int dmg)
    {
        if (_thisNpc != null)
        {
            if (this.setCurrentClass.attackDamage < _thisNpc.npcDefense || this.setCurrentClass.attackDamage > _thisNpc.npcDefense)
            {
                _thisNpc.npcHitPoints -= this.setCurrentClass.attackDamage + dmg;
                this.outputMessage("\n You hit " + _thisNpc.name + " for " + (setCurrentClass.attackDamage + dmg) + " damage");
                this.outputMessage("\n" + _thisNpc.name + " health: " + _thisNpc.npcHitPoints.ToString());
                playerHasAttacked = true;
                if (_thisNpc.npcHitPoints <= 0)
                {
                    this.outputMessage("\n" + _thisNpc.name + " is now dead");
                    _thisNpc.isAlive = false;

					this.outputMessage(PlayingState.Instance.enterState(this.game));
					Command[] playingCommands = { new HelpCommand(), new QuitCommand(), new GoCommand(), new OpenCommand(), new InteractCommand(), new BuyCommand(),
						new UseCommand(), new ShowCommand(), new InspectCommand(), new EquipCommand(), new FastTravelCommand (), new BackCommand() };

					game.Parser (playingCommands);
					this.outputMessage("\n");
					setCurrentClass.currentXP += 100;
					outputMessage("\nYou gained 100 experience points for killing this monster.");
					levelUp();
					this.outputMessage("\n");

                    if(thisNpc.name == "Mad King")
                    {
                        outputMessage(GameOverState.Instance.enterState(this.game));
                    }


                }


            }
            if (playerHasAttacked == true)
            {
                if (_thisNpc.npcHitPoints > 0)
                {
                    _thisNpc.dealDamage(setCurrentClass);
                    this.outputMessage("\n" + _thisNpc.name + " hits back for " + _thisNpc.npcAttackDamage + " damage");
                    if (this.setCurrentClass.currentHitPoints <= 0)
                    {
                        //switching to the gameOver state 
                        this.outputMessage(GameOverState.Instance.enterState(this.game));
						Command[] GameOverCommands = {  };

						game.Parser (GameOverCommands);

						this.outputMessage(MainMenuState.Instance.enterState(this.game));
                    }
                }
                playerHasAttacked = false;
            }

        }
        return this.setCurrentClass.attackDamage;
    }

    public void cast(string spellName)//cast spell
    {
        string castIgni = spellBook[0].spellName;
        if (spellName.Equals(castIgni))
        {
            _thisNpc.npcHitPoints -= this.attackSystem(spellBook[0].spellDamage) + spellBook[0].spellDamage;
        }
        string castQuen = spellBook[1].spellName;
        if (spellName.Equals(castQuen))
        {
            _thisNpc.npcHitPoints -= this.attackSystem(spellBook[1].spellDamage) + spellBook[1].spellDamage;
        	
		}
    }

    //inspect method to inspect the chest and grab its description
    //would like to make it so you can inspect anything, hence why i have 'item' as the parameter
    public void inspectThis(string item)
    {
        Chest theChest = this._currentRoom.getChest(item);
        if (theChest != null)
        {
            this._thisChest = theChest;
            this.outputMessage("\n" + this.thisChest.description() + "\n");
        }
        else
        {
            this.outputMessage("\n There is no chest.\n");
        }
    }




    public void back()
    {
        if (forBack.Count > 0)
        {
            currentRoom = forBack[forBack.Count - 1];
            forBack.Remove(forBack[forBack.Count - 1]);
            _io.clear();
            this.outputMessage(txtReader(currentRoom.tag) + "\n" + this._currentRoom.description());
            thisNpc = null;
        }
        else
        {
            this.outputMessage("\n\nNO WHERE TO GO BACK TO!");
        }
    }
   

    public void battle(string next)
    {
        _io.clear();
        this.outputMessage(BattleState.Instance.enterState(game));

        Command[] battleCommands = { new HelpCommand(), new QuitCommand(), };
        if (game == null)
        {
            game = new Game(gameIO);

        }
        game.Parser(battleCommands);

    }
    public void buy(string itemName)
    {
        if (thisNpc != null)
        {
            Item item = thisNpc.pickup(itemName);
            if (item == null)
            {
                this.outputMessage("\nI am sorry, I do not have any " + itemName + "'s\n" + thisNpc.getItems());
            }
            else if (setCurrentClass.gold >= item.itemCost)
            {
                this.outputMessage("\nThank you for buying " + item.nameOf() + "!");
                this.give(item);
                setCurrentClass.gold -= item.itemCost;
                outputMessage(inspectCharacter());
            }
            else if (setCurrentClass.gold < item.itemCost)
            {
                this.outputMessage("\nYou cannot afford the item " + itemName);
            }
        }
        else
        {
            this.outputMessage("\nYou have not interacted with anyone to buy from.");
        }
    }


    public void equip(string item1)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = inventory[i];
            string elName = item.nameOf();
            if (elName == item1)
            {
                switch (item.armorType)
                {
                    case "chest piece":
                        if (chestPiece != null)
                        {
                            inventory.Add(chestPiece);
                            _currentClass.defenseRating -= chestPiece.itemDefenseRating;
                            inventory.Remove(item);
                            chestPiece = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + chestPiece.itemDefenseRating + " Defense Rating!!");

                            _currentClass.defenseRating += chestPiece.itemDefenseRating;
                            break;
                        }
                        else
                        {
                            chestPiece = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + chestPiece.itemDefenseRating + " Defense Rating!!");
                            _currentClass.defenseRating += chestPiece.itemDefenseRating;
                            inventory.Remove(item);
                            break;
                        }
                    case "shield":
                        if (shield != null)
                        {
                            inventory.Add(shield);
                            _currentClass.defenseRating -= shield.itemDefenseRating;
                            inventory.Remove(item);
                            shield = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + shield.itemDefenseRating + " Defense Rating!!");

                            _currentClass.defenseRating += shield.itemDefenseRating;
                            break;
                        }
                        else
                        {
                            shield = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + shield.itemDefenseRating + " Defense Rating!!");
                            _currentClass.defenseRating += shield.itemDefenseRating;
                            inventory.Remove(item);
                            break;
                        }
                    case "helmet":
                        if (helmet != null)
                        {
                            inventory.Add(helmet);
                            _currentClass.defenseRating -= helmet.itemDefenseRating;
                            inventory.Remove(item);
                            helmet = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + helmet.itemDefenseRating + " Defense Rating!!");

                            _currentClass.defenseRating += helmet.itemDefenseRating;
                            break;
                        }
                        else
                        {
                            helmet = (Armor)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Armor)item);
                            outputMessage(" and gained +" + helmet.itemDefenseRating + " Defense Rating!!");
                            _currentClass.defenseRating += helmet.itemDefenseRating;
                            inventory.Remove(item);
                            break;
                        }

                    case "weapon":
                        if (primaryWeapon != null)
                        {
                            inventory.Add(primaryWeapon);
                            _currentClass.attackDamage -= primaryWeapon.itemDamage;
                            inventory.Remove(item);
                            primaryWeapon = (Weapon)item;

                            _currentClass.attackDamage += primaryWeapon.itemDamage;
                        }
                        else
                        {
						if (equipedweapon)
						{
							UnlockAchievement("equip a weapon");
							outputMessage(achievementManager.unlockAchievementMessage("equip a weapon"));
							equipedweapon = false;
							this.outputMessage("\n");
							setCurrentClass.currentXP += 100;
							outputMessage("\nYou gained 100 experience points for completing this ahievement.");
							levelUp();
							this.outputMessage("\n");

						}
                            primaryWeapon = (Weapon)item;
                            outputMessage("\nYou equipped: ");
                            itemOutputMessage((Weapon)item);
                            outputMessage(" and gained +" + primaryWeapon.itemDamage + " Attack Damage!!");
                            _currentClass.attackDamage += primaryWeapon.itemDamage;
                            inventory.Remove(item);
                           
                        }

                        break;
                }

            }
        }

    }

    public void give(Item item)
    {
        inventory.Add(item);
    }

    public string inspectCharacter()
    {
        string CharacterStats = "Stats: \n";
        CharacterStats += " Level:  " + setCurrentClass.currentLevel + "\n";
        CharacterStats += " HP:  " + setCurrentClass.currentHitPoints + "\n";
        CharacterStats += " Attack Damage:  " + setCurrentClass.attackDamage + "\n";
        CharacterStats += " Defense Rating:  " + setCurrentClass.defenseRating + "\n";
        CharacterStats += " Magic Damage:  " + setCurrentClass.magicDamage + "\n";
        CharacterStats += " Gold:  " + setCurrentClass.gold + "\n";
        CharacterStats += " Weight:  " + (_charWeightCarried) + " lbs\n";
        return CharacterStats;
    }


    public void next()
    {
        _io.clear();
        this.outputMessage(ClassSelectState.Instance.enterState(game));
        this.outputMessage(mage.description());
        this.outputMessage(witcher.description());
        this.outputMessage(pally.description());
        Command[] classSelectCommands = { new HelpCommand(), new QuitCommand(), new SelectCommand(), };
        if (game == null)
        {
            game = new Game(gameIO);

        }

        game.Parser(classSelectCommands);


    }
    public void open(string chest)
    {
        Chest theChest = this._currentRoom.getChest(chest);

        if (theChest == null)
        {
            this.thisChest = new Chest();
        }

        if (theChest != null)
        {
            this._thisChest = theChest;
            chestInventory1 = this._thisChest.getChestItems();

            foreach (Item item in chestInventory1)
            {
                if (item != null)
                {
                    Debug.Log(item.itemName);
                    this._thisItem = this._thisChest.removeItem(item.nameOf());
                    inventory.Add(_thisItem);
                    charWeightCarried += _thisItem.weight;
                    outputMessage("\n ");
                    itemOutputMessage(_thisItem);
                    //this.outputMessage("\nYou get a " + this.thisItem.nameOf() + "!");
                }
                else
                {
                    this.outputMessage("\nThere are no items!!!! BAHAHAHA");
                }
            }
            if (openedchest)
            {
                UnlockAchievement("open a chest");
                outputMessage(achievementManager.unlockAchievementMessage("open a chest"));
                openedchest = false;
                this.outputMessage("\n");
                setCurrentClass.currentXP += 100;
                outputMessage("\nYou gained 100 experience points for completing this ahievement.");
                levelUp();
                this.outputMessage("\n");
            }
            setCurrentClass.currentXP += 100;
            outputMessage("\nYou gained 100 experience points for opening this chest!");
            levelUp();
        }
        else
        {
            this.outputMessage("\nThere is no chest.\n");
        }
    }
    public void select(string charClass)
    {
        switch (charClass)
        {
            case "witcher":
                setCurrentClass = witcher;
                var witchersword = new Weapon("Witcher Sword", "weapon");
                inventory.Add(witchersword);
                Ability lightStrike = new Ability("light strike", 2, "melee");
                Ability heavySlash = new Ability("heavy lash", 4, "melee");
                attackBook.Add(lightStrike);
                attackBook.Add(heavySlash);
                _io.clear();

                itemOutputMessage(inventory[0]);

                this.outputMessage(" was added to your inventory!!!\n");
                //outputMessage("You are currently carrying " + _charWeightCarried + " lbs. You only are only strong enough to carry " +
                //             (50 - _charWeightCarried) + " lbs.\n");
                this.outputMessage("\nYou picked a witcher, and have been transported through time and space \n ");
                this.outputMessage("\nYour abilities are:  \n" + this.attackBook[0].AbilityName + " and it has a base damage of " + this.attackBook[0].AbilityDamage
                    + "\n" + this.attackBook[1].AbilityName + " and it has a base damage of " + this.attackBook[1].AbilityDamage + "\n");
                this.outputMessage(PlayingState.Instance.enterState(this.game) + txtReader(currentRoom.tag) + currentRoom.description());
                break;

            case "mage":
                this.setCurrentClass = mage;
                // Weapon mageStaff = new Weapon("A wizard's staff, good for magic but not much of a melee weapon.", "Wizard's Staff", 2, 5);
                Weapon mageStaff = new Weapon("Mage Staff", "weapon");
                this.inventory.Add(mageStaff);
                Spells fire = new Spells("fire ball", 5, "magic");
                Spells frost = new Spells("frost bolt", 4, "magic");
                spellBook.Add(fire);
                spellBook.Add(frost);
                _io.clear();
                itemOutputMessage(inventory[0]);
                this.outputMessage(" was added to your inventory!!!\n");
                //outputMessage("You are currently carrying " + _charWeightCarried + " lbs. You only are only strong enough to carry " +
                //            (50 - _charWeightCarried) + " lbs.\n");
                this.outputMessage("\nYou picked a mage, and have been transported through time and space \n ");
                this.outputMessage("\nYour abilities are:  \n" + this.spellBook[0].spellName + " and it has a base damage of " + this.spellBook[0].spellDamage
                    + "\n" + this.spellBook[1].spellName + " and it has a base damage of " + this.spellBook[1].spellDamage + "\n");
                this.outputMessage(PlayingState.Instance.enterState(this.game) + txtReader(currentRoom.tag) + currentRoom.description());
                break;

            case "paladin":
                this.outputMessage("\nYou picked a holy knight, and have been transported through \ntime and space \n ");
                setCurrentClass = pally;
                // Weapon warhammer = new Weapon("A Holy Warhammer infused with the power of the gods through meditation.", "Holy Warhammer", 7, 15);
                Weapon warhammer = new Weapon("War Hammer", "weapon");

                inventory.Add(warhammer);

                Spells iceLance = new Spells("ice lance", 5, "magic");
                Spells storm = new Spells("ligthning storm", 4, "magic");
                spellBook.Add(iceLance);
                spellBook.Add(storm);

                _io.clear();
                itemOutputMessage(inventory[0]);
                this.outputMessage(" was added to your inventory!!!\n");
                //outputMessage("You are currently carrying " + _charWeightCarried + " lbs. You only are only strong enough to carry " +
                //(50 - _charWeightCarried) + " lbs.\n");
                this.outputMessage("\nYou picked a paladin, and have been transported through time and space \n ");
                this.outputMessage("\nYour abilities are:  \n" + this.spellBook[0].spellName + " and it has a base damage of " + this.spellBook[0].spellDamage
                    + "\n" + this.spellBook[1].spellName + " and it has a base damage of " + this.spellBook[1].spellDamage + "\n");
                this.outputMessage(PlayingState.Instance.enterState(this.game) + txtReader(currentRoom.tag) + currentRoom.description());
                break;

            default:
                this.outputMessage(charClass + " is not a valid class");
                break;
        }


        Command[] playingCommands = { new HelpCommand(), new QuitCommand(), new GoCommand(), new OpenCommand(), new InteractCommand(), new BuyCommand(),
            new UseCommand(), new ShowCommand(), new InspectCommand(), new EquipCommand(), new FastTravelCommand (), new BackCommand() };
        if (game == null)
        {
            game = new Game(gameIO);

        }

        game.Parser(playingCommands);

    }

    public void setDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                this.outputMessage("\nDifficulty set to easy.");
                break;
            case "hard":
                this.outputMessage("\nDifficulty set to hard.");
                break;
            default:
                this.outputMessage("\n" + difficulty + "is not valid difficulty.");
                break;
        }
    }

    public void Show(string what)
    {
        switch (what)
        {
            case "inventory":
                showInventory();
                break;
            case "achievements":
                this.outputMessage("\n" + achievementManager.getAchievements() + "\n");
                break;
            case "stats":
                this.outputMessage("\n\n" + inspectCharacter());
                break;
            case "armor":
                this.outputMessage("\n\n" + showArmor());
                break;
        }
    }



    public void showInventory()
    {
        outputMessage("\nYour Inventory: ");
        foreach (Item item in inventory)
        {
            itemOutputMessage(item);
            outputMessage(" | ");

        }

    }
    public string showArmor()
    {
        string playerHands = "Your Armor:";
        if (primaryWeapon != null)
        {
            playerHands += " " + primaryWeapon.nameOf();
        }
        if (helmet != null)
        {
            playerHands += " | " + helmet.nameOf();
        }
        if (shield != null)
        {
            playerHands += " | " + shield.nameOf();
        }
        if (chestPiece != null)
        {
            playerHands += " | " + chestPiece.nameOf();
        }
        return playerHands;
    }

    public void walkTo(string direction)
    {
        Room nextRoom = this._currentRoom.getExit(direction);
        if (nextRoom != null)
        {
            haveBeen.Add(currentRoom);
            forBack.Add(currentRoom);
            _io.clear();
            this._currentRoom = nextRoom;
            this.outputMessage(txtReader(currentRoom.tag) + "\n" + this._currentRoom.description());
            thisNpc = null;
        }
        else
        {
            this.outputMessage("\nThere is no door on " + direction);
        }
    }
    public void use(string item1)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = inventory[i];
            string elName = item.nameOf();
            if (elName == item1)
            {
                switch (item.itemTag)
                {
                    case "health potion":
                        setCurrentClass.currentHitPoints += item.healing;
                        inventory.Remove(item);
                        this.outputMessage("\n" + inspectCharacter() + "\n");
                        if (usedpotion)
                        {
                            UnlockAchievement("drink a potion");
                            outputMessage(achievementManager.unlockAchievementMessage("drink a potion"));
                            equipedweapon = false;
                            this.outputMessage("\n");
							setCurrentClass.currentXP += 100;
							outputMessage("\nYou gained 100 experience points for completing this ahievement.");
							levelUp();
							this.outputMessage("\n");
                        }
                        break;
                    default:
                        this.outputMessage("\n" + item1 + " is not useable item.");
                        break;
                }
            }
        }

    }

    #endregion



}
