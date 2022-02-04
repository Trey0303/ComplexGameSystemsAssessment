using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PhysicalSkillData", menuName = "SkillObjects/ScriptablePhysicalSkills", order = 1)]
public class PhysicalSkill : SkillObj
{
    public override void Use()
    {
        wielder = GameObject.FindWithTag(characterTag);
        Debug.Log("phys skill");
        //play animation

        //create physical hitbox
        GameObject hitbox = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), wielder.transform.position + new Vector3(0,0,1), wielder.transform.rotation);

        //apply damage
    }
}
