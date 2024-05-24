using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Set the controler of the player and the animator component
    private Animator playerAnim;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        //We get the animator component.
        playerAnim = GetComponent<Animator>();

    }
    
    //Set a few variable to controle the movement of the character.
    public float speed = 5f;
    public float horizontalInput;
    public float verticalInput;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Vector3 direction;
    

    // Update is called once per frame
    void Update()
    {
        //We first get the input entered by the user.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //Set the direction of the character depending of the inputs.
        direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        //It check if there is a movement necessary, if yes it will proceed to rotate the player smoothly if necessary and move it.
        if (direction.magnitude >= 0.1f ) 
        {
            //Calculation are made to know the target angle and the future angle of the character.
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            //Rotation of the character in the direction wanted.
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //We set the animation to make it walk and move the player object in the good direction.
            playerAnim.SetFloat("MoveSpeed", 1);
            controller.Move(direction * speed * Time.deltaTime);
            
        }
        else
        {
            //If the player isn't moving it set the animation to idle.
            playerAnim.SetFloat("MoveSpeed", 0);
        }
    }
}
