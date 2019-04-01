using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectCommand : Command
{

    public InspectCommand() : base()
    {
        this.name = "inspect";
    }

    override
    public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            if (this.secondWord == "self")
            {
                Debug.Log("we got passed the self string check");
                player.inspectCharacter();


            }
            else
            {
                player.outputMessage("\nI cannot inspect such a thing called <b>" + this.secondWord + "</b>");

            }

        }
        return false;

    }
}

