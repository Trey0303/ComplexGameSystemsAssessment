using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    public float timer = 0.0f;

    void Start ()
    {
        Debug.Log(playerHealth.currentHealth);
        Debug.Log(player);
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        if (playerHealth != null && player != null)
        {
            Spawn();
            timer = spawnTime;
            //InvokeRepeating("Spawn", spawnTime, spawnTime);

        }
        else
        {
            if(GameObject.FindGameObjectWithTag("Player") != null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                playerHealth = player.GetComponent<PlayerHealth>();
            }
            
        }

        //InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    // if there are no players, do nothing
    // otherwise, count down a timer
    // once the timer finishes, spawn an enemy and reset the timer

    void FixedUpdate()
    {
        if (playerHealth != null && player != null)
        {
            //InvokeRepeating("Spawn", spawnTime, spawnTime);

            timer = timer - Time.deltaTime;// otherwise, count down a timer

            if (timer <= 0)// once the timer finishes, spawn an enemy and reset the timer
            {
                Spawn();
                timer = spawnTime;
            }

        }
        else// if there are no players, do nothing
        {
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                playerHealth = player.GetComponent<PlayerHealth>();
            }
        }
    }


    void Spawn ()
    {
        

        // If the player has no health left...
        if(playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        //if player is dead then disable this script
        if (playerHealth.isDead == true)
        {
            this.enabled = false;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}