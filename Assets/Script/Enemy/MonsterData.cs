using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterData
{

    public string monsterName;
    public int monsterPrefabID;
    public int stageLevel;
    public string monsterDescription;
    public int hp;
    public int shield;
    public int blueSoul;
    public int maxRedSoul;
    public int exp;

    public MonsterData(string MonsterName, int MonsterPrefabID, int StageLevel, string MonsterDescription, int Hp,
        int Shield, int BlueSoul, int MaxRedSoul, int Exp)
    {
        monsterName = MonsterName;
        monsterPrefabID = MonsterPrefabID;
        stageLevel = StageLevel;
        monsterDescription = MonsterDescription;
        hp = Hp;
        shield = Shield;
        blueSoul = BlueSoul;
        maxRedSoul = MaxRedSoul;
        exp = Exp;
    }
}