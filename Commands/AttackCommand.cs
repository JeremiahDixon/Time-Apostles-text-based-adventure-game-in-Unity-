public class AttackCommand : Command
{

    private Ability ability;
    public AttackCommand() : base()
    {

        this.name = "attack";
    }

    override
        public bool execute(Player player)
    {
        if (this.hasSecondWord())
        {
            player.attack(this.secondWord);
        }
        else
        {
            player.outputMessage("\nInteract <b>What</b>?");
        }
        return false;
    }
    /*if (this.hasSecondWord())
   {
       if (this.secondWord == player.spellbook[0].AbilityName)
       {
           player.attack(player.spellbook[0]);
           Debug.Log("spell 0");
       }
       else if (this.secondWord == player.spellbook[1].AbilityName)
       {
           player.attack(player.spellbook[1]);
           Debug.Log("spell 1");
       }
   }
   else
   {
       player.outputMessage("\nI do not have an attack called <b>" + this.secondWord + "</b>");
       answer = false;
   }
   return answer;

}
   */


}
