/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCommand : Command
{

    public DropCommand() : base()
    {
        this.name = "drop";
    }

    override
    public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            player.drop(this.secondWord);
        }
        else
        {
            player.outputMessage("\nDrop <b>What</b>?");
        }
        return false;
    }
}*/
