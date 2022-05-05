using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private Text highScoreCount;

    private void Start()
    {
        this.highScoreCount.text = FindObjectOfType<GameManager>().saveData.highScore.ToString();
    }

    public void StartGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }
}
