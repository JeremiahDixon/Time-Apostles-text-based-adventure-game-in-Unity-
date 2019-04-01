using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCommand : Command {

	public BackCommand() : base()
	{
		this.name = "back";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord ()) {
			player.outputMessage ("\nI cannot back <b>" + this.secondWord + "</b>");
		} else {
			player.back ();
		}
		return false;
	}
}
