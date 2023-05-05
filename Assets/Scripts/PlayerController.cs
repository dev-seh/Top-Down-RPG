using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(movementInput != Vector2.zero){
            int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if(count == 0){
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
            
            animator.SetBool("isMoving", true);

        }
        else{
            animator.SetBool("isMoving", false);
        }

        //set direction of sprite to movement direction
        if(movementInput.x < 0){
            spriteRenderer.flipX = true;
        }
        else if (movementInput.x > 0){
            spriteRenderer.flipX = false;
        }
        
    }

    void OnMove(InputValue movementValue){
        movementInput = movementValue.Get<Vector2>();
    }
}
