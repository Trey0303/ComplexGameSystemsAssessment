using UnityEngine;
using System.Collections;
using Unity.Netcode;

//using Unity.Netcode;

public class EnemyMovement : NetworkBehaviour
{
    public Transform player;               // Reference to the player's position.
    public PlayerHealth playerHealth;      // Reference to the player's health.
    public EnemyHealth enemyHealth;        // Reference to this enemy's health.
    public UnityEngine.AI.NavMeshAgent nav;               // Reference to the nav mesh agent.


    private NetworkVariable<Vector3> networkEnemyPosition;


    void Awake ()
    {
        // Set up the references.
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag ("Player").transform;

            if(player != null)//if player is found
            {
                playerHealth = player.GetComponent <PlayerHealth> ();
                enemyHealth = GetComponent <EnemyHealth> ();
                nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
                //nav.enabled = true;
            }

        }
        //else
        //{
        //    nav.enabled = false;
        //}
    }


    void Update ()
    {
        //if (IsServer)
        //{
            if (player != null)//if player spawned
            {
                // If the enemy and the player have health left...
                if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
                {
                    // ... set the destination of the nav mesh agent to the player.
                    nav.SetDestination(player.position);
                }
                // Otherwise...
                else
                {
                    // ... disable the nav mesh agent.
                    nav.enabled = false;
                }

            }
            else
            {//try to find player again
                player = GameObject.FindGameObjectWithTag("Player").transform;

                if (player != null)
                {
                    playerHealth = player.GetComponent<PlayerHealth>();
                    enemyHealth = GetComponent<EnemyHealth>();
                    nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
                    //nav.enabled = true;
                }
            }

            //if player is dead then disable this script
            if (playerHealth.isDead == true)
            {
                this.enabled = false;
            }

            //OwnerSetPotionClientRpc(this.transform.position);
        //}
        //else
        //{
        //    this.transform.position = networkEnemyPosition.Value;
        //}

        
    }

    //update network position with current position
    //[ClientRpc(Delivery = RpcDelivery.Unreliable)]
    //void OwnerSetPotionClientRpc(Vector3 newPos)
    //{
    //    networkEnemyPosition.Value = newPos;
    //}
}