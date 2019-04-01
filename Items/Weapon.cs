using UnityEngine;

public class Weapon : Item
{
    private int _itemDamage;
    private int _itemDurability = 100;

    public int itemDamage
    {
        get { return _itemDamage; }
        set { _itemDamage = value; }
    }

    public int ItemDurability
    {
        get
        {
            return _itemDurability;
        }

        set
        {
            _itemDurability = value;
        }
    }

    public Weapon() : this("no name", "No Tag")
    {

    }

    public Weapon(string name, string tag)
    {
        this.itemName = name;
        this.armorType = tag;
        this.itemDamage = Random.Range(10, 22);
        this.quality = Quality();
        this.weight = Random.Range(3, 5);

    }


    public string Quality()
    {
        var intQuality = Random.Range(0, 99);
        if (intQuality <= 5)
        {
            this.quality = "Epic";
            itemDamage += 6;
            itemCost += 10;
            //itemName = string.Format("<color=purple>{0}</color>", itemName);
            itemName = string.Format(itemName);
            itemDescription = string.Format("<color=purple>{0}</color>", itemDescription);
        }
        else if (intQuality > 5 && intQuality <= 29)
        {
            this.quality = "Rare";
            itemDamage += 3;
            itemCost += 7;
            // itemName = string.Format("<color=blue>{0}</color>", itemName);
            itemName = string.Format(itemName);
            itemDescription = string.Format("<color=blue>{0}</color>", itemDescription);
        }
        else if (intQuality > 29 && intQuality <= 79)
        {
            this.quality = "Common";
            itemDamage += 1;
            itemCost += 4;
            // itemName = string.Format("<color=green>{0}</color>", itemName);
            itemName = string.Format(itemName);
            itemDescription = string.Format("<color=green>{0}</color>", itemDescription);

        }
        else
        {
            this.quality = "Uncommon";
            this.itemCost = 3;
        }
        return quality;
    }
    public string description()
    {
        return "\n\nName: " + this.itemName +
               "\nDamage:  +" + this._itemDamage +
               "\nCost: " + this.itemCost +
               "\nQuality: " + this.quality +
               "\nWeight: " + this.weight;
    }

}
