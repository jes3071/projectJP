using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public object _aaa = 0;

	// Use this for initialization
	void Start () {
        List<Dictionary<string, object>> data = CSVReader.Read("GameData - Card");

        for(var i = 0; i < data.Count; i++)
        {
            Debug.Log("index " + (i).ToString() + ": " + data[i]["ItemName"] + " " + data[i]["ItemDescription"] + " " + data[i]["ReinforceValue"] + " " +
                data[i]["TurnCost"] + " " + data[i]["CardType"] + " " + data[i]["DamageValue"]);
        }

        //_aaa = data[0]["ItemName"];
        //Debug.Log(_aaa);

    }
    
    // Update is called once per frame
    void Update () {
		
	}
}
