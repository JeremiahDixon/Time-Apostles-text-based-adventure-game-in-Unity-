/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCommand : Command 
{
    public PickupCommand() : base()
    {
        this.name = "pickup";
    }

    override
    public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            player.pickup(this.secondWord);
        }
        else
        {
            player.outputMessage("\nPickup <b>What</b>?");
        }
        return false;
    }

}*/
