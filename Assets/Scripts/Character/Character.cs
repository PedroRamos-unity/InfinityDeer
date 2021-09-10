using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{   
    public Guns EquipedWeapon;

    [SerializeField] private Camera cam;

    
    private Animator anim;

    private float gravity = -9.81f;
    private Vector3 velocity;
    private Vector3 moveDir;
    [HideInInspector]public float defaultSpeed ;
    [SerializeField]private float speed;
    [SerializeField]private float runningSpeed;
    [SerializeField]private float jumpHeight;
    private float horizontal, vertical;
    private bool jumping, running, aiming;

    private CharacterController characterController;

    private void Awake()
    {
        DataBank.PlayerCurrentScore = 0;
        defaultSpeed = 3.5f;
        speed = defaultSpeed;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }

    void Update()
    {
        //Movement and animations
        IsGrounded();
        
        if(Input.GetKeyDown(KeyCode.P))
        {
            Enemy enemy = FindObjectOfType<Enemy>();
            enemy.Death();
        }

        MyInputs();

        Vector3 sideMoveScreen = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f) * Vector3.right;
        Vector3 forwardMoveScreen = Quaternion.Euler(0f, cam.transform.eulerAngles.y, 0f) * Vector3.forward;
        moveDir = sideMoveScreen * horizontal + forwardMoveScreen * vertical;

        Running();

        Animations();

        if (jumping && IsGrounded())
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

            if(running)
            {
                anim.CrossFade("JumpAndRun", 0.1f);
            }

            else
            {
                anim.CrossFade("Jump", 0.1f);
            }
            
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    private void Running()
    {
        if (!running)
        {
            characterController.Move(moveDir * speed * Time.deltaTime);
        }

        else
        {
            characterController.Move(moveDir * runningSpeed * Time.deltaTime);
        }
    }

    private void Animations()
    {
        Vector3 horizontalSpeed = new Vector3(characterController.velocity.x, 0, characterController.velocity.z);
        anim.SetFloat("Speed", horizontalSpeed.magnitude);
        anim.SetBool("Aim", aiming);
    }

    private void MyInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        jumping = Input.GetButtonDown("Jump");
        running = Input.GetKey(KeyCode.LeftShift);

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Actions.DisplayPauseMenu();
        }

        //Gun related
        aiming = Input.GetButton("Fire2") && EquipedWeapon != null;
        Actions.Aim(aiming);

        
        
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed; 
    }

    private bool IsGrounded()
    {
        
        return Physics.Raycast(transform.position, Vector3.down, 0.6f, 1 << 12);
    }

}
