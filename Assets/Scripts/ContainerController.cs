using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerController : MonoBehaviour
{
    [SerializeField] private Collider2D ball;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Collider2D leftPaddle;
    [SerializeField] private Collider2D rightPaddle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Mencegah terjadinya bug ketika Bola menembus tembok atas atau bawah.

        if (collision == ball)
        {
            Debug.Log("Ball Out of Bound");
            scoreManager.ResetGame();
        }


        // Membuat paddle bisa tembus tembok atas dan bawah.

        if (collision == leftPaddle)
        {
            Debug.Log("Left Paddle Out of Bound");
            if (gameObject.name == "TopContainer")
            {
                //leftPaddle.GetComponent<PaddleController>().SpawnAboveBottomContainer();
            }
            else if (gameObject.name == "BottomContainer")
            {
                //leftPaddle.GetComponent<PaddleController>().SpawnUnderTopContainer();
            }
        }
        else if (collision == rightPaddle)
        {
            Debug.Log("Right Paddle Out of Bound");
            if (gameObject.name == "TopContainer")
            {
                //rightPaddle.GetComponent<PaddleController>().SpawnAboveBottomContainer();
            }
            else if (gameObject.name == "BottomContainer")
            {
                //rightPaddle.GetComponent<PaddleController>().SpawnUnderTopContainer();
            }
        }
    }
}
