using UnityEngine;

public class Armor : Item
{
    private int _itemDefenseRating;
    private int _itemDurability = 100;

    public int itemDefenseRating
    {
        get { return _itemDefenseRating; }
        set { _itemDefenseRating = value; }
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


    public Armor() : this("No Tag", "none")
    {

    }

    public Armor(string name, string armorTp)
    {
        this.itemName = name;

        this.itemDefenseRating = Random.Range(10, 20);
        //this.armorType = ArmorType();
        this.quality = Quality();
        this.weight = Random.Range(3, 5);
        this.armorType = armorTp;

    }
    public string Quality()
    {
        var intQuality = Random.Range(0, 99);
        if (intQuality <= 5)
        {
            this.quality = "Epic";
            itemDefenseRating += 6;
            itemCost += 10;

            //itemName = "Greatest " + armorType + itemName;
            //itemName = string.Format("<color=purple>{0}</color>", "Greatest " + armorType + itemName);
            // itemDescription = string.Format("<color=purple>{0}</color>", itemDescription);
        }
        else if (intQuality > 5 && intQuality <= 29)
        {
            this.quality = "Rare";
            itemDefenseRating += 3;
            itemCost += 7;
            //itemName = itemName = "Greater " + armorType + itemName;
            //itemName = string.Format("<color=blue>{0}</color>", "Greater " + armorType + itemName);
            //itemDescription = string.Format("<color=blue>{0}</color>", itemDescription);
        }
        else if (intQuality > 29 && intQuality <= 79)
        {
            this.quality = "Common";
            itemDefenseRating += 1;
            itemCost += 4;
            // itemName = itemName = "Great " + armorType + itemName;
            //itemName = string.Format("<color=green>{0}</color>", "Great " + armorType + itemName);
            //itemDescription = string.Format("<color=green>{0}</color>", itemDescription);

        }
        else
        {
            this.quality = "Uncommon";
            itemName = armorType + itemName;
            this.itemCost = 3;
        }
        return quality;
    }

    public string ArmorType()
    {
        var intArmorType = Random.Range(0, 2);
        if (intArmorType == 0)
        {
            this.armorType = "Chestpiece";
            this.ItemDurability = 100;
            this.itemDefenseRating += 5;

        }
        else if (intArmorType == 1)
        {
            this.armorType = "Helmet";
            this.ItemDurability = 100;
            this.itemDefenseRating += 3;
        }
        else
        {
            this.armorType = "Shield";
            this.ItemDurability = 100;
            this.itemDefenseRating += 6;

        }


        return armorType;


    }

    public string description()
    {
        return "\n\nName: " + this.itemName +

               "\nDefense:  +" + this.itemDefenseRating +
               "\nCost: " + this.itemCost +
               "\nQuality: " + this.quality
                                  +
                                  "\nWeight: " + this.weight;






    }

}
