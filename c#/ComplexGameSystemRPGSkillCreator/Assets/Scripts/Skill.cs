using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public List<SkillProgress> skillProgress = new List<SkillProgress>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < skillProgress.Count; i++)
        {
            //exp[i] = skillData[i].exp; 
            if(skillProgress.Count != 0)
            {
                skillProgress[i].AddSkill();

            }
        }   
    }

    // Add Skill method
    // should add the skill to the list of skill progresses
    // set default/starting values on that skill progress
    // use this in Start() instead of hard-coding in how to initialize each progress
    
    // Update is called once per frame
    void Update()
    {
        //skill 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(skillProgress.Count >= 1)
            {
                skillProgress[0].AddExp(5);

            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (skillProgress.Count >= 2)
            {
                skillProgress[1].AddExp(5);

            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (skillProgress.Count >= 3)
            {
                skillProgress[2].AddExp(5);

            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (skillProgress.Count >= 4)
            {
                skillProgress[3].AddExp(5);

            }

        }
    }
}
