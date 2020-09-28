using UnityEngine;

public class Ball : MonoBehaviour
{
    // Access
    private Rigidbody2D rigidBall;

    // Ball launch parameters
    public int ballForce = 30;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
        Invoke("LaunchSelect", 2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 velocity;
            velocity.x = rigidBall.velocity.x;

            velocity.y = (rigidBall.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3);
            rigidBall.velocity = velocity;
        }
    }

    // Puts the ball in center (Refactor later for setting to player paddle etc)
    private void ResetToCeter()
    {
        rigidBall.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void RestartGame()
    {
        ResetToCeter();
        Invoke("LaunchSelect", 1);
    }

    /*    void Invoke()
        {
            LaunchSelect();
        }*/

    // Choose if a direction or a random launch
    private void LaunchSelect()
    {
        RandomLaunch();
    }

    // Send launch direction
    private void LaunchBall(int x, int y)
    {
        rigidBall.AddForce(new Vector2(x, y));
    }

    // This is the default for now
    private void RandomLaunch()
    {
        float randomX = Random.Range(0, 2);
        int randomY = Random.Range(-15, 15);
        if (randomX < 1)
        {
            LaunchBall(ballForce, randomY);
        }
        else
        {
            LaunchBall(-ballForce, randomY);
        }
    }
}