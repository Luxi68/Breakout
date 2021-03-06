using System;
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
    [SerializeField] private Text livesCount; 
    [SerializeField] private Text scoreCount;
    [SerializeField] private Text highScoreCount;
    [SerializeField] private Text username;
    

    [SerializeField] public int level { get; private set; }
    [SerializeField] public int lives { get; private set; }
    [SerializeField] public int score { get; private set; }
    [SerializeField] public int highScore { get; private set; }

    public static GameManager instance { get; private set; }
    public SaveData saveData;

    public BallController ball { get; private set; }
    public PaddleController paddle { get; private set; }
    public BrickController[] bricks { get; private set; }

    // public static event Action<int> UnlockScoreAchievement;

    public void updateHighScore(int score)
    {
        this.highScore = score;
        this.highScoreCount.text = highScore.ToString();
    }

    public void updateAchievements(int id)
    {
        Achievement achievement = saveData.addNewAchievement(id);
        
        if (achievement != null)
        {
            // FindObjectOfType<PowerUpController>().unlockLevel = id + 1;
            FindObjectOfType<AchievementManager>().NotifyAchievementComplete(achievement);
        }
    }

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
    public void Start()
    {
        this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        SceneManager.LoadScene("Start");
    }

    public void NewPlayer()
    {
        SceneManager.LoadScene("NewPlayer");
    }

    public void CreateNewPlayer(string username)
    {
        this.saveData = new SaveData(username);
        SaveGameSystem.SaveData(this.saveData, username);
        NewGame();
    }

    public void ReturningPlayer()
    {
        SceneManager.LoadScene("ReturnPlayer");
    }

    public void NewGame()
    {
        this.gameObject.GetComponentInChildren<Canvas>().enabled = true;

        this.score = DEFAULT_START_SCORE;
        this.lives = DEFAULT_START_LIVES;

        this.scoreCount.text = score.ToString();
        this.livesCount.text = lives.ToString();

        updateHighScore(saveData.highScore);
        this.username.text = this.saveData.username;

        LoadLevel(DEFAULT_START_LEVEL);
    }

    private void LoadLevel(int level)
    {
        this.level = level;
        this.levelCount.text = level.ToString();

        if (level > DEFAULT_MAX_LEVEL)
        {
            // this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Level" + level);
        }
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
        // this.gameObject.GetComponentInChildren<Canvas>().enabled = false;
        SceneManager.LoadScene("GameOver");
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

        if(this.score == 400) updateAchievements(0);
        if(this.score == 1600) updateAchievements(1);
        if(this.score == 2400) updateAchievements(2);
        
           
        if (IsCleared())
        {
            LoadLevel(this.level + 1);
        }
    }

    public void PowerUpHit(int powerUpID)
    {
        switch (powerUpID)
        {
            case 0:
                this.lives++;
                this.livesCount.text = lives.ToString();
                break;

            case 1:
                this.paddle.incSpeed();
                break;

            case 2:
                this.paddle.decSpeed();
                break;

            default:
                break;
        }
    }

    public bool IsCleared()
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
