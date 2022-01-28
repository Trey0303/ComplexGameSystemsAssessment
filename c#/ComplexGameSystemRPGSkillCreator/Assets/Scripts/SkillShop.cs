using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShop : MonoBehaviour
{
    public List<SkillObj> shopList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Buy();
            Debug.Log("money: " + PlayerVariableData.money);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerVariableData.money = PlayerVariableData.money + 1;
        }
    }

    void Buy()
    {


        if(PlayerVariableData.money >= shopList[1].cost)
        {

        }
    }
}
