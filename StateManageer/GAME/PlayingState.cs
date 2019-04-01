using StateStuff;

public class PlayingState : State<Game>
{
    public Parser parsers;
    public Game game;
    public Player player;
    private static PlayingState _instance;

    private PlayingState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static PlayingState Instance
    {

        get
        {
            if (_instance == null)
            {
                new PlayingState();
            }

            return _instance;
        }
    }




    public override string enterState(Game _owner)
    {



        return "";

    }

    public override void exitState(Game _owner)
    {

    }

    public override string updateState(Game _owner)
    {
        if (!_owner.switchState)
        {
            _owner.StateMachine.changeState(BattleState.Instance);
        }
        return "";
    }
}