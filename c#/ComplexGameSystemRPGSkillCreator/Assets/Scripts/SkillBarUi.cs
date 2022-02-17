using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarUi : MonoBehaviour
{
    public Skill skills;

    public List<SkillObj> playerSkillObjs;

    public List<Button> skillWidget;

    public Button tempButton { get; private set; }

    private void Start()
    {
        tempButton = null;

        skills = GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>();

        PlayerVariableData.skillToAdd = false;
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

            PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);

            DisplaySkill(playerSkillObjs[i], skillWidget[i]);

            


        }
    }

    private void Update()
    {
        // if new skill added, add a button for it
        if (PlayerVariableData.skillToAdd)
        {
            for(int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress.Count; i++)
            {
                if(i < skillWidget.Count)//if there is enough buttons to display skill
                {
                    if(i == playerSkillObjs.Count)
                    {
                        //add skill to playerskillobj list
                        playerSkillObjs.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress[i].skillData);

                        //TO DO: Create and add new button to skill dictionary 
                        //skillWidget.Add();

                        //store skill and button into dictionary
                        PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);
                        //display skill on screen
                        DisplaySkill(playerSkillObjs[i], skillWidget[i]);
                        PlayerVariableData.skillToAdd = false;
                    }
                }

            }
        }


        // update the status of all of the buttons
        if(skills.skillProgress.Count != 0)
        {
            for(int i = 0; i < skills.skillProgress.Count; i++)
            {
                if (skills.skillProgress.Count >= i)
                {
                    if (skills.skillReady(i))//if skill can be used
                    {
                        tempButton = PlayerVariableData.skillDictionary[skills.skillProgress[i].skillData];
                        tempButton.interactable = true;
                    }
                    else
                    {
                        tempButton = PlayerVariableData.skillDictionary[skills.skillProgress[i].skillData];
                        tempButton.interactable = false;
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
