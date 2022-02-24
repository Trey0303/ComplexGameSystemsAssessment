using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject checkpointSpawnpoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            respawn.spawnpoint = checkpointSpawnpoint;
        }
    }
}
