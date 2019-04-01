public class InventoryCommand : Command
{

    public InventoryCommand() : base()
    {
        this.name = "inventory";
    }

    override
    public bool execute(Player player)
    {

        if (this.hasSecondWord())
        {
            player.outputMessage("\nI cannot inventory <b>" + this.secondWord + "</b>");

        }
        else
        {
            // player.displayInventory();
        }
        return false;
    }
}
