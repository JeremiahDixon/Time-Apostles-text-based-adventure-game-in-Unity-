public abstract class CharacterClass
{
    private int _maxHitPoints;
    private int _defenseRating;
    private int _attackDamage;
    private int _magicDamage;
    private int _gold;
    private int _currentHitPoints;
    private int _currentLevel;
    private int _currentXP;


    public int maxHitPoints { get; set; }
    public int defenseRating { get; set; }
    public int attackDamage { get; set; }
    public int magicDamage { get; set; }
    public int gold { get; set; }
    public int currentHitPoints { get; set; }
    public int currentLevel { get; set; }
    public int currentXP { get; set; }


}
