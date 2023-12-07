using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slope : MonoBehaviour
{
    [SerializeField] float SlidingMult;
    [SerializeField] float MaxSpeed;
    Rigidbody rb;
    bool bIsSliding;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            bIsSliding = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bIsSliding = false;
        }
    }
    private void FixedUpdate()
    {
        if (bIsSliding)
        {
            if (rb.velocity.magnitude < MaxSpeed)
            {
                rb.velocity *= SlidingMult;
            }
            else
            {

            }
        }
    }
}
