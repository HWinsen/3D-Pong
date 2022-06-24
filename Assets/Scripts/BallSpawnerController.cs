using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    [SerializeField] private ObjectPooler objectPooler;
    [SerializeField] private GameObject ball;
    [SerializeField] private float ballSpawnInterval;

    public int counter = 0;
    private List<Vector3> spawnerPositionList;
    
    private int randomSpawnPosition;
    private float ballSpawnTimer;
    

    private void Start()
    {
        ballSpawnTimer = 0f;
        objectPooler = ObjectPooler.Instance;
        spawnerPositionList = new List<Vector3>
        {
            new Vector3(-13, 3, 13),
            new Vector3(13, 3, 13),
            new Vector3(-13, 3, -13),
            new Vector3(13, 3, -13)
        };
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (counter <= 4)
        {
            randomSpawnPosition = Random.Range(0, spawnerPositionList.Count);
            Debug.Log("Counter: " + counter);
            ballSpawnTimer += Time.deltaTime;

            if (ballSpawnTimer >= ballSpawnInterval)
            {
                //objectPooler.SpawnFromPool(counter, spawnerPositionList[randomSpawnPosition], Quaternion.identity);
                ball = ObjectPooler.Instance.GetPooledObject();
                if (ball != null)
                {
                    ball.transform.position = spawnerPositionList[randomSpawnPosition];
                    ball.transform.rotation = Quaternion.identity;
                    ball.SetActive(true);
                    if (ball.GetComponent<BallController>().spawned)
                    {
                        ball.GetComponent<BallController>().ResetBall();
                    }
                }
                //ball.GetComponent<BallController>().ResetBall();
                ballSpawnTimer = 0f;
                counter += 1;
                if (counter > 4)
                {
                    counter = 0;
                }
            }
        }
    }

}
