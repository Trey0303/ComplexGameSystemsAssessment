using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillShopVTwo : MonoBehaviour
{
    public Skill skillScript;

    

    public string taggedGameobjectWithSkillScript;

    //public List<SkillObj> shopList;

    public List<SkillProgress> skillShop = new List<SkillProgress>();

    SkillBarUi skillbarUi;

    public List<Text> names;

    public List<Text> damage;

    public List<Text> cost;

    public List<Text> itemsOwn;

    public List<Button> buyButtons;
    public static GameObject selectedButton;

    public Button openShopMenu;
    public Button close;

    //menus to display
    public GameObject shopMenu;

    public int money;
    private int currentMoneyCount;

    public Text moneyText;
    private bool shopMenuActive;

    public GameObject playerUI;
    public Text moneyTextPlayerUI;

    // Start is called before the first frame update
    void Start()
    {

        skillScript = GameObject.FindGameObjectWithTag(taggedGameobjectWithSkillScript).GetComponent<Skill>();

        skillbarUi = GameObject.Find("Panel").GetComponent<SkillBarUi>();

        moneyText.text = "0";
        moneyTextPlayerUI.text = "0";
        PlayerVariableData.money = 0;
        currentMoneyCount = 0;
        shopMenu = GameObject.Find("ShopInventory");
        playerUI = GameObject.Find("PlayerUI");

        openShopMenu.interactable = false;

        for (int j = 0; j < skillShop.Count; j++)
        {
            //setup shop
            int count = 0;
            skillShop[j].AddSkill();
            names[j].text = skillShop[j].skillData.skillName;
            damage[j].text = skillShop[j].damage + "";
            cost[j].text = skillShop[j].cost + "";

            //check if player already owns this skill
            for(int i = 0; i < skillScript.skillProgress.Count; i++)
            {
                if(skillShop[j].name != skillScript.skillProgress[i].name)
                {
                    count++;
                    if(count == skillScript.skillProgress.Count)
                    {
                        itemsOwn[j].text = "Not Own";

                    }
                }
                else if(skillScript.skillProgress[i].name == skillShop[j].name)
                {
                    itemsOwn[j].text = "Own";
                    buyButtons[j].gameObject.SetActive(false);
                }
            }

            //if player cant afford skill
            if (PlayerVariableData.money < skillShop[j].cost)
            {
                //Debug.Log("NOT ENOUGH MONEY FOR THIS SKILL");
                //cb.normalColor = unavailableColor;
                buyButtons[j].interactable = false;
            }
            else
            {
                buyButtons[j].interactable = true;
            }
        }

        //how playerUI at startup
        if (playerUI != null)
        {
            playerUI.SetActive(true);
        }

        //hide shop at startup
        if (shopMenu != null)
        {
            shopMenu.SetActive(false);
            openShopMenu.gameObject.SetActive(true);
            close.gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //if player lost or earned money then update ui to reflect that
        if (PlayerVariableData.money != currentMoneyCount)
        {
            currentMoneyCount = PlayerVariableData.money;
            //Debug.Log("money: " + PlayerVariableData.money);
            //Debug.Log(currentMoneyCount);
            moneyText.text = currentMoneyCount + "";
            moneyTextPlayerUI.text = currentMoneyCount + "";

            //update button color
            for (int i = 0; i < skillShop.Count; i++)
            {
                //if player cant afford skill
                if (PlayerVariableData.money < skillShop[i].cost)
                {
                    //Debug.Log("NOT ENOUGH MONEY FOR THIS SKILL");
                    //cb.normalColor = unavailableColor;
                    buyButtons[i].interactable = false;
                }
                else
                {
                    buyButtons[i].interactable = true;
                }
            }
        }



        if (PlayerVariableData.inShopRange)//if player is in shop range
        {
            openShopMenu.interactable = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!shopMenuActive)//if player wants to open shop menu
                {
                    ShowShop();


                }
                else if (shopMenuActive)//if player wants to exit shop menu
                {
                    HideShop();


                }

            }
        }
        if (!PlayerVariableData.inShopRange && shopMenuActive)//if player leaves shop range, close shop menu
        {
            HideShop();
            shopMenuActive = false;
        }
        if (!PlayerVariableData.inShopRange)
        {
            openShopMenu.interactable = false;
        }
    }

    public void ShowShop()
    {
        shopMenu.SetActive(true);
        openShopMenu.gameObject.SetActive(false);
        close.gameObject.SetActive(true);

        shopMenuActive = true;

        if (!PlayerVariableData.inShopRange && shopMenuActive)//check if shop menu should be open
        {
            HideShop();
        }
    }

    public void HideShop()
    {
        shopMenu.SetActive(false);
        openShopMenu.gameObject.SetActive(true);
        close.gameObject.SetActive(false);

        shopMenuActive = false;

    }

    public void Buy()
    {
        //gets gameobject from currenly selected button
        selectedButton = EventSystem.current.currentSelectedGameObject;

        for (int i = 0; i < skillShop.Count; i++)
        {

            //if selected button is found in button list
            if (selectedButton == buyButtons[i].gameObject)
            {
                //check if player has enough money
                if (PlayerVariableData.money >= skillShop[i].cost)
                {
                    //buy item
                    PlayerVariableData.money = PlayerVariableData.money - skillShop[i].cost;
                    itemsOwn[i].text = "Own";
                    buyButtons[i].gameObject.SetActive(false);

                    //add skill to player skills list
                    for (int j = 0; j <= skillScript.skillProgress.Count; j++)
                    {
                        if (j == skillScript.skillProgress.Count)
                        {
                            skillScript.skillProgress.Add(skillShop[i]);
                            

                            PlayerVariableData.skillAdded = true;

                            return;

                        }
                    }

                }
            }

        }
        for (int j = 0; j < skillScript.skillProgress.Count; j++)
        {
            Debug.Log(skillScript.skillProgress[j].name);

        }

    }
}


