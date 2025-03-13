using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GeneralThiaData thisData;
    // Start is called before the first frame update
    void Awake()
    {
        thisData=GetComponent<GeneralThiaData>();
        if (thisData == null)
    {
        Debug.LogError("PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPlayer data is not initialized!");
        return; // 中止执行
    }
        
        thisData.playerAndEnemy=PlayerAndEnemy.Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
