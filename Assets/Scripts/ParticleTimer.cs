using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTimer : MonoBehaviour
{
    public float timer = 0.5f;

    /// <summary>
    /// this destroys object after certain time
    /// </summary>
    private void Start()
    {       
        Destroy(gameObject, timer);
    }
}
