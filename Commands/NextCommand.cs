public class NextCommand : Command
{
    public Game game;
    public NextCommand() : base()
    {

        this.name = "next";
    }

    override
        public bool execute(Player player)
    {
        bool answer = true;


        if (this.hasSecondWord())
        {
            player.outputMessage("\nI cannot next such a thing called <b>" + this.secondWord + "</b>");
            answer = false;
        }
        else
        {

            player.next();


        }



        return answer;

    }


}
