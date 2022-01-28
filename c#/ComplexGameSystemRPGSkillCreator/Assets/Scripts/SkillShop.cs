using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShop : MonoBehaviour
{
    public List<SkillObj> shopList;

    public Button openShopMenu;
    public Button close;

    //menus to display
    public GameObject shopMenu;

    public int money;
    private int currentMoneyCount;

    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "0";
        PlayerVariableData.money = 0;
        currentMoneyCount = 0;
        shopMenu = GameObject.Find("ShopInventory");
        if(shopMenu != null)
        {
            shopMenu.SetActive(false);
            openShopMenu.gameObject.SetActive(true);
            close.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerVariableData.money != currentMoneyCount)
        {
            currentMoneyCount = PlayerVariableData.money;
            //Debug.Log("money: " + PlayerVariableData.money);
            //Debug.Log(currentMoneyCount);
            moneyText.text = currentMoneyCount + "";
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerVariableData.money = PlayerVariableData.money + 1;
        }
    }

    public void ShowShop()
    {
        shopMenu.SetActive(true);
        openShopMenu.gameObject.SetActive(false);
        close.gameObject.SetActive(true);
    }

    public void HideShop()
    {
        shopMenu.SetActive(false);
        openShopMenu.gameObject.SetActive(true);
        close.gameObject.SetActive(false);
    }

    void Buy()
    {


        if(PlayerVariableData.money >= shopList[1].cost)
        {

        }
    }
}
