using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour, IPooledObject
{
    [SerializeField] private Vector3 speed;
    private Rigidbody rig;
    [SerializeField] private Vector3 resetPosition;
    public string lastPaddleHit;

    public void OnObjectSpawn()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(Random.Range(-1f, -0.5f) * transform.position.x, transform.position.y, Random.Range(-1f, -0.5f) * transform.position.z);
        
        rig = GetComponent<Rigidbody>();
        rig.velocity = speed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, transform.position.z);

        rig.velocity = speed;
    }

}
