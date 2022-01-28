using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSkillData : MonoBehaviour
{
    //string currentName = "";
    //string currentType = "";
    //int currentDamage = 0;
    //float currentRange = 1.0f;
    //int currentMax_level = 1;
    //int currentSkillLvl = 1;

    //void Start()
    //{
    //    SaveFile();
    //    LoadFile();
    //}

    //public void SaveFile()
    //{
    //    string destination = Application.persistentDataPath + "/save.dat";
    //    FileStream file;

    //    if (File.Exists(destination)) file = File.OpenWrite(destination);
    //    else file = File.Create(destination);

    //    SkillData data = new SkillData(currentName, currentType, currentDamage, currentRange, currentMax_level, currentSkillLvl);
    //    BinaryFormatter bf = new BinaryFormatter();
    //    bf.Serialize(file, data);
    //    file.Close();
    //}

    //public void LoadFile()
    //{
    //    string destination = Application.persistentDataPath + "/save.dat";
    //    FileStream file;

    //    if (File.Exists(destination)) file = File.OpenRead(destination);
    //    else
    //    {
    //        Debug.LogError("File not found");
    //        return;
    //    }

    //    BinaryFormatter bf = new BinaryFormatter();
    //    SkillData data = (SkillData)bf.Deserialize(file);
        
    //    file.Close();

    //    currentName = data.name;
    //    currentType = data.type;
    //    currentDamage = data.damage;
    //    currentRange = data.range;
    //    currentMax_level = data.maxLevel;
    //    currentSkillLvl = data.skillLvl;

    //    Debug.Log(data.name);
    //}
}
