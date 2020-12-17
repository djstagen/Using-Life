using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Text : MonoBehaviour
{
    public Text uiObject;

    public void Start()
    {
        uiObject.Start();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        uiObject.Start();
    }
}
