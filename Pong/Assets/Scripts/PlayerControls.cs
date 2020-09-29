using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public string playerVert;
    public string playerHori;
    public Vector2 movement;
    private Rigidbody2D paddle;

    // Game experience
    public float speed = 10.0f;

    public float boundary = 5.5f;

    // Called at game start
    private void Start()
    {
        paddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Finds the axis name set in inspector and uses it to find the input being used
        float vert = Input.GetAxis(playerVert);
        float hori = Input.GetAxis(playerHori);

        movement = new Vector2(hori, vert);
        // "Translates" the sum of movement x speed x delta and turns it into movement.
        //transform.Translate(new Vector2(hori, vert) * speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        movePaddle(movement);
    }

    void movePaddle(Vector2 direction)
    {
        paddle.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        //paddle.velocity = direction * speed;
    }

}