using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trrigger : MonoBehaviour
{
    [SerializeField] GameManager gm;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        gm.SetAnimation();
    }
}
