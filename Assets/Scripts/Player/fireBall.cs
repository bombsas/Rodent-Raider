using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private BoxCollider2D boxCollider;
    private Animator anim;

    private void Awake() {
       anim = GetComponent<Animator>();
       boxCollider = GetComponent<BoxCollider2D>(); 
    }

    private void Update() {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed,0,0);
        lifetime += Time.deltaTime;
        if(lifetime >5) gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

    }

    public void SetDirection(float cur_direction) {
        lifetime = 0;
        direction = cur_direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if(Mathf.Sign(localScaleX) != cur_direction){
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate(){
        gameObject.SetActive(false);
    }

}
