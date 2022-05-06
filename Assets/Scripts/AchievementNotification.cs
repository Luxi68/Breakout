using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementNotification : MonoBehaviour
{
    [SerializeField] private Text newAchievement;
    private Queue<Achievements> achievementQ = new Queue<Achievements>();
    
    public void NotifyAchievementComplete(string ID)
    {
        achievementQ.Enqueue(new Achievements(ID));
    }

    private void Awake()
    {
    }
    private void Start()
    {
        this.newAchievement.enabled = false;
        StartCoroutine("AchievementQueCheck");
    }

    private void UnlockAchievement(Achievements achievement)
    {
        this.newAchievement.enabled = true;
        Debug.Log("Achievement unlocked: " + achievement.ID);
    }

    private IEnumerator AchievementQueCheck()
    {
        for (; ; )
        {
            if (achievementQ.Count > 0) UnlockAchievement(achievementQ.Dequeue());
            yield return new WaitForSeconds(5f);
            this.newAchievement.enabled = false;
        }
    }
}
