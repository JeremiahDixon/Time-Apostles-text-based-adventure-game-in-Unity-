using System.Collections.Generic;


public class Chest
{
    private Dictionary<string, Item> items;
    private string _chestName;
    public string chestName
    {
        get { return _chestName; }
        set { _chestName = value; }
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

    public Chest() : this("No Tag")
    {

    }

    public Chest(string tag)
    {
        
        items = new Dictionary<string, Item>();
        this.tag = tag;
    }

    public void setItem(string itemDescription, Item item)
    {
        items[itemDescription] = item;
    }

    public Item removeItem(string itemName)
    {
        Item item = items[itemName];
        items.Remove(itemName);
        return item;
    }

    public Item getItem(string itemDescription)
    {
        Item item = null;
        items.TryGetValue(itemDescription, out item);
        return item;
    }

    public string getItems()
    {
        string itemNames = "Items in chest: ";
        Dictionary<string, Item>.KeyCollection keys = items.Keys;
        foreach (string itemName in keys)
        {
            itemNames += " " + itemName;
        }

        return itemNames;
    }

    public List<Item> getChestItems()
    {
        List<Item> chestInventory = new List<Item>();
        Dictionary<string, Item>.KeyCollection keys = items.Keys;
        foreach (string itemDescription in keys)
        {
            chestInventory.Add(getItem(itemDescription));
        }
        return chestInventory;
    }

    public string description()
    {
        return this.tag;
    }

}
