using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
public class ChouEnemyCard : MonoBehaviour
{
    public GeneralThiaData enemyData;
    public GameObject tarGo;
    public string cardName;
    public bool isUpDateList=false;
    public GameObject ChouWeapon;
    public GameObject ChouArmor;
    public GameObject ChouJiaMa;
    public GameObject ChouJianMa;
    // Start is called before the first frame update
    void Start()
    {
         
       enemyData=GameObject.FindGameObjectWithTag("Enemy").GetComponent<GeneralThiaData>();
       isUpDateList=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isUpDateList){
            InCardGo();
            InEquipGo();
            isUpDateList=false;
        }
    }
    public void InEquipGo(){
        if(enemyData.weaponGo!=null){
            DisTarGoChild(ChouWeapon);
            GameObject weapon=Instantiate(enemyData.weaponGo);
            weapon.name=enemyData.weaponGo.name;
            weapon.transform.SetParent(ChouWeapon.transform);
            weapon.transform.localScale=Vector3.one;
            weapon.transform.localPosition=Vector3.zero;
            weapon.AddComponent<Toggle>();
        }
        if(enemyData.armorGo!=null){
            DisTarGoChild(ChouArmor);
            GameObject armor=Instantiate(enemyData.armorGo);
            armor.name=enemyData.weaponGo.name;
            armor.transform.SetParent(ChouArmor.transform);
            armor.transform.localScale=Vector3.one;
            armor.transform.localPosition=Vector3.zero;
            armor.AddComponent<Toggle>();
        }
        if(enemyData.jiaMaGo!=null){
            DisTarGoChild(ChouJiaMa);
            GameObject jiama=Instantiate(enemyData.jiaMaGo);
            jiama.name=enemyData.jiaMaGo.name;
            jiama.transform.SetParent(ChouJiaMa.transform);
            jiama.transform.localScale=Vector3.one;
            jiama.transform.localPosition=Vector3.zero;
            jiama.AddComponent<Toggle>();
        }
        if(enemyData.jianMaGo!=null){
            DisTarGoChild(ChouJianMa);
            GameObject jianma=Instantiate(enemyData.jianMaGo);
            jianma.name=enemyData.jianMaGo.name;
            jianma.transform.SetParent(ChouJianMa.transform);
            jianma.transform.localScale=Vector3.one;
            jianma.transform.localPosition=Vector3.zero;
            jianma.AddComponent<Toggle>();
        }
    }

    public void InCardGo(){
        if (enemyData == null)
    {
        Debug.LogError("Enemy data reference is null!");
        return; // 中止执行
    }
        if(enemyData.thisCard.Count>0){
            DisTarGoChild(tarGo);
            for(int i=0;i<enemyData.thisCard.Count;i++){
                GameObject card=Instantiate(enemyData.thisCard[i]);
                card.name=enemyData.thisCard[i].name;
                card.transform.SetParent(tarGo.transform);
                card.AddComponent<Toggle>();
                card.transform.localScale=Vector3.one;
                card.transform.localPosition=Vector3.zero;
            }
        }
    }
    public void DisTarGoChild(GameObject gameObject){
        for(int i=0;i<gameObject.transform.childCount;i++){
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }
}
