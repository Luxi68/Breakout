using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour
{
    private static float DEFAULT_SPEED = 1000f;

    private Rigidbody2D rb2D;

    private void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        Invoke(nameof(SetRandDirection), 1f);
    }

    private void SetRandDirection()
    {
        Vector2 force = Vector2.zero;
        // Randomise initil diagonal movement
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rb2D.AddForce(force.normalized * DEFAULT_SPEED);
    }
}
