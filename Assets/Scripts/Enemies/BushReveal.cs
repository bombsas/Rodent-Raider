using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushReveal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bool stunned = collision.GetComponent<Health>().gothitcheck;
            if (stunned == false)
                Debug.Log("Bush reveal trigger");
                Physics2D.IgnoreLayerCollision(8, 9, false);
        }
    }
}
