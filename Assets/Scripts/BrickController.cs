using UnityEngine;

public class BrickController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] healthStates;
    [SerializeField] private Transform powerUp;

    [SerializeField] public bool unbreakable;
    public int health { get; private set; }
    public int points { get; private set; } = 100;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (!this.unbreakable)
        {
            this.health = this.healthStates.Length;
            this.spriteRenderer.sprite = this.healthStates[this.health - 1];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        { //HACK Maybe getting the component would be safer?
            OnHit();
        }
    }

    private void OnHit()
    {
        if (this.unbreakable) { return; }
        this.health--;

        if (this.health <= 0)
        {
            // this.gameObject.SetActive(false);
            Destroy(this.gameObject);

            int randNum = Random.Range(1, 101);
            if (randNum < 100)
            {
                // HACK need to change back when done
                DropPowerUp(randNum);
            }
        }
        else
        {
            this.spriteRenderer.sprite = this.healthStates[this.health - 1];
        }

        FindObjectOfType<GameManager>().BrickHit(this);
    }

    private void DropPowerUp(int num)
    {
        Instantiate(powerUp, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
