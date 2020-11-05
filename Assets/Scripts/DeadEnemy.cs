using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    public int health = -1;
    public GameObject revivedEnemy;
    /// <summary>
    /// Allows enemies to be instantiated when "healed"
    /// </summary>
    void Update()
    {
        if (health >= 0)
        {
            Destroy(gameObject);
            Instantiate(revivedEnemy, transform.position, Quaternion.identity);
        }
    }

    public void RecieveHeal(int heal, float timer)
    {
        health -= heal;
        Debug.Log("healed");        
    }
}
