using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("GroundMovement")]
    [Tooltip("Movement speed in tiles per second (1 tile = 1 meter)")]
    [SerializeField]
    private float speed = 0;

    [Header("AirMovement")]
    [Tooltip("The Upwards force the player jumps.")]
    [Range(0f, 1f)]
    [SerializeField]
    private float jumpForce = 0;

    private Rigidbody2D playerRigidbody;
    private bool isFacingRight = true;
    private bool isOnGround = true;
    new private Collider2D collider;
    private RaycastHit2D[] hits = new RaycastHit2D[1];
    private float groundDistanceCheck = 0.01f;
    private Animator animator;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);

        if ((isFacingRight && horizontalInput < 0) ||
            (!isFacingRight && horizontalInput > 0))
        {
            Flip();
        }

        //Jump Logic
        //Check for landing on the ground
        int numHits = collider.Cast(Vector2.down, hits, 0.1f);
        isOnGround = numHits > 0;
        //Debugging
        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        Vector2 rayDirection = Vector2.down * groundDistanceCheck;
        Debug.DrawRay(rayStart, rayDirection, Color.red, 1f);
        //Jump only if on the ground.
        bool isJumpPressed = Input.GetButtonDown("Jump");
        if (isJumpPressed && isOnGround)
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("Jump");

        }
        if (Input.GetKey(KeyCode.J))
        {
            animator.SetTrigger("attack");
        }

        // Update animator system
        animator.SetFloat("xSpeed", Mathf.Abs(playerRigidbody.velocity.x));
        animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
        animator.SetBool("isOnGround", isOnGround);
    }

    private void FixedUpdate()
    {
        //TODO: we should put our physics code in here, not in update!
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;

        //The above line means the following commented lines. 
        //if (isFacingRight) scale.x = 1;
        //else scale.x = -1;

        transform.localScale = scale;
    }
}
