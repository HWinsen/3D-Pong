using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerOneScore;
    public int playerTwoScore;
    public int playerThreeScore;
    public int playerFourScore;

    private int deadPlayerCount = 0;

    [SerializeField] private int maxScore;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject playerOnePaddle;
    [SerializeField] private GameObject playerTwoPaddle;
    [SerializeField] private GameObject playerThreePaddle;
    [SerializeField] private GameObject playerFourPaddle;
    [SerializeField] private BoxCollider gawangPlayerOne;
    [SerializeField] private BoxCollider gawangPlayerTwo;
    [SerializeField] private BoxCollider gawangPlayerThree;
    [SerializeField] private BoxCollider gawangPlayerFour;
    [SerializeField] private GameObject gameOverCanvas;

    public void AddPlayerOneScore(int increment)
    {
        playerOneScore += increment;
        //ResetGame();

        if (playerOneScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerOnePaddle.SetActive(false);
            gawangPlayerOne.isTrigger = false;
            gawangPlayerOne.gameObject.transform.position = new Vector3(gawangPlayerOne.transform.position.x, gawangPlayerOne.transform.position.y, -13);
            GameOver();
        }
    }

    public void AddPlayerTwoScore(int increment)
    {
        playerTwoScore += increment;
        //ResetGame();

        if (playerTwoScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerTwoPaddle.SetActive(false);
            gawangPlayerTwo.isTrigger = false;
            gawangPlayerTwo.gameObject.transform.position = new Vector3(gawangPlayerTwo.transform.position.x, gawangPlayerTwo.transform.position.y, 13);
            GameOver();
        }
    }

    public void AddPlayerThreeScore(int increment)
    {
        playerThreeScore += increment;
        //ResetGame();

        if (playerThreeScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerThreePaddle.SetActive(false);
            gawangPlayerThree.isTrigger = false;
            gawangPlayerThree.gameObject.transform.position = new Vector3(13, gawangPlayerThree.transform.position.y, gawangPlayerThree.transform.position.z);
            GameOver();
        }
    }

    public void AddPlayerFourScore(int increment)
    {
        playerFourScore += increment;
        //ResetGame();

        if (playerFourScore >= maxScore)
        {
            deadPlayerCount += 1;
            playerFourPaddle.SetActive(false);
            gawangPlayerFour.isTrigger = false;
            gawangPlayerFour.gameObject.transform.position = new Vector3(-13, gawangPlayerFour.transform.position.y, gawangPlayerFour.transform.position.z);
            GameOver();
        }
    }

    public void GameOver()
    {
        if (deadPlayerCount < 2)
        {
            return;
        }
        else
        {
            gameOverCanvas.SetActive(true);
            if (playerOneScore < 15)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerOnePaddle.tag);
            }
            else if (playerTwoScore < 15)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerTwoPaddle.tag);
            }
            else if (playerThreeScore < 15)
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerThreePaddle.tag);
            }
            else
            {
                gameOverCanvas.GetComponent<GameOverController>().ShowWinner(playerFourPaddle.tag);
            }
            deadPlayerCount = 0;
        }
        
    }

    public void ResetGame()
    {
        gameOverCanvas.SetActive(false);
        //ball.ResetBall();
        //ball.RandomBall();
        playerOnePaddle.GetComponent<PaddleController>().ResetPaddle();
        playerTwoPaddle.GetComponent<PaddleController>().ResetPaddle();
        playerThreePaddle.GetComponent<PaddleController>().ResetPaddle();
        playerFourPaddle.GetComponent<PaddleController>().ResetPaddle();
        playerOneScore = 0;
        playerTwoScore = 0;
        playerThreeScore = 0;
        playerFourScore = 0;
    }
}
