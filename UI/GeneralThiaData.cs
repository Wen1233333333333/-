using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Assertions.Must;
public class GeneralThiaData : MonoBehaviour
{
    public int currentHP;
    public int maxHP;
    public string currentNeedOutCardName;
    public string currentOutCardName;
    public GameObject currentClickCardGo;
    //public PlayerAndEnemy currentNeedOutCardName=PlayerAndEnemy.Player;
    public bool isNeedOutCard;
    public ChuPaiState chuPaiState;
    public PlayerAndEnemy playerAndEnemy;
    public bool isJiu;
    public bool isArmor;
    public bool isWeapon;
    public bool isJiaMa;
    public bool isJianMa;
    public bool isWuXie;
    public bool isOutWuXie;
    public bool isChouPai;
    public bool isJueDou;
    public int attackDis=1;
    public int outShaNum=1;
    public int outJinNangDis=1;
    public int ziShenDis=1;

    public EnemyAI enemyAI;
    public PlayerController playerController;

    public PlayerAndEnemy currentPlayerAndEnemy;
    public List<GameObject>thisCard=new List<GameObject>();//自身卡牌列表
    public List<GameObject>thisEquipCardGo=new List<GameObject>();//装备游戏物体列表
    public List<GameObject>cardGo =new List<GameObject>();//全部的卡牌列表
    public AudioController audioController;
    private Transform tarGetPos;
    public GameObject weaponGo;
    public GameObject armorGo;
    public GameObject jianMaGo;
    public GameObject jiaMaGo;
    // Start is called before the first frame update
    void Start()
    {
        audioController=GetComponent<AudioController>();
        tarGetPos=GameObject.Find("TarGetPos").transform ;
        enemyAI=GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
        playerController=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetThisEquipGo();
        if (Input.GetKeyDown(KeyCode.S))
    {
        ThisCard(playerAndEnemy); // 获取玩家的卡牌
    }
    // if (Input.GetKeyDown(KeyCode.D))
    // {
    //     OutCard(currentClickCardGo); 
    // }
    if(playerAndEnemy==PlayerAndEnemy.Player ){
        if (Input.GetKeyDown(KeyCode.D))
    {
        OutCard(currentClickCardGo); 
    }
    }
    }   
    //获取有没有装备
    public void GetThisEquipGo(){
        if(playerAndEnemy==PlayerAndEnemy.Player){
            if(isWeapon==true&&GameObject.Find("PlayerWeapon").transform.childCount>0){
                weaponGo=GameObject.Find("PlayerWeapon").transform.GetChild(0).gameObject;
            }
            else{
                isWeapon=false;
            }
            //防具
            if(isArmor==true&&GameObject.Find("PlayerArmor").transform.childCount>0){
                armorGo=GameObject.Find("PlayerArmor").transform.GetChild(0).gameObject;
            }
            else{
                isArmor=false;
            }
            //加马
            if(isJiaMa==true&&GameObject.Find("PlayerJiaMa").transform.childCount>0){
                jiaMaGo=GameObject.Find("PlayerJiaMa").transform.GetChild(0).gameObject;
            }
            else{
                isJiaMa=false;
            }
            //减马
            if(isJianMa==true&&GameObject.Find("PlayerJianMa").transform.childCount>0){
                jianMaGo=GameObject.Find("PlayerJianMa").transform.GetChild(0).gameObject;
            }
            else{
                isJianMa=false;
            }
        }
        if(playerAndEnemy==PlayerAndEnemy.Enemy){
            if(isWeapon==true&&GameObject.Find("EnemyWeapon").transform.childCount>0){
                weaponGo=GameObject.Find("EnemyWeapon").transform.GetChild(0).gameObject;
            }
            else{
                isWeapon=false;
            }
            //防具
            if(isArmor==true&&GameObject.Find("EnemyArmor").transform.childCount>0){
                armorGo=GameObject.Find("EnemyArmor").transform.GetChild(0).gameObject;
            }
            else{
                isArmor=false;
            }
            //加马
            if(isJiaMa==true&&GameObject.Find("EnemyJiaMa").transform.childCount>0){
                jiaMaGo=GameObject.Find("EnemyJiaMa").transform.GetChild(0).gameObject;
            }
            else{
                isJiaMa=false;
            }
            //减马
            if(isJianMa==true&&GameObject.Find("EnemyJianMa").transform.childCount>0){
                jianMaGo=GameObject.Find("EnemyJianMa").transform.GetChild(0).gameObject;
            }
            else{
                isJianMa=false;
            }
        }
    } 
    public void OutCard(GameObject Go){
        if(thisCard.Count!=0){
            for(int i=0;i<thisCard.Count;i++){
                if(thisCard[i]==null)return;
                if(playerAndEnemy==PlayerAndEnemy.Player){
                    if(thisCard[i].name==Go.name&&thisCard[i].gameObject.GetComponent<Toggle>().isOn==true){
                        if(Go.name=="Sha"&&chuPaiState==ChuPaiState.MayChuPai){
                            outShaNum-=1;
                        }
                        if(Go.name=="WuXieKeJi"){
                            isWuXie=false;
                            isOutWuXie=true;
                            audioController.PlayAudio(Go.name);
                            StartCoroutine(currentOutCardName);
                            StartCoroutine(FunctionCard(thisCard[i].name));
                            thisCard[i].gameObject.GetComponent<Toggle>().graphic=null;
                            OutCardMoveTarGetPos(thisCard[i]);
                           
                        }
                        else{
                            audioController.PlayAudio(Go.name);
                            StartCoroutine(FunctionCard(thisCard[i].name));
                            thisCard[i].gameObject.GetComponent<Toggle>().graphic=null;
                            OutCardMoveTarGetPos(thisCard[i]);
                        }
                        currentClickCardGo=null;
                        //打出牌
                        StartCoroutine(FunctionCard(thisCard[i].name));
                        audioController.PlayAudio(thisCard[i].name);
                        OutCardMoveTarGetPos(thisCard[i]);
                    }
                }
                if(playerAndEnemy==PlayerAndEnemy.Enemy){
                    if(thisCard[i].name==Go.name&&Go!=null){
                    if(currentNeedOutCardName==Go.name&&chuPaiState==ChuPaiState.NeedOutPai){
                        if(Go.name=="WuXieKeJi"){
                            thisCard[i].GetComponent<Image>().sprite=GetcardGo(Go.name).GetComponent<Image>().sprite;
                            playerController.thisData.isWuXie=true;
                            isOutWuXie=true;
                            audioController.PlayAudio(Go.name);
                            StartCoroutine(FunctionCard(thisCard[i].name));
                            OutCardMoveTarGetPos(thisCard[i]);
                            chuPaiState=ChuPaiState.Wait;

                        }else{
                            thisCard[i].GetComponent<Image>().sprite=GetcardGo(Go.name).GetComponent<Image>().sprite;
                            audioController.PlayAudio(Go.name);
                            StartCoroutine(FunctionCard(thisCard[i].name));
                            OutCardMoveTarGetPos(thisCard[i]);
                            chuPaiState=ChuPaiState.Wait;
                        }
                     }
                     if(chuPaiState==ChuPaiState.MayChuPai){
                        if(Go.name=="Sha"){
                            outShaNum-=1;
                        }
                        thisCard[i].GetComponent<Image>().sprite=GetcardGo(Go.name).GetComponent<Image>().sprite;
                        audioController.PlayAudio(Go.name);
                        StartCoroutine(FunctionCard(thisCard[i].name));
                        OutCardMoveTarGetPos(thisCard[i]);
                        chuPaiState=ChuPaiState.Wait;
                     }
                    }
                }
            }
        }
    }
    IEnumerator FunctionCard(string name){
        yield return 0;
        if(playerAndEnemy==PlayerAndEnemy.Player){
            switch(name){
                    case "Sha":
                        if(chuPaiState==ChuPaiState.MayChuPai&&isJueDou==false&&enemyAI.thisData.isJueDou==false){
                            if(isJiu==false){
                                enemyAI.PlayerPlayCard(name,1);
                            }
                            else{
                                enemyAI.PlayerPlayCard(name,2);
                            }
                             }
                        if(isJueDou==true||enemyAI.thisData.isJueDou==true){
                                enemyAI.PlayerPlayCard(name,1);
                            }
                        break;
                    case "Shan":
                        // 处理闪的逻辑
                        break;
                    case "Tao":
                        AddHP(1);
                        break;
                    case "Jiu":
                        isJiu=true  ;
                        break;
                    case "GuoHeChaiQiao":
                        // 处理过河拆桥的逻辑
                        enemyAI.PlayerPlayCard(name,0);
                        currentOutCardName=name;
                        break;
                    case "ShunShouQianYang":
                        // 处理顺手牵羊的逻辑
                        break;
                    case "JieDaoShaRen":
                        // 处理借刀杀人的逻辑
                        break;
                    case "JueDou":
                        // 处理决斗的逻辑
                        break;
                    case "WuZhongShengYou":
                        // 处理无中生有的逻辑
                        break;
                    case "WuXieKeJi":
                        // 处理无懈可击的逻辑
                        break;
                    case "ZhuGeLianNu":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=1;
                        break;
                    case "QingLongYanYueDao":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "BaiYinShiZi":
                        isArmor=true;
                        Equip(name,EqiupType.Armor,playerAndEnemy);
                        break;
                    case "BaGuaZhen":
                        isArmor=true;
                        Equip(name,EqiupType.Armor,playerAndEnemy);
                        break;
                    case "CiXiongShuangJian":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=2;
                        break;
                    case "JiaMa":
                        isJiaMa=true;
                        Equip(name,EqiupType.JiaMa,playerAndEnemy);
                        ziShenDis=2;
                        break;
                    case "JianMa":
                        isJianMa=true;
                        Equip(name,EqiupType.JianMa,playerAndEnemy);
                        outJinNangDis=2;
                        break;
                    case "GuanShiFu":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "ZhangBaSheMao":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "QingGangJian":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=2;
                        break;
                    case "QiLinGong":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=5;
                        break;
                    case "ZhuQueYuShan":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=5;
                        break;
                    default:
                        // 处理未匹配的情况
                        break;

            }
            if(playerAndEnemy==PlayerAndEnemy.Enemy){
            switch(name){
                case "Sha":
                break;
                case "Shan":
                        // 处理闪的逻辑
                        break;
                    case "Tao":
                        // 处理桃的逻辑
                        break;
                    case "Jiu":
                        // 处理酒的逻辑
                        break;
                    case "GuoHeChaiQiao":
                        // 处理过河拆桥的逻辑
                        break;
                    case "ShunShouQianYang":
                        // 处理顺手牵羊的逻辑
                        break;
                    case "JieDaoShaRen":
                        // 处理借刀杀人的逻辑
                        break;
                    case "JueDou":
                        // 处理决斗的逻辑
                        break;
                    case "WuZhongShengYou":
                        // 处理无中生有的逻辑
                        break;
                    case "WuXieKeJi":
                        // 处理无懈可击的逻辑
                        break;
                    case "ZhuGeLianNu":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=1;
                        break;
                    case "QingLongYanYueDao":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "BaiYinShiZi":
                        isArmor=true;
                        Equip(name,EqiupType.Armor,playerAndEnemy);
                        break;
                    case "BaGuaZhen":
                        isArmor=true;
                        Equip(name,EqiupType.Armor,playerAndEnemy);
                        break;
                    case "CiXiongShuangJian":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=2;
                        break;
                    case "JiaMa":
                        isJiaMa=true;
                        Equip(name,EqiupType.JiaMa,playerAndEnemy);
                        ziShenDis=2;
                        break;
                    case "JianMa":
                        isJianMa=true;
                        Equip(name,EqiupType.JianMa,playerAndEnemy);
                        outJinNangDis=2;
                        break;
                    case "GuanShiFu":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "ZhangBaSheMao":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=3;
                        break;
                    case "QingGangJian":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=2;
                        break;
                    case "QiLinGong":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=5;
                        break;
                    case "ZhuQueYuShan":
                        isWeapon=true;
                        Equip(name,EqiupType.Weapon,playerAndEnemy);
                        attackDis=5;
                        break;
                    default:
                        // 处理未匹配的情况
                        break;

            }
        }
    }}
    //穿装备的方法
    public void Equip(string name,EqiupType eqiupType,PlayerAndEnemy  playerAndEnemy){
        audioController.PlayAudio("ZhuangBei");
        GameObject go=Instantiate(GetThisEquipGo(name));
        go.name=name;
        Transform ts=null;
        switch(eqiupType){
            case EqiupType.Armor:
            if(playerAndEnemy==PlayerAndEnemy.Player){
                ts=GameObject.Find("PlayerArmor").transform;
            }
            if(playerAndEnemy==PlayerAndEnemy.Enemy){
                ts=GameObject.Find("EnemyArmor").transform;
            }
            break;
             case EqiupType.Weapon:
             if(playerAndEnemy==PlayerAndEnemy.Player){
                ts=GameObject.Find("PlayerWeapon").transform;
            }
            if(playerAndEnemy==PlayerAndEnemy.Enemy){
                ts=GameObject.Find("EnemyWeapon").transform;
            }
            break;
             case EqiupType.JianMa:
             if(playerAndEnemy==PlayerAndEnemy.Player){
                ts=GameObject.Find("PlayerJianMa").transform;
            }
            if(playerAndEnemy==PlayerAndEnemy.Enemy){
                ts=GameObject.Find("EnemyJianMa").transform;
            }
            break;
             case EqiupType.JiaMa:
             if(playerAndEnemy==PlayerAndEnemy.Player){
                ts=GameObject.Find("PlayerJiaMa").transform;
            }
            if(playerAndEnemy==PlayerAndEnemy.Enemy){
                ts=GameObject.Find("EnemyJiaMa").transform;
            }
            break;
            default:
            break;
        }
        if(ts!=null){
            if (ts.childCount > 0)
        {
            Destroy(ts.GetChild(0).gameObject);
        }
        }
        go.transform.SetParent(ts);
        go.transform.localPosition=Vector3.zero;
        go.transform.localScale=Vector3.one;
    }
        //获取自身卡牌的游戏物体
    public GameObject GetThisCardGo(string name){

        for(int i=0;i<thisCard.Count ;i++){
            if(thisCard [i].name==name){
                return thisCard[i].gameObject;
            }
        }
        return null;
    }
     ///获取自身装备卡牌的游戏物体
    public GameObject GetThisEquipGo(string name){

        for(int i=0;i<thisEquipCardGo.Count ;i++){
            if(thisEquipCardGo[i].name==name){
                return thisEquipCardGo[i].gameObject;
            }
        }
        return null;
    } 
    //获取卡牌的游戏物体
    public GameObject GetcardGo(string name){

        for(int i=0;i<cardGo.Count ;i++){
            
            if(cardGo[i].name==name){
                return cardGo[i].gameObject;
            }
        }
        return null;
    }
    public void OutCardMoveTarGetPos(GameObject gameObject){
        if(currentPlayerAndEnemy== PlayerAndEnemy.Player){
            Destroy(gameObject.transform.GetComponent<Toggle>());
        }
            gameObject.GetComponent<Image>().sprite=GetcardGo(gameObject.name).GetComponent<Image>().sprite;
            gameObject.transform.DOMove(tarGetPos.position,0.5f).OnComplete(()=>
            {
                DestroyCard(gameObject);
                
            }
            );
    }
    //造成伤害
    public void Hit(int damage){
        currentHP-=damage;
        audioController.PlayAudio("Hit");

    }
    //加血
    public void AddHP(int number){
        if(currentHP<maxHP){
            currentHP+=number;
            audioController.PlayAudio("Tao");
        }
    }
    //移除牌
    public void DestroyCard(GameObject gameObject){
        thisCard.Remove(gameObject);
        
        Destroy(gameObject);
    }
    //
    //获取子物体放到列表中
    public void FindChild(GameObject Go){

        for(int i=0;i<Go.transform.childCount;i++){
            if(Go.transform.GetChild(0).childCount>0){
                FindChild(Go.transform.GetChild(i).gameObject);
            }
            thisCard.Add(Go.transform.GetChild(i).gameObject);
        }
    }
    //弃牌方法
    public void DisCard(string name){
        for(int i=0;i<thisCard.Count;i++){
            if(thisCard[i].name==name&&thisCard[i].gameObject.GetComponent<Toggle>().isOn==true){
                OutCardMoveTarGetPos(thisCard[i].gameObject);
            }
        }
    }
    //更新自身牌列表
    public void ThisCard(PlayerAndEnemy playerAndEnemy){
        if(playerAndEnemy==PlayerAndEnemy.Player){
            thisCard.RemoveRange(0,thisCard.Count);
            FindChild(GameObject.Find("PlayerCardList").gameObject);
        }
        if(playerAndEnemy==PlayerAndEnemy.Enemy){
            thisCard.RemoveRange(0,thisCard.Count);
            FindChild(GameObject.Find("EnemyCardList").gameObject);
        }
    }
    
}
