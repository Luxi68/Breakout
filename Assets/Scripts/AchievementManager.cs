using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.UnlockFirstScoreAchievement += CheckAchievement;
    }

    private void OnDisable()
    {
        GameManager.UnlockFirstScoreAchievement -= CheckAchievement;
    }

    private void CheckAchievement(int id)
    {
        Debug.Log("Checking Achievement: "+ id);
        FindObjectOfType<GameManager>().updateAchievements(id);
        //lookup the id and startcourtine
    }
}
