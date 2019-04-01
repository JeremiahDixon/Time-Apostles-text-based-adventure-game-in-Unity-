public class AchievementsManager
{

    string usepotion = "Uncompleted";
    string equipweapon = "Uncompleted";
    string openchest = "Uncompleted";

    public AchievementsManager()
    {
        Player.UnlockAchievement += unlockAchievement;
    }

    public void unlockAchievement(string achievement)
    {
        switch (achievement)
        {
            case "drink a potion":
                usepotion = "Completed";
                break;
            case "equip a weapon":
                equipweapon = "Completed";
                break;
            case "open a chest":
                openchest = "Completed";
                break;
            default:
                break;
        }

    }

    public string unlockAchievementMessage(string achievement)
    {
        return "\nYou have unlocked the achievement: " + achievement + "!\n";
    }

    public string getAchievements()
    {
        return "ACHIEVEMENTS!\n--------------------------\nUse a potion: " + usepotion + "\nEquip a weapon: " + equipweapon + "\nOpen a Chest: " + openchest + "\n";
    }

}
