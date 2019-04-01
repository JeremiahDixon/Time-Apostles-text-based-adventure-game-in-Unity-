using System;
using System.Collections.Generic;

public class NPC
{
    public Player player;
    public Ability ability;
    public Game game;

    public Random rnd = new Random();

    private Dictionary<string, Item> items;
    List<Item> npcInventory = new List<Item>();

    private bool _willAttack;

    public bool WillAttack
    {
        get { return _willAttack; }
        set { _willAttack = value; }

    }
    private bool _isMerchant;

    public bool IsMerchant
    {
        get { return _isMerchant; }
        set { _isMerchant = value; }

    }


    private int _npcHitPoints;

    public int npcHitPoints
    {
        get { return _npcHitPoints; }
        set { _npcHitPoints = value; }
    }

    private int _npcAttackDamage;
    public int npcAttackDamage
    {
        get { return _npcAttackDamage; }
        set { _npcAttackDamage = value; }
    }

    private int _npcDefense;

    public int npcDefense
    {
        get { return _npcDefense; }
        set { _npcDefense = value; }

    }

    private string _name;
    public string name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

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

    private bool _isAlive = true;
    public bool isAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
        }
    }


    public NPC() : this("No Name", "No Tag", 0, 0, 0, false, true)
    {

    }

    public NPC(string name, string tag, int hp, int aD, int def, bool attack, bool merchant)
    {
        items = new Dictionary<string, Item>();
        npcInventory = new List<Item>();
        this.name = name;
        this.tag = tag;
        this.npcHitPoints = hp;
        this.npcAttackDamage = aD;
        this.npcDefense = def;
        this._willAttack = attack;
        this._isMerchant = merchant;
    }

    public void isNPCAlive()
    {
        if (this.npcHitPoints <= 0)
        {
            _isAlive = !_isAlive;
        }

    }

    public void setItem(string itemName, Item item)
    {
        items[itemName] = item;
    }

    public Item getItem(string itemName)
    {
        Item item = null;
        items.TryGetValue(itemName, out item);
        return item;
    }

    public string getItems()
    {
        string itemNames = "Here are my wares!\n" + "---------------------------\n";
        Dictionary<string, Item>.KeyCollection keys = items.Keys;
        foreach (string itemName in keys)
        {
            itemNames += itemName + " | ";
        }

        return itemNames;
    }

    public List<Item> getNpcItems()
    {
        List<Item> npcInventory = new List<Item>();
        Dictionary<string, Item>.KeyCollection keys = items.Keys;
        foreach (string itemName in keys)
        {
            npcInventory.Add(getItem(itemName));
        }
        return npcInventory;
    }

    public Item pickup(string itemName)
    {
        npcInventory = getNpcItems();
        foreach (Item item in npcInventory)
        {
            string elName = item.nameOf();
            if (elName == itemName)
            {
                items.Remove(itemName);
                return item;
            }
        }
        return null;
    }
    public void dealDamage(CharacterClass character)
    {
        if (this.npcAttackDamage > character.defenseRating)
        {
            character.currentHitPoints -= this.npcAttackDamage;
        }

    }
   

    public string description()
    {
        return this.tag;
    }

}
