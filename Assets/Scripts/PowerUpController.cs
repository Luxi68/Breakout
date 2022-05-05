using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private static float DEFAULT_SPEED = 8f;
    [SerializeField] private int powerUpID;

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
