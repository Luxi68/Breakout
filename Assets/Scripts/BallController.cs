using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    private static float DEFAULT_SPEED = 20f;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Reset();
    }

    private void FixedUpdate()
    {
        this.rb2D.velocity = this.rb2D.velocity.normalized * DEFAULT_SPEED;
    }

    public void Reset()
    { 
        // this.transform.position = Vector2.zero;
        this.transform.position = new Vector2(0f, -13.5f);
        this.rb2D.velocity = Vector2.zero;

        Invoke(nameof(SetRandDirection), 1f);
    }

    private void SetRandDirection()
    {
        Vector2 force = Vector2.zero;
        // Randomise initil diagonal movement
        force.x = Random.Range(-0.5f, 0.5f);
        force.y = 1f;

        this.rb2D.AddForce(force.normalized * DEFAULT_SPEED);
    }
}
