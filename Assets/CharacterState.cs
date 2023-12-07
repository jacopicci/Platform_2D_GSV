using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterState : MonoBehaviour
{
    public bool bCanChangeState;
    bool bIsHeavyState;
    private Rigidbody rb;
    [SerializeField] public float additionalGravityLightState;
    [SerializeField] public float additionalGravityHeavyState; //Moltiplicatori per aumentare la gravità
    [SerializeField] public float speedMultiplierLightState;
    [SerializeField] public float speedMultiplierHeavyState;
    [SerializeField] Image img;
    [SerializeField] PhysicMaterial physicMat;
    CharMovement charMov;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        charMov = GetComponent<CharMovement>();
        LightState();
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
        if (bCanChangeState)
        {
            bIsHeavyState = !bIsHeavyState;
            if (!bIsHeavyState)
            {
                LightState();
            }
            else
            {
                HeavyState();
            }
        }
        
    }

    void LightState()
    {
        img.color = Color.yellow;
        physicMat.staticFriction = 0.5f;
        physicMat.dynamicFriction = 0.5f;
        charMov.setSpeedMultiplier(speedMultiplierLightState);
        //Ripristina la gravità originale
    }

    void HeavyState()
    {
        img.color = Color.red;
        physicMat.staticFriction = 0.0f;
        physicMat.dynamicFriction = 0.0f;
        charMov.setSpeedMultiplier(speedMultiplierHeavyState);

        //La gravità viene sostituita da un vettore che ha come y la gravità originale moltiplicata


        //quando diventa pesante diminuisce attrito del collider
        //quando è in aria switch di stato comporta forza verticale aggiuntiva
    }
    private void FixedUpdate()
    {
        if (bIsHeavyState)
        {
            rb.AddForce(new Vector3(0, -additionalGravityHeavyState * rb.mass, 0));
        }
        else
        {
            rb.AddForce(new Vector3(0, - additionalGravityLightState * rb.mass, 0));

        }
    }
    public void SetLightState()
    {
        bIsHeavyState = false;
        LightState();
    }
    public void SetHeavyState()
    {
        bIsHeavyState = true;
        HeavyState();
    }
    public bool GetIsHeavyState()
    {
        return bIsHeavyState;
    }

}



