using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    private static float MAX_BOUNCE_ANGLE = 75f;
    [SerializeField] private float speed;
    private Rigidbody2D rb2D;
    private Vector2 direction;

    private void Awake()
    {
        this.rb2D = GetComponent<Rigidbody2D>();
        this.speed = 60f;
    }

    public void Reset()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
        this.rb2D.velocity = Vector2.zero;
    }

    // Update is called once per frame
    private void Update()
    {
        // Detect where the player is moving the paddle
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.direction = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
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
        if (this.direction != Vector2.zero)
        {
            this.rb2D.AddForce(this.direction * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();

        // Adds variable return angles for ball
        if (ball != null)
        {
            Vector2 paddlePos = this.transform.position;
            Vector2 contactPt = collision.GetContact(0).point;
            float offset = paddlePos.x - contactPt.x;

            // Half of total width of paddle (otherCollider)
            float halfWidth = collision.otherCollider.bounds.size.x / 2;

            Rigidbody2D ballRb2D = ball.GetComponent<Rigidbody2D>();

            // Find angle of ball using its rigidbody
            // CHECK should this be here?
            float curAngle = Vector2.SignedAngle(Vector2.up, ballRb2D.velocity);
            float bounceAngle = (offset / halfWidth) * MAX_BOUNCE_ANGLE;
            float newAngle = Mathf.Clamp(curAngle + bounceAngle, -MAX_BOUNCE_ANGLE, MAX_BOUNCE_ANGLE);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ballRb2D.velocity = rotation * Vector2.up * ballRb2D.velocity.magnitude;
        }
    }

    public void incSpeed()
    {
        this.speed += 30f;
    }

    public void decSpeed()
    {
        if(this.speed > 60f) {
            this.speed -= 30f;
        }
    }
}
