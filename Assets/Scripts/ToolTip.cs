using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTip : MonoBehaviour
{
    public GameObject uiObject;

    private void Start()
    {
        uiObject.SetActive(false);
    }
    public void OnTriggerEnter2D( )
    {
        uiObject.SetActive(true);
    }

    public void OnTriggerExit2D()
    {
        uiObject.SetActive(false);
    }
}
