using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour {

    public GameManager manager;
    public static bool WasGoal { get; private set; }
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "P1 Goal")
            {
                manager.Increment(GameManager.Score.Player2Scored);
                WasGoal = true;

                if(manager.CurrentPlayer2Score == manager.goalsNeededToWin)
                {
                    StartCoroutine(ResetGame());
                }
                else
                {
                    StartCoroutine(ResetPuck());
                }
            }
            else if (other.tag == "P2 Goal")
            {
                manager.Increment(GameManager.Score.Player1Scored);
                WasGoal = true;

                if (manager.CurrentPlayer1Score == manager.goalsNeededToWin)
                {
                    StartCoroutine(ResetGame());
                }
                else
                {
                    StartCoroutine(ResetPuck());
                }

            }
        }
    }

    private IEnumerator ResetPuck()
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
    }

    private IEnumerator ResetGame()
    {
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSecondsRealtime(5);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
