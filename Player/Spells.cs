using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells  {

	public Player player;
	public CharacterClass characterClass;


	private string _spellName;
	private int _spellDamage;
	private string _spellType;

	public string spellName
	{
		get { return _spellName; }
		set { _spellName = value; }
	}

	public int spellDamage
	{
		get { return _spellDamage; }
		set { _spellDamage = value; }
	}

	public string spellType
	{
		get { return _spellType; }
		set { _spellType = value; }
	}


	public Spells() : this("No Name", 0, "no type")
	{

	}

	public Spells(string spell, int spellDamage, string spellType)
	{

		this.spellName = spell;
		this.spellDamage = spellDamage;
		this.spellType = spellType;
	}
	public string description()
	{
		return "\nYour abilities are:  \n" + player.spellBook[0].spellName + " and it has a base damage of " + player.spellBook[0].spellDamage
			+ "\n" + player.spellBook[1].spellName + " and it has a base damage of " + player.spellBook[1].spellDamage + "\n";
	}


}
