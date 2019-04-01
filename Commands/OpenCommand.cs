using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCommand : Command {

	public OpenCommand() : base()
	{
		this.name = "open";
	}

	override
	public bool execute(Player player)
	{
        bool answer;
		if (this.hasSecondWord())
		{
			player.open(this.secondWord);
            return true;
		}
		else
		{
			player.outputMessage("\nopen <b>What</b>?");
		}
		return false;
	}
}
