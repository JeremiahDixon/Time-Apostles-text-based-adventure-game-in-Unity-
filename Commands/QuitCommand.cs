
public class QuitCommand : Command
{

    public QuitCommand() : base()
    {
        this.name = "quit";
    }

    override
    public bool execute(Player player)
    {
		if (this.hasSecondWord ()) {
			player.outputMessage ("\nI cannot quit <b>" + this.secondWord + "</b>");
		} else {
			player.quit ();
		}
		return false;
    }
}
