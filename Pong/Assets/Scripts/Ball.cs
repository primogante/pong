using UnityEngine;

public class Ball : MonoBehaviour
{
    // Access
    private Rigidbody2D ball;

    // Ball launch parameters
    public int ballForce;

    public float maxSpeed;

    private bool ballIsLaunched;

    private Vector2 velocity;

    // Start is called before the first frame update
    private void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        maxSpeed = 20f;
        Invoke(nameof(LaunchSelect), .5f);
    }

    private void Update()
    {
        //if (ballIsLaunched)
    }

    //private void FixedUpdate()
    //{
    //    rigidBall.velocity = rigidBall.velocity.normalized * ballForce;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 paddleVelocity = new Vector2(collision.collider.attachedRigidbody.velocity.x, collision.collider.attachedRigidbody.velocity.y);

            velocity.x = ball.velocity.x;
            velocity.y = ball.velocity.x / 2 + paddleVelocity.y / 3;

            if (velocity.x > maxSpeed)
            {
                velocity.x = maxSpeed;
            }
            else if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }

            if (velocity.x < 4 && velocity.x >= 0)
            {
                velocity.x = 4f;
            }
            else if (velocity.x > -4 && velocity.x <= 0)
            {
                velocity.x = -4f;
            }

            ball.velocity = velocity;

            Debug.Log("velocity is " + velocity);
            Debug.Log(collision.contactCount);

            //Vector2 n, r;
            //n = new Vector2(collision.collider.attachedRigidbody.velocity.x, collision.collider.attachedRigidbody.velocity.y);
            //r = velocity - (2 * Vector2.Dot(velocity, n) * n);
            //ball.velocity = r;
        }
    }

    // Puts the ball in center (Refactor later for setting to player paddle etc)
    private void ResetToCentre()
    {
        ball.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void RestartGame()
    {
        ballIsLaunched = false;
        ResetToCentre();
        Invoke(nameof(LaunchSelect), 1);
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
        // ball.AddForce(new Vector2(x, y));
        // ball.MovePosition((Vector2)transform.position + (new Vector2(x, y) * Time.deltaTime));
        ball.velocity = new Vector2(x, y);
        ballIsLaunched = true;
    }

    // This is the default for now
    private void RandomLaunch()
    {
        float randomX = Random.Range(0, 2);
        int randomY = Random.Range(-5, 5);
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