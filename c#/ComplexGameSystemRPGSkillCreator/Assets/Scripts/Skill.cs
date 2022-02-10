using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Slider manaBar;
    public Text manaText;

    public int mana = 100;

    public List<SkillProgress> skillProgress = new List<SkillProgress>();
    //protected GameObject target;
    //public string targetTag;
    //protected bool targetInRange;


    // Start is called before the first frame update
    void Start()
    {
        manaText.text = "" + mana;
        manaBar.value = mana;

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
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (skillProgress.Count >= 3)
            {

                if (mana >= skillProgress[2].cost)
                {
                    skillProgress[2].skillData.Use();
                    skillProgress[2].AddExp(5);
                    mana = mana - skillProgress[2].cost;
                    manaText.text = "" + mana;
                    manaBar.value = mana;
                }

            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (skillProgress.Count >= 4)
            {
                skillProgress[3].AddExp(5);

            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(skillProgress.Count >= 1)
            {
                if (mana >= skillProgress[0].cost)
                {
                    skillProgress[0].skillData.Use();
                    skillProgress[0].AddExp(5);
                    mana = mana - skillProgress[0].cost;
                    manaText.text = "" + mana;
                    manaBar.value = mana;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (skillProgress.Count >= 2)
            {
                if (mana >= skillProgress[1].cost)
                {
                    skillProgress[1].skillData.Use();
                    skillProgress[1].AddExp(5);
                    mana = mana - skillProgress[1].cost;
                    manaText.text = "" + mana;
                    manaBar.value = mana;
                }
            }
        }

        //Debug.Log("Mana: " + mana);
    }
}
