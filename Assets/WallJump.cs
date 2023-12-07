using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    CharMovement charMov;
    bool isCollidingWithPlayer = false;
    bool isRight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            charMov = other.gameObject.GetComponent<CharMovement>();
            if (other.gameObject.GetComponent<Rigidbody>().velocity.x < 0)
            {
                isRight = true;
            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
        }
    }

    private void Update()
    {
        if (isCollidingWithPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(isRight);
            charMov.WallJumping(isRight);
        }
    }
}