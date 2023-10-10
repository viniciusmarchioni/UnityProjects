using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float hp;
    public float maxHp = 100;
    public float moveSpeed;
    public Rigidbody2D rig2d;
    public float moveX;
    public float moveY;
    bool isMoving;
    Animator anim;
    Vector3 movementVector;
    public Image heart;
    public int enemiesDefeat = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        //Preencher o vetor de movimenta��o com os inputs dos eixos horizontal e vertical.
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        //Chama o m�todo Move
        Move();
        Animation();
        Attack();
        UpdateUI();

        if (hp <= 0)
        {
            SceneManager.LoadScene("SceneGameWin");
        }

        if (enemiesDefeat >= 13)
        {
            SceneManager.LoadScene("SceneGameOver");
        }
    }
    void UpdateUI()
    {
        heart.fillAmount = hp / maxHp;
    }

    void Move()
        {
           movementVector = new Vector3(moveX, moveY, 0);

           rig2d.MovePosition(transform.position + movementVector * Time.deltaTime * moveSpeed);
        }

    void Animation()
    {
        if (moveX == 0 && moveY == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        anim.SetBool("isMoving", isMoving);
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isAttack");
        }
    }

}
