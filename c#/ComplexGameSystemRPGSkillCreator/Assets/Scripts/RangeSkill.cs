using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeSkillData", menuName = "SkillObjects/ScriptableRangeSkill", order = 1)]
public class RangeSkill : SkillObj
{
    protected GameObject activeRangeHitbox;

    // Start is called before the first frame update
    public override void Use()
    {
        wielder = GameObject.FindWithTag(characterTag);
        
        DisplayHitBox();
    }

    void DisplayHitBox()
    {
        var box = Instantiate(hurtboxPrefab, new Vector3(wielder.transform.position.x, wielder.transform.position.y, wielder.transform.position.z + 4.4f), Quaternion.identity);

        var targetTemp = box.GetComponent<FindTarget>();

        targetTemp.skill = this;

        box.transform.parent = wielder.transform;

        Destroy(box, .1f);
    }

    
}
