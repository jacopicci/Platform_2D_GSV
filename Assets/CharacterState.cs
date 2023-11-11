using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    bool isLightState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))              //<-Cambio di stato                                   
        {                                                     //Dopo questo dovrai scrivere il tuo codice per cambiarlo                                   
            changeState();                                    //Ti consiglio di creare due funzioni (come nell'esempio qui sotto), una per ogni stato                                  
        }                                                     //
    }                                                         //
    void changeState()                                        //Concept dalla riunione:
    {                                                         //Il protagonista dovrebbe diventare più lento, ma se prende velocità può distruggere alcuni oggetti
        isLightState = !isLightState;                         //inoltre dovrà essere anche più leggero, in modo da poter rimbalzare 
    }                                                         //aumentando l'altezza del salto cambiando forma in aria
}
