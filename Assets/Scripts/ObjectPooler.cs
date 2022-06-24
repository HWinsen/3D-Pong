using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<GameObject> pooledObjects;
    public AssetReference ball;
    public int amountToPool;

    // Start is called before the first frame update
    void Start()
    {
        Addressables.InitializeAsync();

        pooledObjects = new List<GameObject>();
        
        for (int i = 0; i < amountToPool; i++)
        {
            ball.InstantiateAsync().Completed += (newBall) =>
            {
                GameObject obj = newBall.Result;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            };
        }

    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

}

