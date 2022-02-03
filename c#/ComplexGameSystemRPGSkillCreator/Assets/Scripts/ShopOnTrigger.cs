using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOnTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //Debug.Log("Player in range");
            PlayerVariableData.inShopRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player out of range");
            PlayerVariableData.inShopRange = false;
        }
    }
}
