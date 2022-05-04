using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int DEFAULT_START_LEVEL = 1;
    private static int DEFAULT_START_SCORE = 0;
    private static int DEFAULT_START_LIVES = 3;

    public int level;
    public int score;
    public int lives;

    private void Awake()
    {
        // Allows this (game manager) to persist between loading
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.score = DEFAULT_START_SCORE;
        this.lives = DEFAULT_START_LIVES;

        LoadLevel(DEFAULT_START_LEVEL);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        SceneManager.LoadScene("Level" + level);
    }
}
