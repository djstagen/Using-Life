﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeAttackCD;
    public float startAttacktime;

    public Transform attackPosition;
    public LayerMask whatIsEnemy;
    public float attackRange;
    public int damage;

    public GameObject attackParticles;



    //code referenced from blackthornprod

    private void Update()
    {
        if (timeAttackCD <= 0)
        {
            if(Input.GetKey(KeyCode.J))
            {
                Instantiate(attackParticles, attackPosition.position, Quaternion.identity);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage (damage);
                    
                }
            }
            timeAttackCD = startAttacktime;
        }
        else
        {
            timeAttackCD -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }
}
