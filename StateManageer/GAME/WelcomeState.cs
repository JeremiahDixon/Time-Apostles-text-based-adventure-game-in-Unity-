using StateStuff;
using UnityEngine;

public class WelcomeState : State<Game>
{
    public Game game;
    public Player player;
    public Parser parsers;

    private static WelcomeState _instance;

    private WelcomeState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static WelcomeState Instance
    {

        get
        {
            if (_instance == null)
            {
                new WelcomeState();
            }

            return _instance;
        }
    }




    public override string enterState(Game _owner)
    {

        return "\nWelcome to TIME APOSTLES!\n\nOn this mission you will be undertaking a job that requires you to " +
        	"to fix a 'temporal fault'. Before we send you on a mission, you need to pick a disguise.'" +
                             "\n\nType Next when you are ready to choose or " +
                             "\n\nType 'help' to see a list of available commands.\n\n";


    }


    public override void exitState(Game _owner)
    {

    }

    public override string updateState(Game _owner)
    {
        if (!_owner.switchState)
        {
            _owner.StateMachine.changeState(ClassSelectState.Instance);
        }
        return "";
    }


}
