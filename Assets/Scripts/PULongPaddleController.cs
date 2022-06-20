using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongPaddleController : MonoBehaviour
{
    [SerializeField] private PowerUpManager manager;
    [SerializeField] private Collider2D ball;
    [SerializeField] private float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string lastPaddleHit = ball.GetComponent<BallController>().lastPaddleHit;

        if (collision == ball)
        {
            GameObject.Find(lastPaddleHit).GetComponent<PaddleController>().ActivatePULongPaddle(magnitude);
            manager.UpdateLongPaddleState(lastPaddleHit);
            manager.RemovePowerUp(gameObject);
        }
    }

}
