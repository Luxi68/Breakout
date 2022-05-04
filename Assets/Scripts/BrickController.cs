using UnityEngine;

public class BrickController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Sprite[] healthStates;
    public int health { get; private set; }
    private bool unbreakable;

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

    private void OnHit()
    {
        if (this.unbreakable) { return; }
        this.health--;

        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
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
}
