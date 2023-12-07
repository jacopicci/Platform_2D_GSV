using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float jumpingHeight;
    [SerializeField] public float raycastDistance;
    [SerializeField] public float AirborneSpeedDivisor;
    [SerializeField] public float verticalWallJumpForce = 5f; // This value represents the force applied upwards
    [SerializeField] public float horizontalWallJumpForce = 2f; // This value represents the force applied sideways
    [SerializeField] public float speedThreshold;
    [SerializeField] public float groundPoundBaseSpeed;

    Vector3 vettoreMovimento = new Vector3(0, 0, 0);
    Vector3 drag;
    Rigidbody rb;
    CharacterState charState;
    private float SpeedMultiplier = 1;
    bool bCanGroundPound;
    bool isMoving;
    bool isAirborne;
    bool jump;
    bool groundPound;
    bool destroy;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        charState = GetComponent<CharacterState>();
    }

    void Update()
    {
        CheckForGround();
        isMoving = false;
        if (rb.velocity.x > speedThreshold || rb.velocity.y > speedThreshold)
        {
            destroy = true;
        }
        if (Input.GetKey(KeyCode.A) && isAirborne)
        {
            vettoreMovimento.x -= speed * SpeedMultiplier * Time.deltaTime * 2;
            isMoving = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            vettoreMovimento.x -= speed * SpeedMultiplier * Time.deltaTime;
            isMoving = true;
        }

        if (Input.GetKey(KeyCode.D) && isAirborne)
        {
            vettoreMovimento.x += speed * SpeedMultiplier * Time.deltaTime * 2;
            isMoving = true;
        }
        if (Input.GetKeyDown(KeyCode.S) && isAirborne)
        {
            groundPound = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            vettoreMovimento.x += speed * SpeedMultiplier * Time.deltaTime;
            isMoving = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && !isAirborne)
        {
            jump = true;
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
        GroundPounding();
        Jump();
        
        vettoreMovimento = Vector3.zero;
    }
    void GroundPounding()
    {
        if (groundPound && charState.GetIsHeavyState() && bCanGroundPound)
        {
            Debug.Log("Works");
            rb.AddForce(Vector3.down * groundPoundBaseSpeed * rb.mass, ForceMode.Impulse);
            groundPound = false;
        }
    }
    void Jump()
    {
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingHeight);
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
                bCanGroundPound = true;
            }
        }
    }
    public void WallJumping(bool isRight)
    {
        Vector3 jumpVector;
            if (isRight)
        {
            jumpVector = new Vector3(horizontalWallJumpForce, verticalWallJumpForce, 0);
        }
        else
        {
            jumpVector = new Vector3(-horizontalWallJumpForce, verticalWallJumpForce, 0);
        }

        // Apply the force to the player's Rigidbody
        rb.AddForce(jumpVector * rb.mass, ForceMode.Impulse);

        // Ensure the player cannot wall jump again until conditions are met
    }

    public void setSpeedMultiplier(float speedMult)
    {
        SpeedMultiplier = speedMult;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Destroyable") && destroy)
        {
            Destroy(collision.gameObject);
        }
    }
}
