using System.Collections.Generic;

public class Room
{
    public Player player;
    private Dictionary<string, Room> exits;
    //dictionary for chests
    private Dictionary<string, Chest> chests;
    //dictionary for NPC's
    private Dictionary<string, NPC> npcs;
    private Dictionary<string, Item> items;




    private string _tag;
    public string tag
    {
        get
        {
            return _tag;
        }
        set
        {
            _tag = value;
        }
    }

	private string _nameOf;
	public string nameOf
	{
		get
		{
			return _nameOf;
		}
		set
		{
			_nameOf = value;
		}
	}

    public Room() : this("No Tag", "no name")
    {

    }

	public Room(string tag, string name)
    {
        exits = new Dictionary<string, Room>();
        chests = new Dictionary<string, Chest>();
        npcs = new Dictionary<string, NPC>();
        items = new Dictionary<string, Item>();
        this.tag = tag;
		this.nameOf = name;

    }
    public void setItem(string itemName, Item item)
    {
        items[itemName] = item;
    }


    public void setExit(string exitName, Room room)
    {
        exits[exitName] = room;
    }

    //this allows you to put chests in rooms
    public void setChest(string chestName, Chest chest)
    {
        chests[chestName] = chest;
    }

    public void setNpc(string NpcName, NPC npc)
    {
        npcs[NpcName] = npc;
    }

    public Room getExit(string exitName)
    {
        Room room = null;
        exits.TryGetValue(exitName, out room);
        return room;
    }

    //this is used in the inspect() method in player to get the chest you're wanting to inspect
    public Chest getChest(string chestName)
    {
        Chest chest = null;
        chests.TryGetValue(chestName, out chest);
        return chest;
    }

    //shows npc
    public NPC getNpc(string npcName)
    {
        NPC npc = null;
        npcs.TryGetValue(npcName, out npc);
        return npc;
    }

    public string getExits()
    {
        string exitNames = "Exits: ";
        Dictionary<string, Room>.KeyCollection keys = exits.Keys;
        foreach (string exitName in keys)
        {
            exitNames += " | " + exitName;
        }

        return exitNames;
    }

    //gets the chest names to display when entering a room
    public string getChests()
    {
        string chestNames = "Chests: ";
        Dictionary<string, Chest>.KeyCollection keys = chests.Keys;
        foreach (string chestName in keys)
        {
            chestNames += " | " + chestName;
        }
        return chestNames;
    }

    //gets the chest names to display when entering a room
    public string getNpcs()
    {
        string npcNames = "NPCS: ";
        Dictionary<string, NPC>.KeyCollection keys = npcs.Keys;
        foreach (string npcName in keys)
        {
            npcNames += " | " + npcName;
        }
        return npcNames;
    }
    public string getItems()
    {
        string itemNames = "Items: ";
        Dictionary<string, Item>.KeyCollection keys = items.Keys;
        foreach (string itemName in keys)
        {
            itemNames += " | " + itemName;
        }
        return itemNames;
    }


    public string description()
    {
        //added get chests because this is where you display chests and exits in the room

        return "\n\n *** " + this.getExits() + "\n *** " +
                                 this.getChests() + "\n *** " + this.getNpcs()  
                                 + "\n *** " + this.getItems();
    }





}
