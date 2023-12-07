using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathbox : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject player;
    private Vector3 startingPos;

    private void Start()
    {
        startingPos = player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameManager.AddTentativo();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}