using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;

    
    [Header("Enemy Spawn Position")]
    //public Vector3 spawnPos;
    public Transform spawnPoint;

    public float timer;
    public float targetTime;
    public bool dead;

    public int healthIncrease = 0;
    public int moneyEarnIncrease = 5;

    public int deathCount = 0;
    public int maxDeathCount;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("spawnpoint").transform;
        deathCount = 0;
        maxDeathCount = 5;
        timer = 0;
        targetTime = .5f;
        enemy.transform.position = spawnPoint.position;
        Instantiate(enemy);
        //enemyTransform = this.transform;
        //enemyHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
        }

        if(timer >= targetTime)
        {
            //Debug.Log("spawn");
            deathCount++;
            if(deathCount == maxDeathCount)
            {
                deathCount = 0;
               moneyEarnIncrease++;
            }
            enemy.transform.position = spawnPoint.position;
            healthIncrease++;
            Instantiate(enemy.gameObject);
            dead = false;
            timer = 0;
        }
    }
}
