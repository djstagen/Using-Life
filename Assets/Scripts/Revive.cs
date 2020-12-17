using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadEnemy"))
        {
            collision.GetComponent<DeadEnemy>().health += +2;
        }

    }
}
