using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpingHeight;
    [SerializeField] float raycastDistance;
    [SerializeField] float AirborneSpeedDivisor;

    Vector3 vettoreMovimento = new Vector3(0, 0, 0);
    Vector3 drag;
    Rigidbody rb;
    bool isMoving;
    bool isAirborne;
    bool jump;
    
    Vector3 jumpingForce;
    // Start is called before the first frame update
    void Start()
    {
        jumpingForce = new Vector3(0,jumpingHeight,0);
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckForGround();
        isMoving = false;
        
        if (Input.GetKey(KeyCode.A))
        {
            vettoreMovimento.x -= speed * Time.deltaTime;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            vettoreMovimento.x += speed * Time.deltaTime;
            isMoving = true;
        }
        if ((Input .GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !isAirborne)
        {
            jump=true;
        }


    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            
            if (Mathf.Abs(rb.velocity.x) < maxSpeed)
            {
                if (!isAirborne)
                {
                    rb.velocity += vettoreMovimento;
                }
                else
                {
                    rb.velocity += vettoreMovimento / AirborneSpeedDivisor;
                }
            }        
        }
        else
        {

            drag = new Vector3(rb.velocity.x / 4f, 0, 0);
            rb.velocity -= drag; 
        }
        Jump();

        vettoreMovimento = Vector3.zero;
    }
    void Jump()
    {
        if (jump)
        {
            rb.AddForce(jumpingForce, ForceMode.Impulse);
            jump = false;
        }
    }
    void CheckForGround()
    {
        // Assuming you want to cast the ray from the object's position downward
        Ray ray = new Ray(transform.position, Vector3.down);
        isAirborne = true;
        // Check if the ray hits something
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            // Check if the hit object has the specified tag
            if (hit.collider.CompareTag("Ground"))
            {
                isAirborne = false;
            }
        }
       
            

    }
    void Explode()
    {

    }
}
