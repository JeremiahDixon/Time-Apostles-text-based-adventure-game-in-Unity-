using UnityEngine;
using UnityEngine.UI;

public class AdventureGameRunner : MonoBehaviour
{
    public Text output;
    public Text input;
    public InputField inputField;
    private GameOutput gameIO;
    private Game game;

    // Use this for initialization
    public void Start()
    {
        gameIO = new GameOutput(output);
        game = new Game(gameIO);
        gameIO.clear();
        game.start();
        inputField.ActivateInputField();

    }

    public void Update()
    {
        // game.Update();

    }
		

    public void sendCommand()
    {
        if (input.text.Length > 0)
        {
            game.execute(input.text);
            inputField.text = "";
            inputField.ActivateInputField();
        }
    }

}
