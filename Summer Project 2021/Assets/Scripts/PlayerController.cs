using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variable Declarations
    private float speed = 2.0f;
    private float jumpForce = 5.0f;
    private bool canClimb;
    [SerializeField] bool canJump;
    private Rigidbody2D rb;
    #endregion

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.W) && canClimb)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S) && canClimb)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    #region Collisions and Triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder")) //&& collision.gameObject.isClimbable)
        {
            Ladder ladder = collision.gameObject.GetComponent<Ladder>();
            if (ladder.isClimbable)
            {
                canClimb = true;
                rb.gravityScale = 0.0f;
                rb.velocity = Vector3.zero;//Abstract into ClimbingEnabled?
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
            rb.gravityScale = 1.0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }
    #endregion

    #region Projectile Management
    private void FireProjectile()
    {

    }

    private void SwapProjectile()
    {

    }
    #endregion
}
