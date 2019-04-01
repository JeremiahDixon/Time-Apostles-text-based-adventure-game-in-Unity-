using StateStuff;

public class MainMenuState : State<Game>
{
    public Player player;
    public Parser Parser;
    public Game game;
    public CommandWords CommandWords;



    private static MainMenuState _instance;

    private MainMenuState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static MainMenuState Instance
    {

        get
        {
            if (_instance == null)
            {
                new MainMenuState();
            }

            return _instance;
        }
    }


    public override string enterState(Game _owner)
    {



        return "\n\n\n\n\n TIME APOSTLES" + "\n\n     NEW GAME ? " + "\n\n";

    }

    public override void exitState(Game _owner)
    {

    }

    public override string updateState(Game _owner)
    {
        if (_owner.switchState)
        {
            _owner.StateMachine.changeState(WelcomeState.Instance);
        }
        return "";
    }
}
