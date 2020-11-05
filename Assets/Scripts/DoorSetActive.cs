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

    }

    public void CloseDoor()
    {

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
