using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCommand : Command {

	public BuyCommand() : base()
	{
		this.name = "buy";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord())
		{
			player.buy(this.secondWord);
		}
		else
		{
			player.outputMessage("\nBuy <b>What</b>?");
		}
		return false;
	}
}
