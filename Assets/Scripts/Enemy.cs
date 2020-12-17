using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int scale = 1;

    public int health;
    public float speed;
    public float ySpeed;
    public float flashTime;
    public GameObject deadEnemyLand;
    public GameObject particles;
    Color originalColor;
    public SpriteRenderer sRenderer;
    public bool MoveLeft;


    void Start()
    {
        originalColor = sRenderer.color;
    }

    /// <summary>
    /// update object when health reaches a certain parameter.
    /// creates new object (ex. dead body)
    /// </summary>
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadEnemyLand, transform.position, Quaternion.identity);
        }
        if (MoveLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            transform.localScale = new Vector2(scale, scale);
            transform.Translate(Vector2.up * ySpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.localScale = new Vector2(-scale, scale);
            transform.Translate(Vector2.up * ySpeed * Time.deltaTime);

        }

    }


    /// <summary>
    /// How player attack uses enemy script
    /// </summary>
    /// <param name="damage"></param> amount of damage enemy recieves when attacked
    /// <param name="timer"></param> destroys object after this time
    public void TakeDamage(int damage, float timer)
    {
        health -= damage;
        Debug.Log("damage was dealt to enemy");
        FlashRed();
        FindObjectOfType<AudioManager>().Play("EnemyHit");

        //Instantiate(particles, transform.position, Quaternion.identity);

    }


    /// <summary>
    /// flashes red on hit and reverts
    /// </summary>
    void FlashRed()
    {
        sRenderer.material.color = Color.red;
        Invoke("ResetColor", flashTime);
    }

    void ResetColor()
    {
        sRenderer.material.color = originalColor;
    }

    /// <summary>
    /// turns object around after hitting certain point.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("turn"))
        {
            if(MoveLeft)
            {
                MoveLeft = false;
            }
            else
            {
                MoveLeft = true;
            }
        }
        if(other.gameObject.CompareTag("stop"))
        {
            ySpeed = 0;
        }
    }


}
