using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask BushLayer;
    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (boxCollider.tag == "Player"){
        //     Physics2D.IgnoreLayerCollision(8, 9, true);
        // }
        // else{
        //     Physics2D.IgnoreLayerCollision(8, 9, false);
        // }
    }

    // private void isTouching(){
    //     RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, BushLayer);
    //     return raycastHit.collider != null;
    // }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Bush trigger");
            Physics2D.IgnoreLayerCollision(8, 9, true);
        }
    }
}
