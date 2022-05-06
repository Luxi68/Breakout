using UnityEngine.UI;
using UnityEngine;

public class StartGameController : MonoBehaviour
{

    private void Start()
    {
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
