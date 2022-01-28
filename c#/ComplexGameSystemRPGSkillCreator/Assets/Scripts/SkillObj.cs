using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "SkillObjects/ScriptableSkills", order = 1)]
public class SkillObj : ScriptableObject
{
    public string skillName;
    public int damage;
    public int maxLevel;
    public int cost;
}
