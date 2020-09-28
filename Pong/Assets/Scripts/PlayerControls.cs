using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Enter the axis name found in Input Manager here, which signifies which player is being controlled
    public string playerVert;
    public string playerHori;

    // Game experience
    public float speed = 10.0f;

    public float boundary = 5.5f;

    // Access
    private Rigidbody2D rigidPaddle;

    // The below keycodes aren't required when using Input Manager - the keys are selected within Input Manager, which gets passed through playerNumber
    // Controls
    //public KeyCode moveUp;
    //public KeyCode moveDown;

    // Called at game start
    private void Start()
    {
        rigidPaddle = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Finds the axis name set in inspector and uses it to find the input being used
        float vert = Input.GetAxis(playerVert);
        float hori = Input.GetAxis(playerHori);

        // "Translates" the sum of y-axis movement x speed x delta and turns it into movement.
        transform.Translate(new Vector2(hori, vert) * speed * Time.deltaTime);

        var position = transform.position;
        if (position.y > boundary)
        {
            position.y = boundary;
        }
        else if (position.y < -boundary)
        {
            position.y = -boundary;
        }

        if (position.x > 9)
        {
            position.x = 9;
        }
        else if (position.x < -9)
        {
            position.x = -9;
        }

        transform.position = position;
    }
}