using System;

[Serializable]
public class SaveData
{
    public string username { get; private set; }

    public int highScore { get; private set; }

    public Achievement[] achievementList { get; private set; }
    public int unlockLevel;

    public SaveData(string username)
    {
        this.username = username;
        this.highScore = 0;
        this.achievementList = new Achievement[3];
        this.unlockLevel = 0;
    }

    public bool newHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            return true;
        }

        return false;
    }

    public Achievement addNewAchievement(int id)
    {
        if (achievementList[id] == null)
        {
            string description;
            switch (id)
            {
                case 0:
                    description = "Running out of lives? Unlocked extra lives.";
                    break;

                case 1:
                    description = "Lets make this harder. Unlocked paddle speed up.";
                    break;

                case 2:
                    description = "Too Fast? Unlocked paddle speed down.";
                    break;

                default:
                    return null;
            }
            Achievement achievement = new Achievement(id, description);
            achievementList[id] = achievement;
            unlockLevel++;
            return achievement;
        }
        return null;
    }
}