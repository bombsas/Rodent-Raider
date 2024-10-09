using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    //SerializeFieald allows it to be changed in unity and here
    [SerializeField]private float speed;
    
    /*this is for when the game first stars up it will call wake 
    to make an intial check and calls. this only gets called 
    on the first frame.
    */
    private void Awake()
    {
        //grab references of rigidbody and animator from unity
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    /*
    This update will check every frame of the game and call
    what is inside
    */
    private void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //flips player when moving left or right
        //this for moving right
        if (HorizontalInput > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        //this for moving left
        else if (HorizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //set animator parameters
        // Run is set at not 0 so that it will not be 
        //called when no movement is inputted
        anim.SetBool("Run", HorizontalInput != 0);
        anim.SetBool("Grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
