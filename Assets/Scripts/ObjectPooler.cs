using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GoalController gawangPlayerOne;
    [SerializeField] private GoalController gawangPlayerTwo;
    [SerializeField] private GoalController gawangPlayerThree;
    [SerializeField] private GoalController gawangPlayerFour;

    [System.Serializable]
    public class Pool
    {
        public int key;
        public AssetReference ball;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<int, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync();

        poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in pools)
        for (int i = 0; i < pool.size; i++)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            pool.ball.InstantiateAsync().Completed += (newBall) =>
            {
                GameObject obj = newBall.Result;
                gawangPlayerOne.ball = newBall.Result.GetComponent<SphereCollider>();
                gawangPlayerTwo.ball = newBall.Result.GetComponent<SphereCollider>();
                gawangPlayerThree.ball = newBall.Result.GetComponent<SphereCollider>();
                gawangPlayerFour.ball = newBall.Result.GetComponent<SphereCollider>();
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            };

            poolDictionary.Add(i, objectPool);
        }
    }

    public GameObject SpawnFromPool (int counter, Vector3 position, Quaternion rotation)
    {

        GameObject objectToSpawn = poolDictionary[counter].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        //IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();

        //if (pooledObject != null)
        //{
        //    pooledObject.OnObjectSpawn();
        //}

        //poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

}

