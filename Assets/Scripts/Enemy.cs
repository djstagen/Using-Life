using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject deadEnemyLand;

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadEnemyLand, transform.position,Quaternion.identity);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage was dealt to enemy");
    }
}
