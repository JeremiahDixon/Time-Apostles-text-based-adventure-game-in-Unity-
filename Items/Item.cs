using UnityEngine;

public class Item
{
    public Color Color;
    public Random random;

    private string _itemName;
    private string _itemDescription;
    private int _itemCost;
    private string _quality;
    private string _itemTag;
    private int _weight;
    private string _armorType;
    private int _healing;


    public string itemName { get { return _itemName; } set { _itemName = value; } }
    public string itemDescription { get { return _itemDescription; } set { _itemDescription = value; } }
    public int itemCost { get { return _itemCost; } set { _itemCost = value; } }
    public string quality { get { return _quality; } set { _quality = value; } }
    public string itemTag { get { return _itemTag; } set { _itemTag = value; } }
    public int weight { get { return _weight; } set { _weight = value; } }
    public string armorType { get { return _armorType; } set { _armorType = value; } }
    public int healing { get { return _healing; } set { _healing = value; } }


    public Item() : this("no name ", "no tag")
    {

    }

    public Item(string name, string tag)

    {
        this.itemName = name;
        this.itemTag = tag;

    }
    public string nameOf()
    {
        return this.itemName;
    }

    public int costOf()
    {
        return this.itemCost;
    }




    public string description()
    {
        return "\n\nName: " + this.itemName +




                  "\nCost: " + this.itemCost + " Gold" +
                                  "\nQuality: " + this.quality + "\nWeight: " + this.weight;
    }
}




