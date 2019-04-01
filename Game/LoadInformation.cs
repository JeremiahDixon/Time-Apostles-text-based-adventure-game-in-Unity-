using UnityEngine;

public class LoadInformation
{
    public static void LoadAllInformation()
    {
        GameInformation.playerName = PlayerPrefs.GetString("PLAYERNAME");

        GameInformation.defenseRating = PlayerPrefs.GetInt("PLAYERDEFENSE");
        GameInformation.maxHitPoints = PlayerPrefs.GetInt("PLAYERMAXHP");
        GameInformation.attackDamage = PlayerPrefs.GetInt("PLAYERATTACKDAMAGE");
        GameInformation.magicDamage = PlayerPrefs.GetInt("PLAYERMAGICDAMAGE");
        GameInformation.gold = PlayerPrefs.GetInt("PLAYERGOLD");
        GameInformation.currentHitPoints = PlayerPrefs.GetInt("PLAYERCURRENTHP");
        GameInformation.currentLevel = PlayerPrefs.GetInt("PLAYERCURRENTLEVEL");
        GameInformation.currentXP = PlayerPrefs.GetInt("PLAYERCURRENTXP");

       



    }




}


