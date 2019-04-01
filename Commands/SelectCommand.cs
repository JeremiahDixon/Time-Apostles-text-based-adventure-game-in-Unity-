using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCommand : Command
{

    public SelectCommand() : base()
    {
        this.name = "select";
    }

    override
    public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            player.select(this.secondWord);
        }
        else
        {
            player.outputMessage("\nSelect <b>Which class?</b>?");
        }
        return false;
    }

}
