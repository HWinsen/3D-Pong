using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    //[SerializeField] private GameObject topContainer;
    //[SerializeField] private GameObject bottomContainer;
    private Vector3 defaultScale;
    private Vector3 defaultPosition;
    private int defaultSpeed;

    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        defaultScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        defaultSpeed = speed;
    }

    private void Update()
    {
        MoveObject(GetInput());
    }

    private Vector3 GetInput()
    {
        // Get input.
        if (Input.GetKey(leftKey))
        {
            return Vector3.left * speed;
        }
        else if (Input.GetKey(rightKey))
        {
            return Vector3.right * speed;
        }
        else if (Input.GetKey(upKey))
        {
            return Vector3.forward * speed;
        }
        else if (Input.GetKey(downKey))
        {
            return Vector3.back * speed;
        }

        return Vector3.zero;
    }

    private void MoveObject(Vector3 movement)
    {
        Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    public void ResetPaddle()
    {
        transform.position = defaultPosition;
    }

    //public void SpawnUnderTopContainer()
    //{
    //    transform.position = new Vector3(transform.position.x, topContainer.transform.position.y - topContainer.transform.localScale.y - 1, transform.position.z);
    //}

    //public void SpawnAboveBottomContainer()
    //{
    //    transform.position = new Vector3(transform.position.x, bottomContainer.transform.position.y + bottomContainer.transform.localScale.y + 1, transform.position.z);
    //}

    public void ActivatePULongPaddle(float magnitude)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * magnitude, transform.localScale.z);
    }

    public void DeactivatePULongPaddle()
    {
        transform.localScale = defaultScale;
    }

    public void ActivatePUFastPaddle(int magnitude)
    {
        speed *= magnitude;
    }

    public void DeactivatePUFastPaddle()
    {
        speed = defaultSpeed;
    }
}
