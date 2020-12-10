using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject uiObject;

    private void Start()
    {
        uiObject.SetActive(false);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        uiObject.SetActive(true);
    }
}
