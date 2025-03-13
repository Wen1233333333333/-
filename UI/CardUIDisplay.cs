using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class CardUiDisplay : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    List<CardXinXi>  cardXinXis=new List<CardXinXi>();
    private GameObject CardTextBG;
    private TextMeshProUGUI IntroduceText;
    public void OnPointerEnter(PointerEventData eventData)
    {
        CardTextBG.GetComponent<Image>().color=new Color(255,255,255,255);
        IntroduceText.color=new Color(0,0,0,1);
        // 将 CardTextBG 移动到鼠标位置上方 100 个单位
        Vector3 mousePosition = Input.mousePosition;
        CardTextBG.transform.position = new Vector3(mousePosition.x+60, mousePosition.y + 70, mousePosition.z);
        CardTextBG.GetComponent<Image>().raycastTarget = true;
        if(GetCardName(transform.GetComponent<Image>().gameObject.name)==transform.GetComponent<Image>().gameObject.name){
            IntroduceText.text = GetCardIntroduce(transform.GetComponent<Image>().gameObject.name);
        }  
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CardTextBG.GetComponent<Image>().color = new Color(0, 0, 0, 0); // 不透明
    IntroduceText.color = new Color(0, 0, 0, 0); // 不显示
    CardTextBG.GetComponent<Image>().raycastTarget = false; 
    }

    // Start is called before the first frame update
    void Start()
{
    CardTextBG = GameObject.Find("CardTextBG");
    if (CardTextBG != null)
    {
        IntroduceText = CardTextBG.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        if (IntroduceText == null)
        {
            Debug.LogError("IntroduceText component not found!");
        }
    }
    else
    {
        Debug.LogError("CardTextBG object not found!");
    }
    AddCardXinXi();
}
    private void AddCardXinXi(){
        CardXinXi c1 = new CardXinXi("Jiu", "你的出牌阶段，喝一口酒，下一张‘杀’的伤害+1。");
        CardXinXi c2 = new CardXinXi("Sha", "你的出牌阶段，对攻击范围内的角色使用，造成1点伤害");
        cardXinXis.Add(c2);
        CardXinXi c3 = new CardXinXi("Shan", "使用一张闪可抵消‘杀’造成的伤害");
        CardXinXi c4 = new CardXinXi("Tao", "你的出牌阶段，使用可恢复一点体力值");
        CardXinXi c5 = new CardXinXi("WuXieKeJi", "在一张锦囊牌生效前，抵消此牌对一名角色产生的效果，也可以抵消另一张【无懈可击】。");
        CardXinXi c6 = new CardXinXi("JieDaoShaRen", "出牌阶段，对装备区里有武器牌的其他角色A使用，且其攻击范围内有可以使用【杀】的目标B。");
        CardXinXi c7 = new CardXinXi("WanJianQiFa", "出牌阶段，除自身角色外其他角色需打出一张【闪】否则受到1点伤害。");
        CardXinXi c8 = new CardXinXi("NanManRuQin", "出牌阶段，除自身角色外其他角色需打出一张【杀】否则受到1点伤害。");
        CardXinXi c9 = new CardXinXi("WuZhongShengYou", "出牌阶段，使用后，自已可以摸两张牌。");
        CardXinXi c10 = new CardXinXi("ShunShouQianYang", "出牌阶段，对距离为1的区域里有牌的一名其他角色使用。可以获得其区域里的一张牌。");
        CardXinXi c11 = new CardXinXi("GuoHeChaiQiao", "出牌阶段，对区域里有牌的一名其他角色使用。可以弃置其区域里的一张牌。");
        CardXinXi c12 = new CardXinXi("JueDou", "出牌阶段，对一名其他角色使用。由其开始，其与你轮流打出一张【杀】。");
        CardXinXi e1 = new CardXinXi("CiXiongShuangJian", "攻击范围:2。\n武器特效:你使用【杀】时，指定了一名异性角色后，在【杀】结算前可以选定另一名目标。");
        CardXinXi e2 = new CardXinXi("BaiYinShiZi", "防具效果:每次你受到伤害时，最多承受1点伤害(防止多余的伤害);当你失去装备区里的白银狮子时，回复1点体力。");
        CardXinXi e3 = new CardXinXi("BaGuaZhen", "防具效果:每当你需要使用(或打出)一张【闪】时，你可以进行一次判定:若结果为红色，则视为你使用了一张【闪】。");
        CardXinXi e4 = new CardXinXi("GuanShiFu", "攻击范围:3。\n武器特效:目标角色使用【闪】抵消你使用【杀】的效果时，你可以弃掉一张牌使【杀】生效。");
        CardXinXi e5 = new CardXinXi("JiaMa", "装备效果:其他角色计算与你的距离时，始终+1。");
        CardXinXi e6 = new CardXinXi("JianMa", "装备效果:其他角色计算与你的距离时，始终-1。");
        CardXinXi e7 = new CardXinXi("QiLinGong", "攻击范围:5。\n武器特效:你使用【杀】对目标角色造成伤害时，你可以将其装备区里的一匹马弃掉。");
        CardXinXi e8 = new CardXinXi("QingGangJian", "攻击范围:2。\n武器特效:锁定技，每当你使用【杀】时，无视目标角色的防具。");
        CardXinXi e9 = new CardXinXi("QingLongYanYueDao", "攻击范围:3。\n武器技能:当你使用的【杀】被抵消时，你可以立即对相同的目标再使用一张【杀】。");
        CardXinXi e10 = new CardXinXi("ZhangBaSheMao", "攻击范围:3。\n武器特效:当你需要使用(或打出)一张【杀】时，你可以将两张手牌当一张【杀】使用。");
        CardXinXi e11 = new CardXinXi("ZhuGeLianNu", "攻击范围:1。\n武器特效:出牌阶段，你可以使用任意张【杀】。");
        CardXinXi e12 = new CardXinXi("ZhuQueYuShan", "攻击范围:4。\n武器特效:你可以将你的任一普通杀当作具火焰伤害的杀来使用。");
        cardXinXis.Add(c1);
        cardXinXis.Add(c3);
        cardXinXis.Add(c4);
        cardXinXis.Add(c5);
        cardXinXis.Add(c6);
        cardXinXis.Add(c7);
        cardXinXis.Add(c8);
        cardXinXis.Add(c9);
        cardXinXis.Add(c10);
        cardXinXis.Add(c11);
        cardXinXis.Add(c12);
        cardXinXis.Add(e1);
        cardXinXis.Add(e2);
        cardXinXis.Add(e3);
        cardXinXis.Add(e4);
        cardXinXis.Add(e5);
        cardXinXis.Add(e6);
        cardXinXis.Add(e7);
        cardXinXis.Add(e8);
        cardXinXis.Add(e9);
        cardXinXis.Add(e10);
        cardXinXis.Add(e11);
        cardXinXis.Add(e12);
            }   
    // Update is called once per frame
    void Update()
    {
        
    }
    private string GetCardName(string name)
    {
        for(int i=0;i<cardXinXis.Count;i++){
            if(name==cardXinXis[i].Name){
                return cardXinXis[i].Name;
            }
        }
        return null;
    }
    private string GetCardIntroduce(string name)
{
    for (int i = 0; i < cardXinXis.Count; i++)
    {
        if (name == cardXinXis[i].Name)
        {
            Debug.Log("Found introduction for card: " + name);
            return cardXinXis[i].Introduce;
        }
    }
    Debug.LogWarning("No introduction found for card: " + name);
    return null; // 删除重复的 for 循环
}
}
public class CardXinXi{
    private string name;
    private string introduce;
    public string Name{
        get{return name;}
    }
    public string Introduce{
        get {return introduce;}
    }
    public CardXinXi(string Name,string Introduce){
        this.name=Name;
        this.introduce=Introduce;


    }

}
