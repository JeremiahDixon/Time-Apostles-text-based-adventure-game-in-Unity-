public class Ability
{
    public Player player;
    public CharacterClass characterClass;


    private string _abilityName;
    private int _abilityDamage;
    private string _abilityType;

    public string AbilityName
    {
        get { return _abilityName; }
        set { _abilityName = value; }
    }

    public int AbilityDamage
    {
        get { return _abilityDamage; }
        set { _abilityDamage = value; }
    }

    public string AbilityType
    {
        get { return _abilityType; }
        set { _abilityType = value; }
    }


    public Ability() : this("No Name", 0, "no type")
    {

    }

    public Ability(string ability, int abilityDamage, string abilityType)
    {

        this.AbilityName = ability;
        this.AbilityDamage = abilityDamage;
        this.AbilityType = abilityType;
    }
    public string description()
    {
        return "\nYour abilities are:  \n" + player.attackBook[0].AbilityName + " and it has a base damage of " + player.attackBook[0].AbilityDamage
             + "\n" + player.attackBook[1].AbilityName + " and it has a base damage of " + player.attackBook[1].AbilityDamage + "\n";
    }




}
