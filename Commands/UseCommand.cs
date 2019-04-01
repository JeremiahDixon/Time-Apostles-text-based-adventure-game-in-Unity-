using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCommand : Command
{

    public UseCommand() : base()
    {
        this.name = "use";
    }

    override
    public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            player.use(this.secondWord);
        }
        else
        {
            player.outputMessage("\nUse <b>What</b>?");
        }
        return false;
    }
}
