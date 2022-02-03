using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyObjOnTrigger : MonoBehaviour
{
    //public Button moneyIncreaseButton;
    private bool inRange;

    private void Start()
    {
        inRange = false;
    }
     
    private void Update()
    {
        //increase amount of money if in range and key was pressed
        if (inRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GetMoney();
            }
        }
    }

    public void GetMoneyOnClick()
    {
        Debug.Log("button pressed");
        //GetMoney();
    }

    public void GetMoney()
    {
        PlayerVariableData.money = PlayerVariableData.money + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player in range");
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player out of range");
            inRange = false;
        }
    }
}
