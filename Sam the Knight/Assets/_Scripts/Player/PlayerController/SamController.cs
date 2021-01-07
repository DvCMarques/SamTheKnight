using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class SamController : IPlayerController
{
    Sam sam;
    Animator animator;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;

    float movementSpeed = 1.5f;
    float jumpPower = 5.5f;

    public bool slashing { get; private set; }
    

    public SamController(Sam sam,Animator animator, Rigidbody2D rigidbody, SpriteRenderer spriteRenderer) {
        this.sam = sam;
        this.animator = animator;
        this.rigidbody = rigidbody;
        this.spriteRenderer = spriteRenderer;
        foreach(Slashing s in animator.GetBehaviours<Slashing>()) {
            s.AssignSamController(this);
        }
        slashing = false;
        

    }

    public void Attack() {
        if (sam.playerState == PlayerState.Dead)
            return;
        animator.SetTrigger("Slash");
        rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
        
    }

    public void Move(InputDir dir) {
        if (slashing || sam.playerState == PlayerState.Dead)
            return;

        animator.SetBool("Running",true);
        switch (dir) {
            case InputDir.Left:
                spriteRenderer.flipX = true;
                rigidbody.velocity = new Vector2(- movementSpeed, rigidbody.velocity.y);
                break;
            case InputDir.Right:
                spriteRenderer.flipX = false;
                rigidbody.velocity = new Vector2( movementSpeed, rigidbody.velocity.y);
                break;
            default:
                break;
        }
    }

    public void Jump() {
        if (sam.playerState == PlayerState.Dead)
            return;

        animator.SetTrigger("Jump");
        rigidbody.velocity += new Vector2(rigidbody.velocity.x, jumpPower);
    }
    
    public void Dead() {
        animator.SetTrigger("Dead");
        sam.Die();
    }

    public void StopMove() {
        animator.SetBool("Running", false);
        rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);
    }


    public void SlashEnd() {
        slashing = false;
    }

    public void SlashStart() {
        slashing = true;
    }
}