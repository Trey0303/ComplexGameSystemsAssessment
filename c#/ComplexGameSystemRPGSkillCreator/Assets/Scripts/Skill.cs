using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public SkillObj skillData;


    int exp;
    int level;
    float damage;
    private int maxExp;

    // Start is called before the first frame update
    void Start()
    {
        maxExp = 5;
        //Debug.Log(skillData.damage);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            exp = exp + 1;
            LevelUpSkill();
            Debug.Log("exp: " + exp);
            Debug.Log("maxExp: " + maxExp);
            Debug.Log("lvl: " + level);
            Debug.Log("dmg: " + damage);

        }

        
    }

    void LevelUpSkill()
    {
        //check if skill has enough exp to level up
        if (exp >= maxExp)
        {
            //if so then increase level
            level = level + 1;

            //increase skill damage
            damage = skillData.damage + (level - 1) * 3;

            //save any extra exp 
            if (exp > maxExp)
            {
                //check if there is any leftover experience to add after level up
                exp = exp - maxExp;
            }
            else
            {
                exp = 0;
            }

            //increase the maxExp cap by 5
            maxExp = maxExp + (level - 1) * 5;

        }
    }
}
