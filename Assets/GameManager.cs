using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject UI;
    [SerializeField] float staminaConsuption;
    [SerializeField] GameObject Menu;
    bool isMenuOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && UI.transform.localScale.x > 0)
        {
            //Debug.Log(UI.transform.localScale);
            Vector3 scale = new Vector3(UI.transform.localScale.x - staminaConsuption, UI.transform.localScale.y, UI.transform.localScale.z);
            UI.transform.localScale = scale;
        }
        else if(UI.transform.localScale.x < 1)
        {
            Vector3 scale = new Vector3(UI.transform.localScale.x + staminaConsuption, UI.transform.localScale.y, UI.transform.localScale.z);
            UI.transform.localScale = scale;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuOpen = !isMenuOpen;
            Player.GetComponent<CharMovement>().IsMenuOpen();
            Menu.SetActive(isMenuOpen);
        }
    }
    public void SetAnimation()
    {
        Player.GetComponent<Animation>().Play();
    }
}