using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public PlayerController playerController;
    public GeneralThiaData thisData;
    // Start is called before the first frame update
    void Awake()
    {
        thisData=GetComponent<GeneralThiaData>();
        thisData.playerAndEnemy=PlayerAndEnemy.Enemy;
        playerController=GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //需要出的牌
    public void ReceiveCardPlay(string name){
        thisData.currentNeedOutCardName =name;
        if(thisData.thisCard.Count>0){
            for(int i=0;i<thisData.thisCard.Count ;i++){
                if(thisData.thisCard[i].name==name){
                    thisData.chuPaiState=ChuPaiState.NeedOutPai;
                    thisData.OutCard(thisData.thisCard[i]);
                    thisData.isNeedOutCard=true;
                }
            }
        }

    }
    //接收玩家出的牌
    public void PlayerPlayCard(string name,int damage){
        switch(name){
           
                    case "Sha":
                        if(playerController.thisData.isJueDou==true||thisData.isJueDou==true){
                            ReceiveCardPlay("Sha");
                        }
                        else{
                            ReceiveCardPlay("Shan");
                            if(thisData.isNeedOutCard==true){
                                thisData.currentNeedOutCardName="";
                                thisData.isNeedOutCard=false;
                            }
                            else{
                                thisData.Hit(damage);
                                thisData.currentNeedOutCardName="";
                            }
                        }
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
                        ReceiveCardPlay("WuXieKeJi");
                        if(thisData.isOutWuXie){
                            OutWuXieKeJi();
                        }
                        else{
                            thisData.isChouPai=true;
                        }
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
                    case "TaoYuanJieYi":
                        // 处理桃园结义的逻辑
                        break;
                    case "LeBuSiShu":
                        // 处理乐不思蜀的逻辑
                        break;
                    case "BingLiangCunDuan":
                        // 处理兵粮寸断的逻辑
                        break;
                    case "ZhuGeLianNu":
                        // 处理诸葛连弩的逻辑
                        break;
                    case "QingLongYanYueDao":
                        // 处理青龙偃月刀的逻辑
                        break;
                    case "HanBingJian":
                        // 处理寒冰剑的逻辑
                        break;
                    case "BaiYinShiZi":
                        // 处理白银狮子的逻辑
                        break;
                    case "BaGuaZhen":
                        // 处理八卦阵的逻辑
                        break;
                    case "TengJia":
                        // 处理藤甲的逻辑
                        break;
                    default:
                        // 处理未匹配的情况
                        break;

        }
    }
    public void OutWuXieKeJi(){
        thisData.currentNeedOutCardName="";
        thisData.isNeedOutCard=false;
        playerController.thisData.chuPaiState=ChuPaiState.NeedOutPai;
        GameController.Instance.playerNeedTimer=10;
        playerController.thisData.isNeedOutCard=true;
        thisData.isOutWuXie=false;
    }
}
