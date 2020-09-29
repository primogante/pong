using UnityEngine;

public class Ball : MonoBehaviour
{
    // Access
    private Rigidbody2D rigidBall;

    // Ball launch parameters
    public int ballForce;
    public float maxSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        rigidBall = GetComponent<Rigidbody2D>();
        maxSpeed = 20f;
        Invoke("LaunchSelect", .5f);
    }

    //private void FixedUpdate()
    //{
    //    rigidBall.velocity = rigidBall.velocity.normalized * ballForce;
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 velocity;
            Vector2 paddleVelocity = new Vector2(collision.collider.attachedRigidbody.velocity.x, collision.collider.attachedRigidbody.velocity.y);

            velocity.x = rigidBall.velocity.x;

            velocity.y = ((rigidBall.velocity.y / 2) + (collision.collider.attachedRigidbody.velocity.y / 3));

            if (velocity.x > maxSpeed) {
                velocity.x = maxSpeed;
            } else if (velocity.x < -maxSpeed)
            {
                velocity.x = -maxSpeed;
            }
            rigidBall.velocity = velocity;


            Debug.Log("velocity is " + velocity);
            Debug.Log(collision.contactCount);

            //Vector3 d, n, r;
            //d = rigidBall.velocity;
            //n = collision;
            //r = d - (2 * Vector2.Dot(d, n) * n);

            //rigidBall.velocity = r;
        }
    }

    // Puts the ball in center (Refactor later for setting to player paddle etc)
    private void ResetToCentre()
    {
        rigidBall.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    private void RestartGame()
    {
        ResetToCentre();
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
        //rigidBall.MovePosition((Vector2)transform.position + (new Vector2(x, y) * Time.deltaTime));
        // rigidBall.velocity = new Vector2(x, y);
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