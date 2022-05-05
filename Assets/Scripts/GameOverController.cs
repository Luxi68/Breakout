using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Text finalScoreCount;
    [SerializeField] private Text newHighScore;

    private int finalScore;

    private void Start()
    {
        GameManager gm = FindObjectOfType<GameManager>();

        finalScore = gm.score;
        this.finalScoreCount.text = finalScore.ToString();
        newHighScore.enabled = gm.saveData.newHighScore(finalScore);

        saveProgress();
    }

    public void NewGame()
    {
        FindObjectOfType<GameManager>().Start();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void saveProgress()
    {
        SaveGameSystem.DeleteSaveData("score_data");
        SaveGameSystem.SaveData(FindObjectOfType<GameManager>().saveData, "score_data");
    }
}

