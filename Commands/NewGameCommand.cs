using UnityEngine;
public class NewGameCommand : Command
{
    public Game game;
    public NewGameCommand() : base()
    {

        this.name = "new";
    }

    override
        public bool execute(Player player)
    {
        bool answer = true;


        if (this.hasSecondWord())
        {
            if (this.secondWord == "game")
            {
                Debug.Log("we got passed the NEW game string check");
                player.NewGame();


            }
            else
            {
                player.outputMessage("\nI cannot save such a thing called <b>" + this.secondWord + "</b>");
                answer = false;
            }

        }
        return answer;

    }


}
