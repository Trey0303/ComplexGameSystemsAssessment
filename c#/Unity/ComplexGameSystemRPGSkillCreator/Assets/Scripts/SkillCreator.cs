using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SkillData
{
    string name;
    string type;
    int damage;
    float range;
    int max_level;

}

public class SkillCreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //create skill using given parameters
    void CreateSkill(string name, string type, int damage, float range, int max_level)
    {
        //create an empty skill

        //overwrite skill with current parameters

        //save skill to a list of skills
    }

    //delete skill by name
    void Delete(string name)
    {
        //check if skill exsists
        
        //if so then delete and remove from skill list
    }

    //adjust/change skills name, type, damage, range, or max_level
    void EditSkill(string name)
    {
        //check if skills exsists

        //if so then ask for all parameters again

        //overwrite current skill with new data

        //save change to skill list
    }

    //increase level of skill if conditions are met
    void LevelUp(int exp)
    {
        //check if skill has enough experience to level up

        //if so then increase level

        //check if there is any leftover experience to add after level up
    }
}
