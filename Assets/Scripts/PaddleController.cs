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
    private Vector3 defaultPosition;


    private Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        defaultPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
        //Debug.Log("Test: " + movement);
        rig.velocity = movement;
    }

    public void ResetPaddle()
    {
        transform.position = defaultPosition;
    }
}
