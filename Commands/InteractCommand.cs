using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCommand : Command {

	public InteractCommand() : base()
	{
		this.name = "interact";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord())
		{
			player.interact(this.secondWord);
		}
		else
		{
			player.outputMessage("\nInteract <b>What</b>?");
		}
		return false;
	}
}
