using System.Collections.Generic;

public class CommandWords
{
    Dictionary<string, Command> commands;
    public static Command[] commandArray = {new GoCommand (), new QuitCommand (), new AttackCommand (), new CastCommand (),
		new EquipCommand (), new InspectCommand (), new UseCommand (), new SelectCommand (), new NextCommand (),
		new NewGameCommand (), new InteractCommand (), new SaveGameCommand (), new LoadGameCommand (), new OpenCommand (), new ShowCommand (),
		new BattleCommand (), new FastTravelCommand (), new BackCommand()
	};

    public CommandWords() : this(commandArray)
    {

    }

    public CommandWords(Command[] commandList)
    {
        commands = new Dictionary<string, Command>();
        foreach (Command command in commandList)
        {
            commands[command.name] = command;
        }
        Command help = new HelpCommand(this);
        commands[help.name] = help;
    }

    public Command get(string word)
    {
        Command command = null;
        commands.TryGetValue(word, out command);
        return command;
    }

    public string description()
    {
        string commandNames = "";
        Dictionary<string, Command>.KeyCollection keys = commands.Keys;
        foreach (string commandName in keys)
        {
            commandNames += " " + commandName;
        }
        return commandNames;


    }
}
