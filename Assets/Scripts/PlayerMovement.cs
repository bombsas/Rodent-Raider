using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    
    /*this is for when the game first stars up it will call wake 
    to make an intial check and calls. this only gets called 
    on the first frame.
    */
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    /*
    This update will check every frame of the game and call
    what is inside
    */
    private void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal"),body.velocity.y);
    }
}
