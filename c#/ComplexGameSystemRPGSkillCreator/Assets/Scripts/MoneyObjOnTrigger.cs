using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoneyObjOnTrigger : MonoBehaviour
{
    public Button moneyIncreaseButton;
    public bool inRange;
    public bool buttonActive;

    private void Start()
    {
        inRange = false;
        buttonActive = false;
        moneyIncreaseButton.interactable = false;

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
        if (inRange && !buttonActive)
        {
            buttonActive = true;
            moneyIncreaseButton.interactable = true;
        }
        if (!inRange && buttonActive)
        {
            moneyIncreaseButton.interactable = false;
            buttonActive = false;
        }
    }


    public void GetMoney()
    {
        //Debug.Log("button pressed");
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
