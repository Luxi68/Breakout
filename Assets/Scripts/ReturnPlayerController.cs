using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnPlayerController : MonoBehaviour
{
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
}
