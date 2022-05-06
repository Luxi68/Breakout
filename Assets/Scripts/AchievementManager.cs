using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    [SerializeField] private Text newAchievement;
    private Queue<Achievement> achievementQ = new Queue<Achievement>();
    
    public void NotifyAchievementComplete(Achievement achievement)
    {
        achievementQ.Enqueue(achievement);
    }

    private void Awake()
    {
    }
    private void Start()
    {
        this.newAchievement.enabled = false;
        StartCoroutine("AchievementQueCheck");
    }

    private void UnlockAchievement(Achievement achievement)
    {
        this.newAchievement.text = achievement.description;
        this.newAchievement.enabled = true;
        Debug.Log("Achievement unlocked: " + achievement.id);
    }

    private IEnumerator AchievementQueCheck()
    {
        for (; ; )
        {
            if (achievementQ.Count > 0) UnlockAchievement(achievementQ.Dequeue());
            yield return new WaitForSeconds(2f);
            this.newAchievement.enabled = false;
        }
    }
}
