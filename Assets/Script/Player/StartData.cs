using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StartData
{
    public string characterName;
    public int characterOpen;
    public int blueSoul;
    public int redSoul;
    public int lv;
    public int hp;
    public int shield;
    public int exp;
    public int stageLevel;

    public StartData(string CharacterName, int CharacterOpen, int BlueSoul, int RedSoul, int Lv, int Hp,
        int Shield, int Exp, int StageLevel)
    {
        characterName = CharacterName;
        characterOpen = CharacterOpen;
        blueSoul = BlueSoul;
        redSoul = RedSoul;
        lv = Lv;
        hp = Hp;
        shield = Shield;
        blueSoul = BlueSoul;
        exp = Exp;
    }
}
