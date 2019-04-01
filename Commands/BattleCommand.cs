public class BattleCommand : Command
{

    public BattleCommand() : base()
    {

        this.name = "battle";
    }

    override
        public bool execute(Player player)
    {
        bool answer = true;


        if (this.hasSecondWord())
        {
            player.outputMessage("\nI cannot battle such a thing called <b>" + this.secondWord + "</b>");
            answer = false;
        }
        else
        {
            player.battle(this.name);
        }



        return answer;

    }


}
