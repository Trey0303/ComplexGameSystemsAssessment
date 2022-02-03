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
        if (Input.GetKeyDown(KeyCode.F))
        {
            skillProgress[0].AddExp(5);
        }
    }
}
