using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Skill skill;

    public Slider manaBar;
    public Text manaAmount;
    public Text skillLvl;
    private int skillLvlCur;

    // Start is called before the first frame update
    void Start()
    {
        skill = GameObject.FindGameObjectWithTag("Player").GetComponent<Skill>();

        manaBar.value = PlayerVariableData.mana;
        manaAmount.text = "" + PlayerVariableData.mana;
        skillLvl.text = "" + skill.skill.level;
        skillLvlCur = skill.skill.level;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillLvlCur != skill.skill.level)
        {
            skillLvl.text = "" + skill.skill.level;
        }

        if(manaBar.value != PlayerVariableData.mana)
        {
            manaBar.value = PlayerVariableData.mana;
            manaAmount.text = "" + PlayerVariableData.mana;
        }
    }
}
