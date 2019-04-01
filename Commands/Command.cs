public abstract class Command
{
    private string _name;
    public string name { get { return _name; } set { _name = value; } }
    private string _secondWord;
    public string secondWord { get { return _secondWord; } set { _secondWord = value; } }

    public Command()
    {
        this.name = "";
        this.secondWord = null;
    }

    public bool hasSecondWord()
    {
        return this.secondWord != null;
    }

    public abstract bool execute(Player player);
}
