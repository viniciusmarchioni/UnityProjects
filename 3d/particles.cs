//SCRIPT DO PROJÉTIL
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{

    public CharacterController playerController;
    private float inputX;
    private float inputZ;
    Animator anim;
    private Vector3 direction;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    public GameObject FireBall;
    public Transform spawnFire;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        direction = new Vector3(inputX, 0, inputZ);
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }
            
        
        if (playerController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isJumping", true);
                direction.y = jumpSpeed;
            }
            else
            {
                anim.SetBool("isJumping", false);
            }
        }

        if (inputX != 0 || inputZ != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
       

        direction.y -= gravity;
        playerController.Move(direction * Time.deltaTime * moveSpeed);
    }
}

