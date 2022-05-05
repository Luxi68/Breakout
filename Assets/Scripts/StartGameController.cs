using UnityEngine;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{
    [SerializeField] private Text highScoreCount;

    private void Start()
    {
        // TODO implement properly
        this.highScoreCount.text = "100000";
    }

    public void StartGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }
}
