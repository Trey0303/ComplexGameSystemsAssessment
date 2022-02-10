using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindTarget : MonoBehaviour
{
    //public string playerTag;

    public PhysicalSkill physicalSkill;

    //SkillObj skillData;

    protected GameObject target;
    //public string targetTag;
    protected bool targetInRange;

    //private void Start()
    //{
    //    skillData = GameObject.FindWithTag(playerTag).GetComponent<SkillObj>();
    //    physicalSkill = skillData;

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)//enemy
        {
            Debug.Log("enemy in range");
            //targetInRange = true;
            target = other.gameObject;

            //physicalSkill.isTarget = true;

            physicalSkill.HitTarget(other);

            //apply damage
            //target.GetComponent<Health>().health -= physicalSkill.damage/*get damage from skill in use???*/;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            Debug.Log("enemy out of range");
            targetInRange = false;
            target = null;

            //physicalSkill.isTarget = false;
        }
    }
}
 