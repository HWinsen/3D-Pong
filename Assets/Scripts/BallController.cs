using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector2 speed;
    private Rigidbody2D rig;
    [SerializeField] private Vector2 resetPosition;
    public string lastPaddleHit;

    private void Awake()
    {
        RandomBall();
    }

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }

    public void RandomBall()
    {
        speed = new Vector2(5 * (Random.Range(0, 2) * 2 - 1), Random.Range(-2, 3));
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, transform.position.z);
        
        rig.velocity = speed;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PaddleKanan")
        {
            lastPaddleHit = "PaddleKanan";
        }
        else if (collision.gameObject.tag == "PaddleKiri")
        {
            lastPaddleHit = "PaddleKiri";
        }
    }
}
