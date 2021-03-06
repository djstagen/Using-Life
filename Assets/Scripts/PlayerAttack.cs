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

    private float timer1 = 0.1f;
    private float timer2 = 20f;


    //code referenced from blackthornprod

        /// <summary>
        /// Take damage is for Enemy script
        /// GetHitSplit is for SpawnMore script
        /// </summary>
    private void Update()
    {
        //Get Button down does not let an attack come out at all.
        if (timeAttackCD <= 0)
        {
            if(Input.GetKey(KeyCode.J))
            {
                Instantiate(attackParticles, attackPosition.position, Quaternion.identity);
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemy);
                FindObjectOfType<AudioManager>().Play("Damage");
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage (damage, timer1);
                    enemiesToDamage[i].GetComponent<SpawnMore>().GetHitSplit(damage, timer2);

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
