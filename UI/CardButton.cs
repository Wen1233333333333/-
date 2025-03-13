using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class CardButton : MonoBehaviour
{
    public  Toggle toggle;
    public GeneralThiaData generalThiaData;
    // Start is called before the first frame update
    
   void Start()
{
    
    toggle = GetComponent<Toggle>();
    
   toggle.onValueChanged.AddListener(OnToggleValueChanged);
    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    
    if (playerObject == null)
    {
        Debug.LogError("Player GameObject not found!");
        return; // 提前返回，避免后续错误
    }

    Debug.Log("Found Player GameObject: " + playerObject.name);
    generalThiaData = GameObject.FindGameObjectWithTag("Player").GetComponent<GeneralThiaData>();
    if (generalThiaData == null)
    {
        Debug.LogError("GeneralThiaData component not found on Player.");
    }
}

    // Update is called once per frame
    void Update()
    {
        if(toggle==null)return;
        if(toggle.group ==null){
            toggle.group=transform.parent.gameObject.GetComponent<ToggleGroup>();
        }
    }
    public void OnToggleValueChanged(bool isOn)
{
    if (isOn)
    {
        Debug.Log("Toggle is ON");
        Sel_toggle(true);
    }
    else
    {
        Debug.Log("Toggle is OFF");
        Sel_toggle(false);
    }
}

public void Sel_toggle(bool Selete)
{
    if (Selete)
    {
        Tween tween = gameObject.transform.DOMove(transform.position + new Vector3(0, 30, 0), 0.1f);
        tween.SetAutoKill(false);
        generalThiaData.currentClickCardGo = transform.gameObject; // 正确赋值
        Debug.Log("Assigned currentClickCardGo: " + generalThiaData.currentClickCardGo.name); // 调试信息
    }
    else
    {
        gameObject.transform.DOPlayBackwards();
    }
}
}
