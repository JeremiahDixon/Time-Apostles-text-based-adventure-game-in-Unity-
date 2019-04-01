using StateStuff;
using UnityEngine;

public class GameOverState : State<Game>
{
    public Parser parsers;
    public Game game;
    public Player player;
    private static GameOverState _instance;

    private GameOverState()
    {
        if (_instance != null)
        {
            return;
        }
        _instance = this;
    }

    public static GameOverState Instance
    {

        get
        {
            if (_instance == null)
            {
                new GameOverState();
            }

            return _instance;
        }
    }



    public override string enterState(Game _owner)
    {
        return "Game Over";

    }

    public override void exitState(Game _owner)
    {

    }

    public override string updateState(Game _owner)
    {
        if (!_owner.switchState)
        {
            _owner.StateMachine.changeState(MainMenuState.Instance);
        }
        return "";
    }
}

