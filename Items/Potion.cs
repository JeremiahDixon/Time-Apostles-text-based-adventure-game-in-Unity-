using UnityEngine;

public class Potion : Item
{


    public Potion(string name, string tag)
    {
        var intQuality = Random.Range(0, 99);

        if (intQuality <= 49)
        {
            // this.itemName = string.Format("<color=green>{0}</color>", "Greater " + name);
            this.itemName = name;
            this.itemTag = tag;

            this.itemCost += 7;
            this.healing += Random.Range(10, 15);
            this.quality = "Common";
            this.weight = 1;

        }
        else
        {
            this.itemName = name;
            // this.tag = tag;
            this.quality = "Uncommon";
			this.itemCost = 3;
        }

    }
    public string description()
    {
        return "\n\nName: " + this.itemName +
                  "\nHealing:  +" + this.healing +
                  "\nCost: " + this.itemCost +
                  "\nQuality: " + this.quality;
    }



}
