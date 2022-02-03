using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    //change this to a list for ability to add more skills to player
    public List<SkillObj> skillData;


    //might need to change these to reflect on mulitiple different skills
    private List<int> exp;
    private List<int> level;
    private List<float> damage;
    private List<int> maxExp;

    // Start is called before the first frame update
    void Start()
    {
        //maxExp = 5;
        for(int i = 0; i < skillData.Count; i++)
        {
            //exp[i] = skillData[i].exp; 
            maxExp[i] = 5;
        }

        
        
    }


    // Update is called once per frame
    void Update()
    {
        //skill 1
        if (Input.GetKeyDown(KeyCode.F))
        {
            exp[0] = exp[0] + 1;
            LevelUpSkill();

        }
        //skill 2
        if (Input.GetKeyDown(KeyCode.G)){
            exp[1] = exp[1] + 1;
            LevelUpSkill();
        }
        //skill 3
        if (Input.GetKeyDown(KeyCode.H))
        {
            exp[2] = exp[2] + 1;
            LevelUpSkill();
        }
        //skill 4
        if (Input.GetKeyDown(KeyCode.J))
        {
            exp[3] = exp[3] + 1;
            LevelUpSkill();
        }

    }

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
}
