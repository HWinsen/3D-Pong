using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerController : MonoBehaviour
{
    ObjectPooler objectPooler;

    [SerializeField] private GameObject ball;
    [SerializeField] private float ballSpawnInterval;

    private int counter = 0;
    private List<Vector3> spawnerPositionList;
    private int randomSpawnPosition;
    private float ballSpawnTimer;
    

    private void Start()
    {
        ballSpawnTimer = 0f;
        objectPooler = ObjectPooler.Instance;
        spawnerPositionList = new List<Vector3>();
        spawnerPositionList.Add(new Vector3(-13, 3, 13));
        spawnerPositionList.Add(new Vector3(13, 3, 13));
        spawnerPositionList.Add(new Vector3(-13, 3, -13));
        spawnerPositionList.Add(new Vector3(13, 3, -13));
        print(spawnerPositionList);
    }

    // Update is called once per frame
    private void Update()
    {
        //if (objectPooler.poolDictionary.Count <= 5)
        if (counter <= 4)
        {
            randomSpawnPosition = Random.Range(0, spawnerPositionList.Count);

            ballSpawnTimer += Time.deltaTime;

            if (ballSpawnTimer >= ballSpawnInterval)
            {
                objectPooler.SpawnFromPool(counter, spawnerPositionList[randomSpawnPosition], Quaternion.identity);
                ballSpawnTimer = 0f;
                counter += 1;
            }
        }
    }

}
