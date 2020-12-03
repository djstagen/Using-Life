using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSetActive : MonoBehaviour, IDoor
{
    [SerializeField]
    GameObject door;

    
    private bool isOpen = false;

    public void OpenDoor()
    {
        gameObject.SetActive(false);

        //door.transform.position = new Vector2(position.x,position.y +4);
    }

    public void CloseDoor()
    {
        gameObject.SetActive(true);
        //door.transform.position = new Vector2(0, -4);

    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}
