using StateStuff;
using UnityEngine;

public class BattleState : State<Game>
{
    private CharacterClass characterClass;
    public Parser parsers;
    public Game game;
    public Player player;
    private static BattleState _instance;
    public NPC npc;
    public Mage mage;
    public Witcher witcher;
    public Paladin pally;

    private BattleState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static BattleState Instance
    {

        get
        {
            if (_instance == null)
            {
                new BattleState();
            }

            return _instance;
        }
    }




    public override string enterState(Game _owner)
    {

        return "\nPrepare to battle!!";

    }

    public override void exitState(Game _owner)
    {

    }

    public override string updateState(Game _owner)
    {
        Debug.Log("update state in battle state");

        if (!_owner.switchState)
        {


        }


        return "";
    }
}

