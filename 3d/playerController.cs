using UnityEngine;

public class playerController : MonoBehaviour
{

    CharacterController playerController;
    float inputX, inputZ, jumpSpeed, gravity, moveSpeed;
    Animator anim;
    private Vector3 direction;

    void Start()
    {
        moveSpeed = 5;
        gravity = 1;
        jumpSpeed = 55;
        anim = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        direction = new Vector3(inputX, 0, inputZ);

        if (playerController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = jumpSpeed;
            }
            anim.SetBool("isJumping", false);
        }
        if (gameObject.transform.position.y > 1)
        {
            anim.SetBool("isJumping", true);
        }

        if (inputX != 0 || inputZ != 0)
        {
            anim.SetBool("isRunning", true);            
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShooting", true);
        }
        else
        {
            anim.SetBool("isShooting", false);
        }

        direction.y -= gravity;
        playerController.Move(direction * Time.deltaTime * moveSpeed);
    }
}
