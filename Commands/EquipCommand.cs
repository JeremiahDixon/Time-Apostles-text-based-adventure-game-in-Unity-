using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCommand : Command {

	public EquipCommand() : base()
	{
		this.name = "equip";
	}

	override
	public bool execute(Player player)
	{
		if (this.hasSecondWord())
		{
			player.equip(this.secondWord);
		}
		else
		{
			player.outputMessage("\nEquip <b>What</b>?");
		}
		return false;
	}
}
