using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;               // Reference to the player's position.
    public PlayerHealth playerHealth;      // Reference to the player's health.
    public EnemyHealth enemyHealth;        // Reference to this enemy's health.
    public UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    void Awake ()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        if(player != null)//if player is found
        {
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
            //nav.enabled = true;
        }
        //else
        //{
        //    nav.enabled = false;
        //}
    }


    void Update ()
    {
        if (player != null)//if player spawned
        {
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination (player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }

        }
        else {//try to find player again
            player = GameObject.FindGameObjectWithTag("Player").transform;

            if(player != null)
            {
                playerHealth = player.GetComponent<PlayerHealth>();
                enemyHealth = GetComponent<EnemyHealth>();
                nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
                //nav.enabled = true;
            }
        }
    }
}