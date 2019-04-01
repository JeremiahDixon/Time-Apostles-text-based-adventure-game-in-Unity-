using UnityEngine;

public class SaveGameCommand : Command
{

    public SaveGameCommand() : base()
    {

        this.name = "save";
    }

    override
        public bool execute(Player player)
    {
        bool answer = true;


        if (this.hasSecondWord())
        {
            if (this.secondWord == "game")
            {
                Debug.Log("we got passed the game string check");
                player.SaveGame();


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