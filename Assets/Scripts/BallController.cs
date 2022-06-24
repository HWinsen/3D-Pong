using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Vector3 speed;
    private Rigidbody rig;
    public bool spawned = false;

    void Start()
    {   
        rig = GetComponent<Rigidbody>();
        ResetBall();
    }

    public void ResetBall()
    {
        speed = new Vector3(Random.Range(-1f, -0.5f) * transform.position.x, transform.position.y, Random.Range(-1f, -0.5f) * transform.position.z);
        rig.velocity = speed;
    }
}
