using UnityEngine;

public class SaveInformation
{
    public static void SaveAllInformation()
    {
        PlayerPrefs.SetString("PLAYERNAME", GameInformation.playerName);

        PlayerPrefs.SetInt("PLAYERDEFENSE", GameInformation.defenseRating);
        PlayerPrefs.SetInt("PLAYERMAXHP", GameInformation.maxHitPoints);
        PlayerPrefs.SetInt("PLAYERATTACKDAMAGE", GameInformation.attackDamage);
        PlayerPrefs.SetInt("PLAYERMAGICDAMAGE", GameInformation.magicDamage);
        PlayerPrefs.SetInt("PLAYERGOLD", GameInformation.gold);
        PlayerPrefs.SetInt("PLAYERCURRENTHP", GameInformation.currentHitPoints);
        PlayerPrefs.SetInt("PLAYERCURRENTLEVEL", GameInformation.currentLevel);
        PlayerPrefs.SetInt("PLAYERCURRENTXP", GameInformation.currentXP);

        Debug.Log("This was called");


    }

}
