using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBarUi : MonoBehaviour
{
    public Skill skills;

    public List<SkillObj> playerSkillObjs;

    public List<Button> skillWidget;
    public Button buttonPrefab;

    public Button tempButton { get; private set; }

    public GameObject buttonSpawnPoint;

    public GameObject canvasUI;
    private int lastManaCheck;

    private void Start()
    {
        buttonSpawnPoint = canvasUI;

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

        lastManaCheck = PlayerVariableData.mana;

        if (GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress.Count > 0)
        {
            for (int i = 0; i < GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress.Count; i++)
            {
                if(i < skillWidget.Count)
                {
                    //add skill to playerSkillObjs list
                    playerSkillObjs.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>().skillProgress[i].skillData);

                    //create new button
                    skillWidget[i] = Instantiate(buttonPrefab, buttonSpawnPoint.transform.position, Quaternion.identity);

                    //set as child inside canvus
                    skillWidget[i].transform.SetParent(canvasUI.transform);

                    //update spawnpoint
                    buttonSpawnPoint = skillWidget[i].gameObject;
                    skillWidget[i].transform.localPosition = new Vector3(skillWidget[i].transform.localPosition.x + 60, skillWidget[i].transform.localPosition.y);

                    //match playerSkillObjs with skillwidget
                    PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);

                    //display skill
                    DisplaySkill(playerSkillObjs[i], skillWidget[i]);

                }
            }

        }

        //mana check
        if (skills.skillProgress.Count != 0)
        {
            for (int i = 0; i < skills.skillProgress.Count; i++)
            {
                if (skills.skillProgress.Count >= i)
                {
                    if (PlayerVariableData.skillDictionary[skills.skillProgress[i].skillData] != null)
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
                        skillWidget[i] = Instantiate(buttonPrefab, buttonSpawnPoint.transform.position, Quaternion.identity);

                        //set it as a child inside canvas
                        skillWidget[i].transform.SetParent(canvasUI.transform);

                        //update spawn point 
                        buttonSpawnPoint = skillWidget[i].gameObject;
                        skillWidget[i].transform.localPosition = new Vector3(skillWidget[i].transform.localPosition.x + 60, skillWidget[i].transform.localPosition.y);

                        //store skill and button into dictionary
                        PlayerVariableData.skillDictionary.Add(playerSkillObjs[i], skillWidget[i]);

                        //display skill on screen
                        DisplaySkill(playerSkillObjs[i], skillWidget[i]);
                        PlayerVariableData.skillToAdd = false;
                    }
                }
                else
                {
                    PlayerVariableData.skillToAdd = false;
                    //Debug.Log("cant add any more skills");
                }

            }
        }


        // update the status of all of the buttons
        if (lastManaCheck != PlayerVariableData.mana)
        {
            if (skills.skillProgress.Count != 0)
            {
                for (int i = 0; i < skills.skillProgress.Count; i++)
                {
                    if (skills.skillProgress.Count >= i)
                    {
                        if (PlayerVariableData.skillDictionary.ContainsKey(skills.skillProgress[i].skillData) &&
                            skillWidget[i] != null)
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
