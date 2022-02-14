using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    private static float DEFAULT_SPEED = 60f;
    private static float MAX_BOUNCE_ANGLE = 75f;

    private Rigidbody2D rb2D;
    private Vector2 direction;
    
    private void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Detect where the player is moving the paddle
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.direction = Vector2.right;
        }
        else
        {
            this.direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        // Move the paddle
        if(this.direction != Vector2.zero)
        {
            this.rb2D.AddForce(this.direction * DEFAULT_SPEED);
        }
    }
}
