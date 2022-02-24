using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public static GameObject spawnpoint { get; set; }

    GameObject player;

    //GameObject spawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnpoint = GameObject.Find("respawn");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<KinematicBody>().enabled = false;
            player.transform.position = spawnpoint.transform.position;
            player.GetComponent<KinematicBody>().enabled = true;
        }
    }
}
