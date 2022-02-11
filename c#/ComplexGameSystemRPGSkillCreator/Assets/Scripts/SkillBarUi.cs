using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarUi : MonoBehaviour
{
    List<Skill> playerSkills;

    public List<Button> skillWidget;

    Dictionary<SkillObj, Button> skillDictionary = new Dictionary<SkillObj, Button>();

    private void Start()
    {
        //setup
        for(int i = 0; i < skillWidget.Count; i++)
        {
            playerSkills[i] = GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>();
            skillDictionary.Add(playerSkills[i].skillProgress[i].skillData, skillWidget[i]);
            skillWidget[i].gameObject.SetActive(false);
        }

    }

    //Dictionary<SkillObj, skillWidget>

    void DisplaySkill(SkillObj skillData, int widget)
    {
        skillWidget[widget].gameObject.GetComponentInChildren<Text>().text = skillData.skillName;

        skillWidget[widget].gameObject.SetActive(true);
    }

    void RemoveSkill(SkillObj skillObj)
    {
        
    }
}
