using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatchaSystem : MonoBehaviour {

    public List<string> GatchaList = new List<string>() { "용사의 검", "이순신의 투구", "엘프의 활", "드워프의 망치", "프리스트의 십자가" };
    public List<string> ResultList = new List<string>();

        public void Gatcha()
    {
        for(int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, GatchaList.Count);
            Debug.Log(GatchaList[rand]);
            GatchaList.RemoveAt(rand);
        }
    }

    
}
