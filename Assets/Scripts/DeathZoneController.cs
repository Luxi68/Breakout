using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        { //HACK Maybe getting the component would be safer?
            FindObjectOfType<GameManager>().BallDeath();
        }
    }
}
