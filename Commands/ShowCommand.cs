using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCommand : Command {

	public ShowCommand() : base()
	{
		this.name = "show";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord())
		{
			player.Show(this.secondWord);
		}
		else
		{
			player.outputMessage("\nShow <b>What</b>?");
		}
		return false;
	}
}
