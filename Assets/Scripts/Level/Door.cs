using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private Door linkedDoor;
    [SerializeField] private GameObject attachedRoom;
    [SerializeField] private GameObject exitLocation;
    private RoomManager roomManager;

    [SerializeField] private static int count = 0;

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
        if (count == 7)
        {
            SceneManager.LoadScene("YouWin");

        }

        roomManager.ChangeRoom(attachedRoom, linkedDoor.attachedRoom, linkedDoor, linkedDoor.exitLocation);
        count++;

        
        
        
    }

}
