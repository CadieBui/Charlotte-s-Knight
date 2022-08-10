using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wantaTalk : MonoBehaviour
{
    public int clicknum=0;
    public int[] stance_num;
    public int nowstance=3;
    public int begin=0;
    public bool begintime=false;
    public GameObject o1,o2;
    public bool lose=false;
    bool isClick=false;
    bool tmp;
    int times=0;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if(begintime){
            Invoke("key",10f);
            begintime=false;
        }
    }

    public void attack(){
        begin=stance_num[1];
        clicknum=1;
        nowstance=stance_num[2]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
        GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;

        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
        lose=true;
    }

    public void talkQueen(){
        begin=stance_num[2];
        clicknum=2;
        nowstance=stance_num[3]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
        GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;

        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
        lose=true;
    }

    void key(){
        begin=stance_num[3];
        clicknum=3;
        nowstance=stance_num[4]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
        // GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;
        o1.SetActive(false);
        o2.SetActive(true);
        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
        
    }

    public void clickobj(bool necklace){
        if(!necklace){
            begin=stance_num[4];
            clicknum=4;
            nowstance=stance_num[5]-1;
            lose=true;

        }else{
            begin=stance_num[5];
            clicknum=5;
            nowstance=stance_num[6]-1;
        }
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
        GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
    }

    public void click() {
        begin=stance_num[6];
        clicknum=6;
        nowstance=stance_num[7]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
    }

    private void OnMouseDown() {
        begin=stance_num[6];
        clicknum=6;
        nowstance=stance_num[7]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3_1();
    }
}
