using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SkillData
{
    public string name;
    public string type;
    public int damage;
    public float range;
    public int max_level;
    public int skillLvl;

    public SkillData(string nameString, string typeString, int damageInt, float rangeFloat, int max_levelInt, int skillLvlInt)
    {
        nameString = name;
        typeString = type;
        damageInt = damage;
        rangeFloat = range;
        max_levelInt = max_level;
        skillLvlInt = skillLvl;

    }

}

public class SkillCreator : MonoBehaviour
{
    int exp;
    int max_exp;

    //butttons to call functions
    public Button createButton;
    public Button editButton;
    public Button deleteButton;

    // Start is called before the first frame update
    void Start()
    {
        exp = 1;
    }

    public void CreateSkill()
    {
        //Debug.Log("Create skill");
        //CreateSkill(name, type, damage, range, max_level);
    }

    //create skill using given parameters
    public void CreateSkill(string name, string type, int damage, float range, int max_level)
    {
        //create an empty skill

        //save skill to a list of skills
    }

    public void DeleteSkill()
    {
        //Debug.Log("Delete skill");
        DeleteSkill(name);
    }

    //delete skill by name
    public void DeleteSkill(string name)
    {
        //check if skill exsists
        
        //if so then delete and remove from skill list
    }

    public void EditSkill()
    {
        //Debug.Log("Edit skill");
        EditSkill(name);
    }

    //adjust/change skills name, type, damage, range, or max_level
    public void EditSkill(string name)
    {
        //check if skills exsists

        //if so then ask for all parameters again

        //overwrite current skill with new data

        //save change to skill list
    }

    void LevelUpSkill()
    {
        LevelUpSkill(exp);
    }

    //increase level of skill if conditions are met
    void LevelUpSkill(int exp)
    {
        //check if skill has enough experience to level up
        if(exp >= max_exp)
        {
            //if so then increase level
            //skillLvl = SkillData.skillLvl + 1;
            if(exp > max_exp)
            {
                //check if there is any leftover experience to add after level up
                exp = exp - max_exp;
            }
        }
    }
}
