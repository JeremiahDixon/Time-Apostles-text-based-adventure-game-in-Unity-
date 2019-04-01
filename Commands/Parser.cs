using UnityEngine;

public class Parser
{

    private CommandWords commands;


    public Parser() : this(new CommandWords())
    {

    }

    public Parser(CommandWords newCommands)
    {
        commands = newCommands;
    }



    public Command parseCommand(string commandString)
    {
        Command command = null;
        string[] words = commandString.Split(' ');

        string itemName = "";
        for (int i = 1; i < words.Length; i++)
        {
            if (i == 1)
            {
                itemName = itemName + words[i];
            }
            if (i > 1)
            {
                itemName = itemName + " " + words[i];
            }

        }

        if (words.Length > 0)
        {
            command = commands.get(words[0]);
            if (command != null)
            {
                if (words.Length > 1)
                {
                    command.secondWord = itemName;
                }
                else
                {
                    command.secondWord = null;
                }
            }
            else
            {
                Debug.Log(">>>Did not find the command " + words[0]);
            }
        }
        else
        {
            Debug.Log("No words parsed!");
        }
        return command;
    }

    public string description()
    {
        return commands.description();
    }
}
