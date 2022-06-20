using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFastPaddleController : MonoBehaviour
{
    [SerializeField] private PowerUpManager manager;
    [SerializeField] private Collider2D ball;
    [SerializeField] private int magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string lastPaddleHit = ball.GetComponent<BallController>().lastPaddleHit;

        if (collision == ball)
        {
            GameObject.Find(lastPaddleHit).GetComponent<PaddleController>().ActivatePUFastPaddle(magnitude);
            manager.UpdateFastPaddleState(lastPaddleHit);
            manager.RemovePowerUp(gameObject);
        }
    }
}
