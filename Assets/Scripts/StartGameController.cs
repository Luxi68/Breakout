using UnityEngine.UI;
using UnityEngine;

public class StartGameController : MonoBehaviour
{

    private void Start()
    {
        // GameManager gm = FindObjectOfType<GameManager>();

        // // Load in save data ie highscores
        // gm.saveData = SaveGameSystem.LoadData("score_data");
        // if (gm.saveData == null)
        // {
        //     gm.saveData = new SaveData();
        // }
    }

    public void NewPlayer()
    {
        FindObjectOfType<GameManager>().NewPlayer();
    }

    public void ReturningPlayer()
    {
        FindObjectOfType<GameManager>().ReturningPlayer();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }
}
