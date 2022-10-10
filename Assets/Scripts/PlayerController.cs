using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;
    public float moveSpeed;
    public float jumpForce;

    public Animator animator;

    private Rigidbody2D rd;

    bool isJump;
    bool canDoubleJump;

    void Awake()
    {
        isJump = false;
        canDoubleJump = false;
        animator = GetComponent<Animator>();
    }
    void Start()
    {      
        rd = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {

        Move();
        if (Input.GetKeyDown(KeyCode.Space) && !isJump)
        {
            Jump();
            animator.SetBool("isGround", false);
            animator.SetBool("isJump", true);
            canDoubleJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isJump && canDoubleJump)
        {
            animator.SetBool("isGround", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isDoubleJump", true);
            Jump();      
            canDoubleJump = false;
        }
        
    }
    void Move()
    {
        Vector3 v = Vector2.right;
        transform.position += moveSpeed * Time.deltaTime * v;
    }

    void Jump()
    {
        isJump = true;
        rd.velocity = new Vector2(rd.velocity.x, 0f);
        rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "map")
        {
            animator.SetBool("isJump", false);
            animator.SetBool("isDoubleJump", false);
            animator.SetBool("isGround", true);
            isJump = false;
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            bool isJelly = collision.gameObject.name.Contains("item1");
            bool isYellow = collision.gameObject.name.Contains("item2");
            bool isPink = collision.gameObject.name.Contains("item3");

            if (isJelly)
                gameManager.stagePoint += 50;
            else if (isYellow)
                gameManager.stagePoint += 100;
            else if (isPink)
                gameManager.stagePoint += 300;

            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag == "Finish")
        {
            gameManager.NextStage();
        }

        if (collision.gameObject.tag == "blank")
        {
            gameManager.Restart();
        }

        if (collision.gameObject.tag == "spike")
        {
            gameManager.Restart();
        }
    }
    public void VelocityZero()
    {
        rd.velocity = Vector2.zero;
    }
}
