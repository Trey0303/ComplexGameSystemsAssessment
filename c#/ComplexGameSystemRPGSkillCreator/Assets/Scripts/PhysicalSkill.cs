using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PhysicalSkillData", menuName = "SkillObjects/ScriptablePhysicalSkills", order = 1)]
public class PhysicalSkill : SkillObj
{
    protected GameObject activePhysicalHitbox;

    public AnimationClip physAnimation;

    public GameObject hurtboxPrefab;
    
    public override void Use()
    {
        wielder = GameObject.FindWithTag(characterTag);
        //Debug.Log("phys skill");

        //play animation

        DisplayHitBox();

        //return;
        ////create physical skill hitbox
        //if (activePhysicalHitbox == null)
        //{
        //    DisplayHitBox();
        //}
        //else if(activePhysicalHitbox != null)
        //{
        //    if (targetInRange)
        //    {
        //        Debug.Log("hit");
        //        DamageTarget();
                
        //    }
        //    else
        //    {
        //        Debug.Log("missing a target");
        //    }
        //}
    }

    void DisplayHitBox()
    {
        //GameObject hitbox = GameObject.CreatePrimitive(PrimitiveType.Cube);
        var box = Instantiate(hurtboxPrefab, wielder.transform.position + wielder.transform.forward, Quaternion.identity);
        Destroy(box, 0.1f);
        //hitbox.transform.position = new Vector3(wielder.transform.position.x, wielder.transform.position.y, wielder.transform.position.z + 1);
        //hitbox.GetComponent<Collider>().isTrigger = true;

        //hitbox.transform.parent = wielder.transform;

        //activePhysicalHitbox = box;
    }

    //void DamageTarget()
    //{
    //    //apply damage
    //    target.GetComponent<Health>().health -= damage;


    //    //play animation


    //    //play sound


    //    //remove hitbox
    //    Destroy(activePhysicalHitbox);
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == targetTag)
    //    {
    //        Debug.Log("enemy in range");
    //        targetInRange = true;
    //        target = other.gameObject;

    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == targetTag)
    //    {
    //        Debug.Log("enemy out of range");
    //        targetInRange = false;
    //        target = null;
    //    }
    //}
}
