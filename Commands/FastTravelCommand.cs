using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravelCommand : Command {

	public FastTravelCommand() : base()
	{
		this.name = "travel";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord())
		{
			player.fastTravel(this.secondWord);
		}
		else
		{
			player.outputMessage("\nTravel <b>Where</b>?");
		}
		return false;
	}
}
