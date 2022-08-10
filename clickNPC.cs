using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickNPC : MonoBehaviour
{
    public CanvasGroup DCG;
    public dialogue Dialogy;
    bool isClick=false;
    bool tmp;
    int times=0;
    public int clicknum=0;
    public int[] stance_num;
    public int woodnum=0;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Dialogy=GameObject.Find("dialog").GetComponent<dialogue>();
        player=GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {
        times++;
        if(times>10&&!isClick){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
        if (Input.GetKeyDown("o"))
        {            
            woodnum++;
        }

    }

    public void OnMouseDown() {
        DCG.alpha=1;
        DCG.interactable=true;
        DCG.blocksRaycasts=true;
        if(transform.name=="artisan"&&woodnum>=6){
            if(woodnum<8){
                clicknum=1;
            }else{
                if(clicknum+1<stance_num.Length){
                    clicknum++;
                }
            }
        }
        if(transform.name=="artisan"&&GameObject.Find("boat").GetComponent<SpriteRenderer>().enabled==true&&woodnum<8){
            Dialogy.level2(transform.name,clicknum,12);
        }else if(transform.name=="artisan"&&GameObject.Find("boat").GetComponent<SpriteRenderer>().enabled==true&&woodnum==8){
            Dialogy.level2(transform.name,clicknum,22);
        }else{
            Dialogy.level2(transform.name,clicknum,stance_num[clicknum]);
        }
        if(clicknum+1<stance_num.Length&&transform.name!="flower"&&transform.name!="bird"&&transform.name!="artisan"){
            clicknum++;
        }
        if(transform.name=="bird"){   
            player.GetComponent<DiaryItem>().bird=true;
        }
    }

    public void AutoTalk(){
        DCG.alpha=1;
        DCG.interactable=true;
        DCG.blocksRaycasts=true;
        GameObject.Find("flowerShow").GetComponent<CanvasGroup>().alpha=1;
        Dialogy.level2(transform.name,clicknum,stance_num[clicknum]);
        if(clicknum+1<stance_num.Length){
            clicknum++;
        }
    }
}
