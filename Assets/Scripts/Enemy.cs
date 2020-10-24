using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float flashTime;
    public GameObject deadEnemyLand;
    public GameObject particles;
    Color originalColor;
    public SpriteRenderer sRenderer;

    void Start()
    {
        originalColor = sRenderer.color;
    }

    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadEnemyLand, transform.position,Quaternion.identity);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }



    public void TakeDamage(int damage, float timer)
    {
        health -= damage;
        Debug.Log("damage was dealt to enemy");
        FlashRed();
        //Instantiate(particles, transform.position, Quaternion.identity);

    }

    void FlashRed()
    {
        sRenderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sRenderer.material.color = originalColor;
    }
}
