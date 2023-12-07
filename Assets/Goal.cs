using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject nextSpawn;
    [SerializeField] GameObject gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = nextSpawn.transform.position;
            gameManager.GetComponent<GameManager>().NextStage();
        }
    }
}
