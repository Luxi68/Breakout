using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static int DEFAULT_START_LEVEL = 1;
    private static int DEFAULT_MAX_LEVEL = 5;
    private static int DEFAULT_START_SCORE = 0;
    private static int DEFAULT_START_LIVES = 3;
    
    [SerializeField] private Text levelCount;
    [SerializeField] private Text scoreCount;
    [SerializeField] private Text livesCount;

    [SerializeField] private int level;
    [SerializeField] private int score;
    [SerializeField] private int lives;

    public static GameManager instance { get; private set; }
    public BallController ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public BrickController[] bricks { get; private set; }

    private void Awake()
    {
        // Ensures only one game manager can exist (singlton)
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Allows this (game manager) to persist between loading
        DontDestroyOnLoad(this.gameObject);
        // Subscribing to the scene loaded event
        SceneManager.sceneLoaded += OnLevelLoad;
    }

    // Start is called before the first frame update
    private void Start()
    {
        SceneManager.LoadScene("Start");
        // NewGame();
    }

    public void NewGame()
    {
        this.score = DEFAULT_START_SCORE;
        this.lives = DEFAULT_START_LIVES;

        this.scoreCount.text = score.ToString();
        this.livesCount.text = lives.ToString();

        LoadLevel(DEFAULT_START_LEVEL);
    }

    private void LoadLevel(int level)
    {
        this.level = level;

        this.levelCount.text = level.ToString();

        if (level > DEFAULT_MAX_LEVEL)
        {
            // TODO Add win screen
            // SceneManager.LoadScene("WinScreen");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }

        // CHECK make sure to add new levels to file>build settings
    }

    private void OnLevelLoad(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<BallController>();
        this.paddle = FindObjectOfType<PaddleController>();
        this.bricks = FindObjectsOfType<BrickController>();
    }

    private void ResetLevel()
    {
        this.ball.Reset();
        this.paddle.Reset();
    }

    private void GameOver()
    {
        // TODO make gameover screen
        SceneManager.LoadScene("GameOver");
        // NewGame();
    }

    public void BallDeath()
    {
        this.lives--;
        this.livesCount.text = lives.ToString();

        if (this.lives > 0)
        {
            ResetLevel();
        }
        else
        {
            GameOver();
        }
    }

    public void BrickHit(BrickController brick)
    {
        this.score += brick.points;
        this.scoreCount.text = score.ToString();

        if (IsCleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    private bool IsCleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
}
