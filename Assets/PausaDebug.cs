using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausaDebug : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject jumpPad_01;
    [SerializeField] GameObject jumpPad_02;
    bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
            menu.SetActive(isActive);
        }
    }



    public void ChangeGravity(String gravity)
    {
        float parsedGravity;
        if (float.TryParse(gravity, out parsedGravity))
        {
            Physics.gravity = new Vector3(0, -parsedGravity, 0);
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + gravity);
        }
    }

    public void ChangeSpeed(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().speed = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeMaxSpeed(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().maxSpeed = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeJumpingHeight(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().jumpingHeight = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeAirborneDivisor(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().AirborneSpeedDivisor = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void WallJumpX(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().horizontalWallJumpForce = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void WallJumpY(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().verticalWallJumpForce = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void DestroySpeedThreshold(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().speedThreshold = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangegroundPoundBaseSpeed(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharMovement>().groundPoundBaseSpeed = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeGravityLight(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharacterState>().additionalGravityLightState = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeGravityHeavy(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharacterState>().additionalGravityHeavyState = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangespeedMultiplierLightState(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharacterState>().speedMultiplierLightState = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangespeedMultiplierHeavyState(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            player.GetComponent<CharacterState>().speedMultiplierHeavyState = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeBouncePad01(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            jumpPad_01.GetComponentInChildren<JumpPad>().padBounciness = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }
    public void ChangeBouncePad02(String value)
    {
        float parsedValue;
        if (float.TryParse(value, out parsedValue))
        {
            jumpPad_02.GetComponentInChildren<JumpPad>().padBounciness = parsedValue;
        }
        else
        {
            Debug.LogError("Invalid gravity input: " + value);
        }
    }


}
