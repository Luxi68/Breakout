using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private static float DEFAULT_SPEED = 8f;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] powerUps;
    [SerializeField] private int powerUpID;
    public int unlockLevel;

    private void Awake()
    {
        unlockLevel = FindObjectOfType<GameManager>().saveData.unlockLevel;
        Debug.Log(unlockLevel);
        if (unlockLevel == 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            this.spriteRenderer = GetComponent<SpriteRenderer>();
            this.powerUpID = Random.Range(0, unlockLevel);
        }
    }

    private void Start()
    {
        this.spriteRenderer.sprite = this.powerUps[powerUpID];
    }

    private void Update()
    {
        transform.Translate(new Vector2(0f, -1f) * Time.deltaTime * DEFAULT_SPEED);

        if (transform.position.y < -20f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            FindObjectOfType<GameManager>().PowerUpHit(powerUpID);
            // this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
