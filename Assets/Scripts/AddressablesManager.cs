using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AddressablesManager : MonoBehaviour
{
    public AssetReference ballReference;
    [SerializeField] private GoalController gawangPlayerOne;
    [SerializeField] private GoalController gawangPlayerTwo;
    [SerializeField] private GoalController gawangPlayerThree;
    [SerializeField] private GoalController gawangPlayerFour;
    [SerializeField] private ObjectPooler objectPooler;

    private void Start()
    {
        //Addressables.InitializeAsync().Completed += AddressablesManager_Completed =>
        //{
        //    Debug.Log("Test");
        //    //ballReference.LoadAssetAsync<GameObject>();
        //    ballReference.InstantiateAsync();
        //};

        Addressables.InitializeAsync();
        //ballReference.InstantiateAsync();
        
    }

    public void SpawnBallAsync()
    {
        ballReference.InstantiateAsync().Completed += (newBall) =>
        {
            gawangPlayerOne.ball = newBall.Result.GetComponent<SphereCollider>();
            gawangPlayerTwo.ball = newBall.Result.GetComponent<SphereCollider>();
            gawangPlayerThree.ball = newBall.Result.GetComponent<SphereCollider>();
            gawangPlayerFour.ball = newBall.Result.GetComponent<SphereCollider>();
            //objectPooler.ball = newBall.Result;
        };
    }
}
