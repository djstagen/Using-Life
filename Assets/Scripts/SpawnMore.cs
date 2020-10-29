using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMore : MonoBehaviour
{
    public GameObject particles;

    /// <summary>
    /// spawns more objects on hit.
    /// </summary>
    public void GetHitSplit(int damage, float timer)
    {
        Debug.Log("damage was dealt to enemy");
        Instantiate(particles, transform.position, Quaternion.identity);

    }
}
