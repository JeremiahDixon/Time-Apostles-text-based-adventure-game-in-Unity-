using UnityEngine;

public class GameInformation : MonoBehaviour
{


    //this is called before the start function
    void awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    public static string playerName { get; set; }
    public static int playerLevel { get; set; }


    public static int maxHitPoints { get; set; }
    public static int defenseRating { get; set; }
    public static int attackDamage { get; set; }
    public static int magicDamage { get; set; }
    public static int gold { get; set; }
    public static int currentHitPoints { get; set; }
    public static int currentLevel { get; set; }
    public static int currentXP { get; set; }
    public static CharacterClass playerClass { get; set; }



}
