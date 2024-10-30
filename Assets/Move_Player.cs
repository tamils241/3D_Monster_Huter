using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Move_Player : MonoBehaviour
{
  // Reference to the CharacterController component
    private CharacterController characterController;

    // Movement speed
    public float walkSpeed = 9.0f;
    public float runSpeed = 15.0f;

    // Jumping variables
    public float jumpHeight = 2.0f;
    private float gravity = -9.81f;
    private float verticalVelocity;

    // Camera rotation
    public Transform cameraTransform;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    // Ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
     // Reference to the Animator component
    public Animator animator;
    //bool IsAttack;
    public Transform enemy; // The enemy to attack, assign it in the Inspector or find it dynamically
    public float rotationSpeed = 5f; // Speed of rotation to face the enemy
    public AudioSource Audio;
    public AudioClip Attack_Sound;
    // score 
    private int Score = 0;
    public TMP_Text Score_text; 

    

    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component attached to the player
        characterController = GetComponent<CharacterController>();
        // Get the Animator component attached to the character
        //animator = GetComponent<Animator>();
       // IsAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // Slight downward force to stick to the ground
        }

        // Get input for movement
        float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow
        float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down arrow

        // Calculate the movement direction relative to the camera
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        // Apply movement
        if (direction.magnitude >= 0.1f)
        {
            // Calculate target angle for character rotation
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            // Rotate the character towards the target angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Calculate move direction based on target angle
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply move direction
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed; // Use Left Shift to run
            characterController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Apply gravity
        verticalVelocity += gravity * Time.deltaTime;

        // Apply jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
              animator.SetTrigger("IsJumping");
        }

        // Apply vertical movement
        Vector3 verticalMove = new Vector3(0, verticalVelocity, 0);
        characterController.Move(verticalMove * Time.deltaTime);

         // Check if there's any input in horizontal or vertical axes
        if (horizontal != 0 || vertical != 0)
        {
            // If the character is moving, set the Walk parameter to true
            animator.SetBool("Walk", true);
        }
        else
        {
            // If no movement input, set the Walk parameter to false
            animator.SetBool("Walk", false);
        }
        
         // Attack button function
        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Audio.PlayOneShot(Attack_Sound);
            LookAtEnemy(); // Make the player face the enemy
           // IsAttack = true;
        }
        //else if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape))
        //{
          //animator.SetTrigger("Pick_Up");
        //}
    } 

     void LookAtEnemy()
    {
        if (enemy != null)
        {
            // Calculate the direction to the enemy
            Vector3 directionToEnemy = (enemy.position - transform.position).normalized;

            // Ignore Y-axis for horizontal rotation
            directionToEnemy.y = 0;

            // Calculate the rotation needed to face the enemy
            Quaternion lookRotation = Quaternion.LookRotation(directionToEnemy);

            // Smoothly rotate towards the enemy
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            Debug.LogError("Enemy not assigned in PlayerAttack script.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Daimin"))
        {
            animator.SetTrigger("Pick_Up");
            Destroy(other.gameObject,0.5f);
            Score ++;
            Score_text.text = "Score :" + Score;
        }
    }

}