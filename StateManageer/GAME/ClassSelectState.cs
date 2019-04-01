using StateStuff;

public class ClassSelectState : State<Game>
{
    public Parser parsers;
    public Game game;
    public Player player;
    private static ClassSelectState _instance;

    private ClassSelectState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static ClassSelectState Instance
    {

        get
        {
            if (_instance == null)
            {
                new ClassSelectState();
            }

            return _instance;
        }
    }





    public override string enterState(Game _owner)
    {

        return "Please choose one of the classes below. Be aware tho, some of them are stronger \nthan others. " +
                                    " Type 'select' and the name of the class when you are ready to continue. \n";

    }




    public override void exitState(Game _owner)
    {
    }

    public override string updateState(Game _owner)
    {
        if (!_owner.switchState)
        {
            _owner.StateMachine.changeState(PlayingState.Instance);
        }
        return "";
    }
}

