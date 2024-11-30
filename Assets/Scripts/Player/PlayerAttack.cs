using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]private float attackCooldown;
    private Animator anim;
    private PlayerMovement playerMovement;
    private float coolDownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if(Input.GetKey("a") && coolDownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        coolDownTimer = 0;
        //pool projectile
        /*using pooling due to instatniate and destroy creates new projectiles on every usage
        and destroys it on hit easy to implement but bars performance. while object pooling
        means multiple projectile objects are already created and they are just activated
        on use and deactived when finished and are reused. this is recomended when you are
        creating a lot of objects*/
    }

}
