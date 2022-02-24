using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportpoint;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawn.spawnpoint = teleportpoint;
            player.GetComponent<KinematicBody>().enabled = false;
            player.transform.position = respawn.spawnpoint.transform.position;
            player.GetComponent<KinematicBody>().enabled = true;
        }
    }
}
