public class Witcher : CharacterClass
{
    public Witcher()
    {
        maxHitPoints = 100;
        currentHitPoints = maxHitPoints;
        defenseRating = 20;
        attackDamage = 20;
        magicDamage = 20;
        gold = 20;
        currentLevel = 1;
        currentXP = 0;


    }

    public string description()
    {
        return "\nWitcher CLASS: " + "\nHP: " + maxHitPoints +
               " Defense Rating: " + defenseRating +
               " Attack Damage: " + attackDamage +
               " Magic Damage: " + magicDamage +
               " Gold: " + gold + "\n";

    }




}


