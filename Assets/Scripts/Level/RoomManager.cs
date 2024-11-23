using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private GameObject player;
    private Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = player.GetComponent<Collider2D>();
    }

    public void ChangeRoom(GameObject roomToUnload, GameObject roomToLoad, Door dest, GameObject exitLocation)
    {
        GameManager.EnablePlayerInput = false;
        roomToLoad.SetActive(true);
        Collider2D doorCollider = dest.GetComponent<Collider2D>();

        player.transform.position = exitLocation.transform.position;


        GameManager.EnablePlayerInput = true;
        roomToUnload.SetActive(false);
    }
}
