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
    public int maxLevel;
    public int skillLvl;

    public SkillData(string nameString, string typeString, int damageInt, float rangeFloat, int max_levelInt, int skillLvlInt)
    {
        nameString = name;
        typeString = type;
        damageInt = damage;
        rangeFloat = range;
        max_levelInt = maxLevel;
        skillLvlInt = skillLvl;

    }

}

public class SkillCreator : MonoBehaviour
{
    int exp;
    int maxExp;
    int damageStep;
    int rangeStep;
    int maxExpStep;

    //butttons to call functions
    public Button createButton;
    public Button editButton;
    public Button deleteButton;

    //display menus
    public GameObject createSkillMenu;
    public GameObject editSkillMenu;
    public GameObject deleteSkillMenu;

    //submits changes to skills
    public Button submitCreate;
    public Button submitEdit;
    public Button submitDelete;

    //getting user input
    InputField nameInput;
    string myName;
    InputField damageInput;
    int myDamage;
    InputField rangeInput;
    int myRange;

    // Start is called before the first frame update
    void Start()
    {
        exp = 1;
        maxExp = 5;
        damageStep = 3;
        rangeStep = 2;
        maxExpStep = 5;

        createSkillMenu.SetActive(false);
        editSkillMenu.SetActive(false);
        deleteSkillMenu.SetActive(false);
    }

    public void ShowCreateMenu()
    {
        Debug.Log("Create skill");

        //hide main buttons
        createButton.gameObject.SetActive(false);
        editButton.gameObject.SetActive(false);
        deleteButton.gameObject.SetActive(false);

        //show skill creation ui
        createSkillMenu.SetActive(true);


    }
    

    void LevelUpSkill()
    {
        //LevelUpSkill(exp);
    }

    //increase level of skill if conditions are met
    //void LevelUpSkill(int exp)
    //{
    //    check if skill has enough experience to level up
    //    if (exp >= maxExp)
    //    {
    //        //if so then increase level
    //        skillLvl = SkillData.skillLvl + 1;

    //        //increase skill damage
    //        myDamage = myDamage + (skillLvl - 1) * damageStep;


    //        if (exp > maxExp)
    //        {
    //            //check if there is any leftover experience to add after level up
    //            exp = exp - maxExp;
    //            maxExp = maxExp + (skillLvl - 1) * maxExpStep;
    //        }
    //    }
    //}
}
