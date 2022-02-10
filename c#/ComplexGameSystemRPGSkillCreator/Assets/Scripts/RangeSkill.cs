using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RangeSkillData", menuName = "SkillObjects/ScriptableRangeSkills", order = 1)]
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

        box.transform.parent = wielder.transform;

        Destroy(box, 0.1f);
    }

    public void HitTarget(Collider targetCollider)
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
