using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Enter the axis name found in Input Manager here, which signifies which player is being controlled
    public string playerNumber;

    // Game experience
    public float speed = 10.0f;

    public float boundary = 4.09f;

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
        //var velocity = rigidPaddle.velocity;

        // Finds the axis name set in inspector and uses it to find the input being used
        float vert = Input.GetAxis(playerNumber);

        // "Translates" the sum of y-axis movement x speed x delta and turns it into movement.
        transform.Translate(new Vector2(0, vert) * speed * Time.deltaTime);

        // transform.Translate line of code replaces the below velocity code
        //if (vertical > .1)
        //{
        //    velocity.y = speed;
        //}
        //else if (vertical < -.1)
        //{
        //    velocity.y = -speed;
        //}
        //else
        //{
        //    velocity.y = 0;
        //}
        //rigidPaddle.velocity = velocity;

        var position = transform.position;
        if (position.y > boundary)
        {
            position.y = boundary;
        }
        else if (position.y < -boundary)
        {
            position.y = -boundary;
        }
        transform.position = position;
    }
}