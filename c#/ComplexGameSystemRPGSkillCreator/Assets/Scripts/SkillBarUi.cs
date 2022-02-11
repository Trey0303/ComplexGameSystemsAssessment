using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarUi : MonoBehaviour
{
    //public List<SkillObj> playerSkillProgress;

    public List<SkillObj> playerSkillObjs;

    public List<Button> skillWidget;

    //public Dictionary<SkillObj, Button> skillDictionary = new Dictionary<SkillObj, Button>();

    private void Start()
    {
        PlayerVariableData.skillAdded = false;
        //setup
        StartCoroutine(LateStart(.1f));
        


    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call

        for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress.Count; i++)
        {
            playerSkillObjs.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress[i].skillData);
            //playerSkillProgress[i] = GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress[i];
            PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);
            //skillWidget[i].gameObject.SetActive(false);
            DisplaySkill(playerSkillObjs[i], skillWidget[i]);



        }
    }

    private void Update()
    {
        if (PlayerVariableData.skillAdded)//if new skill added
        {
            for(int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress.Count; i++)
            {
                if(i < skillWidget.Count)//if there is enough buttons to display skill
                {
                    if(i == playerSkillObjs.Count)
                    {
                        playerSkillObjs.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress[i].skillData);
                        PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);
                        DisplaySkill(playerSkillObjs[i], skillWidget[i]);
                        PlayerVariableData.skillAdded = false;

                    }
                }

            }
        }
    }

    void DisplaySkill(SkillObj skillObj, Button widget)
    {
        widget.gameObject.GetComponentInChildren<Text>().text = skillObj.skillName;

        widget.gameObject.SetActive(true);
    }

    void RemoveSkill(SkillObj skillObj)
    {
        skillObj = null;
    }
}
