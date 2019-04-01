public class Paladin : CharacterClass
{
    public Paladin()
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
        return "\nPaladin Class: " + "\nHP: " + maxHitPoints +
               " Defense Rating: " + defenseRating +
               " Attack Damage: " + attackDamage +
               " Magic Damage: " + magicDamage +
               " Gold: " + gold + "\n";
    }

}
