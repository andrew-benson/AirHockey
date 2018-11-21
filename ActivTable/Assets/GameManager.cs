using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int goalsNeededToWin = 7;

    public enum Score
    {
        Player1Scored, Player2Scored
    }

    public Text p1Txt, p2Txt, gameOverText;
    private int currentPlayer1Score, currentPlayer2Score;

    public int CurrentPlayer1Score
    {
        get { return currentPlayer1Score; }
        private set { currentPlayer1Score = value; }
    }

    public int CurrentPlayer2Score
    {
        get
        {
            return currentPlayer2Score;
        }

        private set
        {
            currentPlayer2Score = value;
        }
    }

    public void Increment(Score playerScored)
    {
        if (playerScored == Score.Player1Scored)
            p1Txt.text = (++CurrentPlayer1Score).ToString();
        else
            p2Txt.text = (++CurrentPlayer2Score).ToString();

        if(CurrentPlayer1Score == goalsNeededToWin)
        {
            gameOverText.enabled = true;
            gameOverText.text += "Player 1";
        }

        if (CurrentPlayer2Score == goalsNeededToWin)
        {
            gameOverText.enabled = true;
            gameOverText.text += "Player 2";
        }
    }
}
