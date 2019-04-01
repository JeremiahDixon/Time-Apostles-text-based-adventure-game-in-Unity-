using UnityEngine;
public class CastCommand : Command
{
    private Ability ability;
    public CastCommand() : base()
    {

        this.name = "cast";
    }

    override
        public bool execute(Player player)
    {
        bool answer = true;


        if (this.hasSecondWord())
        {
            if (this.secondWord == player.spellBook[0].spellName || this.secondWord == player.spellBook[1].spellName)
            {
                Debug.Log("we got passed the cast string check");
                //player.NewGame();


            }
            else
            {
                player.outputMessage("\nI do not have an attack called <b>" + this.secondWord + "</b>");
                answer = false;
            }

        }
        return answer;

    }




}
