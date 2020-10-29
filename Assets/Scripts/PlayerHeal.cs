using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : MonoBehaviour
{
    private float timeHealCD;
    public float startHealTime;

    public Transform healPosition;
    public LayerMask whatIsDeadBody;
    public float healRange;
    public int heal;

    public GameObject healParticles;

    private void Update()
    {
        if (timeHealCD <= 0)
        {
            if (Input.GetKey(KeyCode.H))
            {
                Instantiate(healParticles, healPosition.position, Quaternion.identity);
                Collider2D[] enemiesToHeal = Physics2D.OverlapCircleAll(healPosition.position, healRange, whatIsDeadBody);
                for (int i = 0; i < enemiesToHeal.Length; i++)
                {

                }
            }
        }
    }
}
