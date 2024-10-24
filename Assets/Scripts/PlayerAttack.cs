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
        if(Input.GetKey(KeyCode.A) && coolDownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
        coolDownTimer += Time.deltaTime;
    }

    private void Attack()
    {

    }

}
