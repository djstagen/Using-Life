using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour
{
    public float timer = 0.5f;
    private void Start()
    {       
        Destroy(gameObject, timer);
    }
}
