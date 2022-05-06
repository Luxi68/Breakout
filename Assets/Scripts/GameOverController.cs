using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Text newHighScore;

    private int finalScore;

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        finalScore = gm.score;
        newHighScore.enabled = false;
        if (gm.saveData.newHighScore(finalScore))
        {
            newHighScore.enabled = true;
            gm.updateHighScore(finalScore);
        }

        saveProgress();
    }

    public void NewGame()
    {
        FindObjectOfType<GameManager>().NewGame();
    }

    public void QuitGame()
    {
        FindObjectOfType<GameManager>().Start();
    }

    private void saveProgress()
    {
        SaveGameSystem.DeleteSaveData("score_data");
        SaveGameSystem.SaveData(FindObjectOfType<GameManager>().saveData, "score_data");
    }
}

