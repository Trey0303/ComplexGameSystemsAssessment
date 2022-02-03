using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public List<SkillProgress> skillProgress = new List<SkillProgress>();

    // Start is called before the first frame update
    void Start()
    {
        //maxExp = 5;
        for(int i = 0; i < skillProgress.Count; i++)
        {
            //exp[i] = skillData[i].exp; 
            if(skillProgress.Count != 0)
            {
                skillProgress[i].AddSkill();

            }

            //skillProgress[i].maxExp = 5;
            //skillProgress[i].level = 1;
            //skillProgress[i].damage = skillProgress[i].skillData.damage;
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

    /*
    void LevelUpSkill()
    {
        for (int i = 0; i < skillData.Count; i++)
        {

            //check if skill has enough exp to level up
            if (exp[i] >= maxExp[i])
            {
                //if so then increase level
                level[i] = level[i] + 1;

                //increase skill damage
                damage[i] = skillData[i].damage + (level[i] - 1) * 3;

                //save any extra exp 
                if (exp[i] > maxExp[i])
                {
                    //check if there is any leftover experience to add after level up
                    exp[i] = exp[i] - maxExp[i];
                }
                else
                {
                    exp[i] = 0;
                }

                //increase the maxExp cap by 5
                maxExp[i] = maxExp[i] + (level[i] - 1) * 5;

                Debug.Log("skill " + i + "maxExp: " + maxExp[i]);
                Debug.Log("skill " + i + "level: " + level[i]);
                Debug.Log("skill " + i + "dmg: " + damage[i]);

            }
        }

    }
    */
}
