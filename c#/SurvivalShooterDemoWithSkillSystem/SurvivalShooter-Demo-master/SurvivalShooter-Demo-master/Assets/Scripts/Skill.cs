using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillProgress skill;

    // Start is called before the first frame update
    void Start()
    {
        PlayerVariableData.mana = 100;

        if (skill != null)
        {
            skill.AddSkill();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerVariableData.mana >= skill.cost)
            {
                skill.AddExp(5);
                skill.Use();
                PlayerVariableData.mana -= skill.cost;

            }
        }
    }
}
