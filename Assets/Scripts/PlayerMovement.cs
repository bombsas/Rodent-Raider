using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    //SerializeFieald allows it to be changed in unity and here
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCoolDown;
    private float HorizontalInput;

    /*this is for when the game first stars up it will call wake 
    to make an intial check and calls. this only gets called 
    on the first frame.
    */
    private void Awake()
    {
        //grab references of rigidbody and animator from unity
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    /*
    This update will check every frame of the game and call
    what is inside
    */
    private void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        

        //flips player when moving left or right
        //this for moving right
        if (HorizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        //this for moving left
        else if (HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        

        

        //set animator parameters
        // Run is set at not 0 so that it will not be 
        //called when no movement is inputted
        anim.SetBool("Run", HorizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());

        // wall jump logic
        if (wallJumpCoolDown > 0.1f)
        {
            

            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else{
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else{
            wallJumpCoolDown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if(isGrounded()){
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        else if(onWall() && !isGrounded()){
            if (HorizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x),transform.localScale.y,transform.localScale.z);
            }
            else{
                /* the transform is on the player itself to get the direction of the player
                // we want them to jump away and not into the wall
                // mathf.sign riturns the sign of the number when it gets a number
                // it either returns a 1 for positive numbers or -1 for negative numbers
                // and due to having a negative with the mathf it returns the opposite allowing 
                // players to jump away from wall
                // the first parameter is how far the player is pushed away from the wall
                // second parameter is how high they get pushed up
                */
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
            }
            wallJumpCoolDown = 0;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){

    }

    private bool isGrounded(){
        //Physics2D.BoxCast( origin of the box cast, the size of the box, the angle, direction of box cast, distance, layer)
        //layer is to serperate layers such like a layer for the player, enemies, the ground and the wall putting something in the
        //layer allows it to search only within that layer
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        //Physics2D.BoxCast( origin of the box cast, the size of the box, the angle, direction of box cast, distance, layer)
        //layer is to serperate layers such like a layer for the player, enemies, the ground and the wall putting something in the
        //layer allows it to search only within that layer
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.01f, wallLayer);
        return raycastHit.collider != null;
    }
}
