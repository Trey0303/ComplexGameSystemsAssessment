using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PhysicalSkillData", menuName = "SkillObjects/ScriptablePhysicalSkill", order = 1)]
public class PhysicalSkill : SkillObj
{
    protected GameObject activePhysicalHitbox;

    //public AnimationClip physAnimation;
    
    public override void Use()
    {
        wielder = GameObject.FindWithTag(characterTag);

        DisplayHitBox();
    }

    void DisplayHitBox()
    {
        var box = Instantiate(hurtboxPrefab, wielder.transform.position + wielder.transform.forward, wielder.transform.rotation);

        //get target from FindTarget
        var targetTemp = box.GetComponent<FindTarget>();

        //give FindTarget current skill
        targetTemp.skill = this;

        box.transform.parent = wielder.transform;
        
        Destroy(box, .1f);
    }

    //public void HitTarget(Collider targetCollider)
    //{
    //    if (targetCollider != null)
    //    {
    //        if (targetCollider.gameObject.GetComponent<Health>() != null)
    //        {
    //            Health targetHealth = targetCollider.gameObject.GetComponent<Health>();

    //            targetHealth.health = targetHealth.health - damage;
    //            //Debug.Log("hit");

    //        }
    //        else
    //        {
    //            Debug.Log("target does NOT have health script attached");
    //        }
    //    }
    //}

}
