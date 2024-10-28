using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFiring : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Fireball;
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
        if (Input.GetKey("s") && coolDownTimer > attackCooldown && playerMovement.canAttack())
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
        Fireball[0].transform.position = firePoint.position;
        Fireball[0].GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
