using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnPlayerController : MonoBehaviour
{
    [SerializeField] private Text ScoreDetailCount;
    [SerializeField] private Text AchievementDetailCount;
    [SerializeField] private Dropdown AllUsers;
    private List<string> names;

    private void Start()
    {
        names = SaveGameSystem.GetAllUsers();
        AllUsers.options.Clear();

        foreach (string option in names)
        {
            AllUsers.options.Add(new Dropdown.OptionData(option));
        }
        AllUsers.RefreshShownValue();
        UpdateText();
    }

    public void StartGame()
    {
        string username = names[AllUsers.value];
        
        GameManager gm = FindObjectOfType<GameManager>();
        gm.saveData = SaveGameSystem.LoadData(username);
        gm.NewGame();
    }

    public void BackToStart()
    {
        FindObjectOfType<GameManager>().Start();
    }

    public void UpdateText()
    {
        string username = names[AllUsers.value];
        
        SaveData data = SaveGameSystem.LoadData(username);
        this.ScoreDetailCount.text = data.highScore.ToString();
        this.AchievementDetailCount.text = data.unlockLevel.ToString();
    }
}
