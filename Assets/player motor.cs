using JetBrains.Annotations;
using System.Collections;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Windows;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class playermotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2d;
    public float speed = 10;
    
    public float jumpForce = 3;
    private bool canJump = true;
    public int maxJump = 2;
    private int currentJumps;

    public float maxSpeed = 5;
    
    public float stoppingForce = 5;

    public float dashForce = 30;
    private bool canDash = true;

    private Animator animator;
    private float initScale;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initScale = transform.localScale.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        animator.SetFloat("SpeedY", rigidbody2d.linearVelocityY);
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(initScale, transform.localScale.y, transform.localScale.x);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-initScale, transform.localScale.y, transform.localScale.x);
        }
        MaxSpeed();
        StoppingForce();
    }

    private void MaxSpeed()
    {
        if ((!canDash))
        {
            return;
        }
        if (rigidbody2d.linearVelocityX >= maxSpeed)
        {
            rigidbody2d.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2d.linearVelocityX <= -maxSpeed)
        {
            rigidbody2d.linearVelocityX = -maxSpeed;
        }
    }

    private void StoppingForce()
    {
        if (direction.x != 0)
        {
            rigidbody2d.AddForce(new Vector2(direction.x * speed, 0));
            animator.SetBool("IsMoving", true);
        }
        else if (rigidbody2d.linearVelocityX != 0)
        {
            rigidbody2d.AddForce(new Vector2(-rigidbody2d.linearVelocityX * stoppingForce, 0));
        }

        if (direction.x == 0)
        {
            animator.SetBool("IsMoving", false);
        }
    }
    

    void OnMove(InputValue value)
    {
        //Debug.Log("Move");
        //Debug.Log(value.Get<Vector2>());
        direction = value.Get<Vector2>();

    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            currentJumps++;
            if(currentJumps >= maxJump)
            {
                canJump = false;
            }
        }
    }

    private void OnDash()
    {
        if (canDash)
        {
            if(direction.x != 0)
            {
                rigidbody2d.AddForce(new Vector2(direction.x * dashForce, 0), ForceMode2D.Impulse);
            }
            else
            {
                rigidbody2d.AddForce(new Vector2(dashForce, 0), ForceMode2D.Impulse);
            }
            //Debug.Log("Dashing");
            canDash = false;
            StartCoroutine(ResetDash(1));
        }
    }

    IEnumerator ResetDash(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canDash = true;
    }
        

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        currentJumps = 0;

    }

}
