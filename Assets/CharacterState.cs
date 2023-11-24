using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{

    bool isLightState;
    private Rigidbody rb;
    private float originalGravity;
    
    //Moltiplicatore per aumentare la gravit�
    [SerializeField] float heavyGravityMultiplier = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ChangeState();
        }
    }

    void ChangeState()
    {
        isLightState = !isLightState;

        if (isLightState)
        {
            LightState();
        }
        else
        {
            HeavyState();
        }
    }

    void LightState()
    {
        //Ripristina la gravit� originale
        Physics.gravity = new Vector3(0, originalGravity, 0);

    }

    void HeavyState()
    {
        //La gravit� viene sostituita da un vettore che ha come y la gravit� originale moltiplicata
        Physics.gravity = new Vector3(0, originalGravity * heavyGravityMultiplier, 0);

        //quando diventa pesante diminuisce attrito del collider
        //quando � in aria switch di stato comporta forza verticale aggiuntiva
    }
}



