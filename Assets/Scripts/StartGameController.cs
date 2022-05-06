using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        // Load in save data ie highscores
        gm.saveData = SaveGameSystem.LoadData("score_data");
        if (gm.saveData == null)
        {
            gm.saveData = new SaveData();
        }
    }

    public void StartGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }

    public void NewPlayer()
    {

    }

    public void ReturningPlayer()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
