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

        //create hitbox
        DisplayHitBox();

        //apply damage
    }

    void DisplayHitBox()
    {
        //GameObject hitbox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var box = Instantiate(hurtboxPrefab, wielder.transform.position + wielder.transform.forward, Quaternion.identity);

        //get target from FindTarget
        var targetTemp = box.GetComponent<FindTarget>();

        //give FindTarget current skill
        targetTemp.skill = this;

        //hitbox follows player while active
        box.transform.parent = wielder.transform;

        Destroy(box, 0.1f);
        //hitbox.transform.position = new Vector3(wielder.transform.position.x, wielder.transform.position.y, wielder.transform.position.z + 1);
        //hitbox.GetComponent<Collider>().isTrigger = true;

        //hitbox.transform.parent = wielder.transform;

        //activePhysicalHitbox = box;
    }

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