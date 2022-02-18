using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public Enemy enemySpawner;

    public EnemyHealth enemyhealth;

    public int health;

    private void Start()
    {
        enemyhealth = this.gameObject.GetComponent<EnemyHealth>();

        health = enemyhealth.currentHealth;
        //enemySpawner = GameObject.Find("EnemySpawner").GetComponent<Enemy>();   
        //health += enemySpawner.healthIncrease;

    }

    private void Update()
    {
        if(health != enemyhealth.currentHealth)
        {
            if (health < enemyhealth.currentHealth)
            {
                enemyhealth.currentHealth = health;
            }
            else
            {
                health = enemyhealth.currentHealth;

            }
        }

        //Debug.Log(PlayerVariableData.mana);

        if(health <= 0 && !enemyhealth.isDead)
        {

            
            enemyhealth.Death();
        }
    }
}
