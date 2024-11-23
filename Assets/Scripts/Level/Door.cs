using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Door linkedDoor;
    [SerializeField] private GameObject attachedRoom;
    [SerializeField] private GameObject exitLocation;
    private RoomManager roomManager;

    void Start()
    {
        roomManager = FindObjectOfType<RoomManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        roomManager.ChangeRoom(attachedRoom, linkedDoor.attachedRoom, linkedDoor, linkedDoor.exitLocation);
    }

}
