using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Text finalScoreCount;

    private void Start()
    {
        this.finalScoreCount.text = FindObjectOfType<GameManager>().score.ToString();
    }

    public void NewGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }

    public void QuitGame()
    {
        // TODO add data persistance
        Application.Quit();
    }
}

