using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{

    public SkillObj skill;

    public List<GameObject> targets;

    public int targetLayer = 6;

    private void Update()
    {
        if (targets != null)
        {
            for(int i = 0; i < targets.Count; i++)
            {
                skill.HitTarget(targets[i]);
                targets[i] = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("triggered");
        if (other.gameObject.layer == targetLayer)//enemy
        {
            //Debug.Log("enemy in range");

            targets.Add(other.gameObject);
        }


    }
}
 