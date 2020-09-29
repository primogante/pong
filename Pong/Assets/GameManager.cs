using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Player scores
    public static int Player1Score = 0;

    public static int Player2Score = 0;
    public int maxScore = 10;

    public GUISkin layout;

    private GameObject ball;

    // Start is called before the first frame update
    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + Player2Score);

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 50), "Restart"))
        {
            ScoreReset();
            ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
        }

        if (Player1Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 1 Wins");
            ball.SendMessage("ResetToCenter", null, SendMessageOptions.DontRequireReceiver);
            Invoke("ScoreReset", 2);
        }
        else if (Player2Score == maxScore)
        {
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "Player 2 Wins");
            ball.SendMessage("ResetToCenter", null, SendMessageOptions.DontRequireReceiver);
            Invoke("ScoreReset", 2);
        }
    }

    // Add score based on collision with wall (Check tag)
    public static void Score(string wall)
    {
        if (wall == "Left")
        {
            Player2Score++;
        }
        else if (wall == "Right")
        {
            Player1Score++;
        }
    }

    private void ScoreReset()
    {
        Player1Score = 0;
        Player2Score = 0;
    }
}