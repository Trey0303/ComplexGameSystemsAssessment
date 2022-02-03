using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillShop : MonoBehaviour
{
    public List<SkillObj> shopList;

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
        moneyText.text = "0";
        moneyTextPlayerUI.text = "0";
        PlayerVariableData.money = 0;
        currentMoneyCount = 0;
        shopMenu = GameObject.Find("ShopInventory");
        playerUI = GameObject.Find("PlayerUI");

        //assign name, damage, cost to shop list
        for (int i = 0; i < shopList.Count; i++)
        {
            names[i].text = shopList[i].skillName;
            damage[i].text = shopList[i].damage + "";
            cost[i].text = shopList[i].cost + "";
            itemsOwn[i].text = "Not Own";

            //if player cant afford skill
            if (PlayerVariableData.money < shopList[i].cost)
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
        if(PlayerVariableData.money != currentMoneyCount)
        {
            currentMoneyCount = PlayerVariableData.money;
            //Debug.Log("money: " + PlayerVariableData.money);
            //Debug.Log(currentMoneyCount);
            moneyText.text = currentMoneyCount + "";
            moneyTextPlayerUI.text = currentMoneyCount + "";

            //update button color
            for (int i = 0; i < shopList.Count; i++)
            {
                //if player cant afford skill
                if (PlayerVariableData.money < shopList[i].cost)
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

        //Debug.Log(selectedButton.name);

        for(int i = 0; i < shopList.Count; i++)
        {
            //Debug.Log("Selected Button: " + selectedButton.name);
            //Debug.Log("Button List: " + i);
            
            //if selected button is found in button list
            if(selectedButton == buyButtons[i].gameObject)
            {
                //check if player has enough money
                if(PlayerVariableData.money >= shopList[i].cost)
                {
                   //buy item
                   PlayerVariableData.money = PlayerVariableData.money - shopList[i].cost;
                   itemsOwn[i].text = "Own";
                   // Debug.Log(itemsOwn[i].text);
                   buyButtons[i].gameObject.SetActive(false);

                }
                


            }
        }




        
    }


}
