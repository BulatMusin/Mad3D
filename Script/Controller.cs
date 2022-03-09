using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]

public class Controller : MonoBehaviour
{
    
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public AudioClip pickupSound;
    public FlashScreen flash;

    //Leg Kick Shit
    public LayerMask whatIsEnemy;
    public float attackRange;
    public  Rigidbody m_Rigidbody;
    private float m_Thrust = 20f;
    
    private bool hasKicked , enemyInAttackRange;
   

    CharacterController characterController;
    AudioSource source;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        source = GetComponent<AudioSource>();
        m_Rigidbody = GetComponent<Rigidbody>();
       
    }

    void Update()
    {   enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange,whatIsEnemy);
        if(Input.GetKeyDown(KeyCode.R) &&enemyInAttackRange )
        {
        m_Rigidbody.AddForce(-transform.forward * m_Thrust);

        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
  /*  void OnTriggerEnter (Collider other)
{
  if(other.CompareTag("HovaBonus"))
  {
   GetComponent<PlayerHealth>().AddHealth(20);
  }
  else if(other.CompareTag("Armor"))
  {
  GetComponent<PlayerHealth>().AddArmor(25);
  }
  else if(other.CompareTag("AmmoSawed"))
  {
      transform.Find("Weapons").Find("Sawed").GetComponent<Sawed>().AddAmmo(5);
  }
  if(other.CompareTag("HpBonus") || other.CompareTag("ArmorBonus") || other.CompareTag("AmmoBonus"))
  {   flash.PickedUpBonus();  
      source.PlayOneShot(pickupSound);
      Destroy(other.gameObject);
  }
}
}
*/