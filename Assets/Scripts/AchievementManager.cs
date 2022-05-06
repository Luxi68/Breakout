using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    private void Start()
    {
        GameManager.UnlockScoreAchievement += CheckAchievement;
    }

    private void OnDisable()
    {
        GameManager.UnlockScoreAchievement -= CheckAchievement;
    }

    private void CheckAchievement(int id)
    {
        // TODO check for negatives ect
        Debug.Log("Checking Achievement: "+ id);
        FindObjectOfType<GameManager>().updateAchievements(id);
        //lookup the id and startcourtine
    }
}
