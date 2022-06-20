using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    private Transform spawnArea;
    [SerializeField] private PaddleController leftPaddle;
    [SerializeField] private PaddleController rightPaddle;
    [SerializeField] private int maxPowerUpAmount;
    [SerializeField] private int spawnInterval;
    [SerializeField] private int removeInterval;
    [SerializeField] private int longPaddleInterval;
    [SerializeField] private int fastPaddleInterval;
    [SerializeField] private Vector2 powerUpAreaMin;
    [SerializeField] private Vector2 powerUpAreaMax;

    private List<GameObject> powerUpList;
    [SerializeField] private List<GameObject> powerUpTemplateList;

    private bool leftLongPaddleState = false;
    private bool rightLongPaddleState = false;
    private bool leftFastPaddleState = false;
    private bool rightFastPaddleState = false;

    private float spawnTimer;
    private float leftLongPaddleTimer;
    private float rightLongPaddleTimer;
    private float leftFastPaddleTimer;
    private float rightFastPaddleTimer;
    private float removeTimer;

    void Start()
    {
        powerUpList = new List<GameObject>();
        spawnTimer = 0;
        leftLongPaddleTimer = 0;
        rightLongPaddleTimer = 0;
        leftFastPaddleTimer = 0;
        rightFastPaddleTimer = 0;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnInterval)
        {
            GenerateRandomPowerUp();
            spawnTimer -= spawnInterval;
        }

        if (powerUpList.Count > 0)
        {
            removeTimer += Time.deltaTime;

            if (removeTimer > removeInterval)
            {
                RemovePowerUp(powerUpList[0]);
                removeTimer -= removeInterval;
            }
        }

        if (leftLongPaddleState)
        {
            leftLongPaddleTimer += Time.deltaTime;

            if (leftLongPaddleTimer >= longPaddleInterval)
            {
                leftPaddle.GetComponent<PaddleController>().DeactivatePULongPaddle();
                leftLongPaddleTimer -= longPaddleInterval;
                leftLongPaddleState = false;
            }
        }

        if (rightLongPaddleState)
        {
            rightLongPaddleTimer += Time.deltaTime;

            if (rightLongPaddleTimer >= longPaddleInterval)
            {
                rightPaddle.GetComponent<PaddleController>().DeactivatePULongPaddle();
                rightLongPaddleTimer -= longPaddleInterval;
                rightLongPaddleState = false;
            }
        }

        if (leftFastPaddleState)
        {
            leftFastPaddleTimer += Time.deltaTime;

            if (leftFastPaddleTimer >= fastPaddleInterval)
            {
                leftPaddle.GetComponent<PaddleController>().DeactivatePUFastPaddle();
                leftFastPaddleTimer -= fastPaddleInterval;
                leftFastPaddleState = false;
            }
        }

        if (rightFastPaddleState)
        {
            rightFastPaddleTimer += Time.deltaTime;

            if (rightFastPaddleTimer >= fastPaddleInterval)
            {
                rightPaddle.GetComponent<PaddleController>().DeactivatePUFastPaddle();
                rightFastPaddleTimer -= fastPaddleInterval;
                rightFastPaddleState = false;
            }
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if(position.x < powerUpAreaMin.x ||
           position.x > powerUpAreaMax.x ||
           position.y < powerUpAreaMin.y ||
           position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        while (powerUpList.Count > 0) {
            RemovePowerUp(powerUpList[0]);
        }
    }

    public void ResetTimer()
    {
        spawnTimer = 0;
        removeTimer = 0;
        leftLongPaddleTimer = 0;
        rightLongPaddleTimer = 0;
        leftFastPaddleTimer = 0;
        rightFastPaddleTimer = 0;
    }

    public void ResetPUState()
    {
        leftLongPaddleState = false;
        rightLongPaddleState = false;
        leftPaddle.GetComponent<PaddleController>().DeactivatePULongPaddle();
        rightPaddle.GetComponent<PaddleController>().DeactivatePULongPaddle();
        
        leftFastPaddleState = false;
        rightFastPaddleState = false;
        leftPaddle.GetComponent<PaddleController>().DeactivatePUFastPaddle();
        rightPaddle.GetComponent<PaddleController>().DeactivatePUFastPaddle();
    }

    public void UpdateLongPaddleState(string lastPaddleHit)
    {
        
        if (lastPaddleHit == "PaddleKiri")
        {
            leftLongPaddleState = true;
        }
        else
        {
            rightLongPaddleState = true;
        }
    }

    public void UpdateFastPaddleState(string lastPaddleHit)
    {

        if (lastPaddleHit == "PaddleKiri")
        {
            leftFastPaddleState = true;
        }
        else
        {
            rightFastPaddleState = true;
        }
    }
}
