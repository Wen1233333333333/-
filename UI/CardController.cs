using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class CardController : MonoBehaviour
{
    public GameObject playerTrs;
    public GameObject  enemyTrs;
    public GameObject  targetTrs;
    public List<GameObject> cardGo;
    public List<CaedList> cardLists=new List<CaedList>();
    public Image back;
    // Start is called before the first frame update
    void Awake()
    {
        CreateCardGoList();
        Debug.Log(cardLists.Count );
    }

    // Update is called once per frame
    void Update()
    {
        if(cardLists.Count==0){
            CreateCardGoList();
        }
    }
    public void SendCard(PlayerAndEnemy playerAndEnemy){
        GameObject go=InstantiateCard();
        if(playerAndEnemy==PlayerAndEnemy.Player){
            OutCardMovePOS(go,playerTrs.transform);
            go.transform.localScale=Vector3.one;
        }
        else{
            go.GetComponent<Image>().sprite=back.sprite;
            Destroy(go.transform.GetComponent<CardUiDisplay>());
            Destroy(go.transform.GetComponent<CardButton>());
            Destroy(go.transform.GetComponent<Toggle>());
            OutCardMovePOS(go,enemyTrs.transform);
            go.transform.localScale=Vector3.one;
        }
        cardLists.RemoveAt(cardLists.Count-1);
    }
    public void OutCardMovePOS(GameObject gameObject,Transform tarGetPos){
        gameObject.transform.DOMove(tarGetPos.position,0.5f).OnComplete(()=>{
            gameObject.transform.SetParent(tarGetPos);
            GameController.Instance.isGetCard=true;
        });
    }
    public GameObject InstantiateCard()
{
    int lastIndex = cardLists.Count - 1; // 确保不会越界
    GameObject Go = Instantiate(cardLists[lastIndex].CardGo);
    Go.name = cardLists[lastIndex].Name; // 确保将名称赋值正确
    Go.transform.SetParent(targetTrs.transform);
    Go.transform.position = targetTrs.transform.position;
    return Go;
}
    public void CreateCardGoList(){
        
        AddCardList(5,cardGo[0]);
        AddCardList(60,cardGo[1]);
        AddCardList(60,cardGo[2]);
        AddCardList(8,cardGo[3]);
        AddCardList(6,cardGo[4]);
        AddCardList(3,cardGo[5]);
        AddCardList(3,cardGo[6]);
        AddCardList(5,cardGo[7]); 
        AddCardList(5,cardGo[8]);
        AddCardList(1,cardGo[9]);
        AddCardList(1,cardGo[10]);
        AddCardList(3,cardGo[11]);
        AddCardList(5,cardGo[12]);
        AddCardList(1,cardGo[13]);
        AddCardList(1,cardGo[14]);
        AddCardList(1,cardGo[15]); 
        AddCardList(30,cardGo[16]);
        AddCardList(1,cardGo[17]);
        AddCardList(5,cardGo[18]);
        AddCardList(5,cardGo[19]); 
        AddCardList(5,cardGo[20]);
        AddCardList(2,cardGo[21]);
        AddCardList(30,cardGo[22]);
        for(int i=0;i<cardLists.Count;i++){
            var temp=cardLists[i];
            var randomIndex=Random.Range(0,cardLists.Count);
            cardLists[i]=cardLists[randomIndex];
            cardLists[randomIndex]=temp;
        }
    }
    //往牌堆添加牌
    public void AddCardList(int number ,GameObject CardGo){
         // 使用 CardGo 的名称而不是 ToString()
    CaedList caedList = new CaedList(CardGo.name, CardGo);
    for (int i = 0; i < number; i++)
    {
        cardLists.Add(caedList);
    }
}
}
public class CaedList{
    private GameObject cardGo;
    private string name;
    public string Name{
        get{return name;}
    }
    public GameObject CardGo{
        get{return cardGo;}
    }
    public CaedList(string Name,GameObject CardGo){
        this.name=Name;
        this.cardGo=CardGo;
    }

}
