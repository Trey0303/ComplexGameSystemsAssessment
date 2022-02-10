using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillObjects/ScriptableSkills", order = 1)]
public class SkillObj : ScriptableObject
{
    public string skillName;
    public int damage;
    public int maxLevel;
    public int cost;

    //use skill
    public string characterTag;
    protected GameObject wielder;
    //protected bool hitboxSpawned = false;

    public GameObject hurtboxPrefab;


    public virtual void Use() {
        wielder = GameObject.FindWithTag(characterTag);

        Debug.Log("basic skill");
        //play animation
    }

    //apply damage
    public virtual void HitTarget(GameObject targetCollider)
    {
        if (targetCollider != null)
        {
            if (targetCollider.gameObject.GetComponent<Health>() != null)
            {
                Health targetHealth = targetCollider.gameObject.GetComponent<Health>();

                targetHealth.health = targetHealth.health - damage;
                //Debug.Log("hit");

            }
            else
            {
                Debug.Log("target does NOT have health script attached");
            }
        }
    }

}