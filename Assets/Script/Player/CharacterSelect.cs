using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour {

    public GameObject character;
    public Sprite warriorImage;
    public Sprite magicianImage;
    public GameObject buttonOnOff;
    public GameObject warriorDes;
    public GameObject magicianDes;

	// Use this for initialization
	void Start ()
    {
        character = GameObject.Find("UILoobyCharacterSelectPopup").transform.Find("Character/CharacterImage").gameObject;
        buttonOnOff = GameObject.Find("UILoobyCharacterSelectPopup").transform.Find("Character/Button").gameObject;
        warriorDes = GameObject.Find("UILoobyCharacterSelectPopup").transform.Find("Cha0Description").gameObject;
        magicianDes = GameObject.Find("UILoobyCharacterSelectPopup").transform.Find("Cha1Description").gameObject;
        warriorDes.SetActive(true);
        warriorImage = Resources.Load<Sprite>("UI/Warrior");
        magicianImage = Resources.Load<Sprite>("UI/Magician");
    }
	
    public void NextButton()
    {
        if(character.GetComponent<Image>().sprite == warriorImage)
        {
            character.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Magician");
            magicianDes.SetActive(true);
            warriorDes.SetActive(false);
            buttonOnOff.GetComponent<Button>().interactable = false;
        }
        else
        {
            character.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Warrior");
            warriorDes.SetActive(true);
            magicianDes.SetActive(false);
            buttonOnOff.GetComponent<Button>().interactable = true;
        }
            
    }

    public void PrevButton()
    {
        if (character.GetComponent<Image>().sprite == warriorImage)
        {
            character.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Magician");
            magicianDes.SetActive(true);
            warriorDes.SetActive(false);
            buttonOnOff.GetComponent<Button>().interactable = false;
        }
        else
        {
            character.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Warrior");
            warriorDes.SetActive(true);
            magicianDes.SetActive(false);
            buttonOnOff.GetComponent<Button>().interactable = true;
        }
    }
}
