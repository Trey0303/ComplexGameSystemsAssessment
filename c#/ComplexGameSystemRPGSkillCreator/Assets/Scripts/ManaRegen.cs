using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegen : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(PlayerVariableData.mana < 100)
            {
                PlayerVariableData.mana = PlayerVariableData.mana + 1;
            }
        }
    }
}
