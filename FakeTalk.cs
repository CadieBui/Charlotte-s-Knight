using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeTalk : MonoBehaviour
{
    public int clicknum=0;
    public int[] stance_num;
    public int nowstance=3;
    public int begin=0;
    public bool begintime1=false;
    public GameObject o1,o2,o3;
    public bool lose=false;
    public int answer=4;
    private Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //找Inventory腳本下的變數

    }

    // Update is called once per frame
    void Update()
    {
        if(begintime1){
            Invoke("think",10f);
            begintime1=false;
        }
    }

    public void runAway(){
        begin=stance_num[1];
        clicknum=1;
        nowstance=stance_num[2]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3();
        GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;

        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
        lose=true;
    }

    public void follow(){
        begin=stance_num[2];
        clicknum=2;
        nowstance=stance_num[3]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3();
        GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;

        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
        lose=true;
    }

    void think(){
        begin=stance_num[3];
        clicknum=3;
        nowstance=stance_num[4]-1;
        GameObject.Find("dialog").GetComponent<dialogue>().level3();
        // GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;
        o1.SetActive(false);
        o2.SetActive(true);
        GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
        GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
        GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
    }

    public void click(int num){
        if(o2.transform.GetChild(num).name=="t"){
            o2.transform.GetChild(num).name="f";
        }else{
            o2.transform.GetChild(num).name="t";
        }
        if(o2.transform.GetChild(num).GetComponent<Image>().color==new Color(1,1,1,1)){
            o2.transform.GetChild(num).GetComponent<Image>().color=new Color(100/255f,100/255f,100/255f,1);
        }else{
            o2.transform.GetChild(num).GetComponent<Image>().color=new Color(1,1,1,1);
        }

        if(o2.transform.GetChild(num).name=="t"){
            answer++;
            if(answer==9){
                begin=stance_num[4];
                clicknum=4;
                nowstance=stance_num[5]-1;
                GameObject.Find("dialog").GetComponent<dialogue>().level3();
                o2.SetActive(false);
                o3.SetActive(true);
                GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
                GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
                GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
            }
        }else{
            answer--;
        }
    }

    public void npc(bool istrue){
        if(istrue){
            begin=stance_num[5];
            clicknum=5;
            nowstance=stance_num[6]-1;
            GameObject.Find("dialog").GetComponent<dialogue>().level3();
            GameObject.Find("option").GetComponent<CanvasGroup>().alpha=0;
            GameObject.Find("option").GetComponent<CanvasGroup>().blocksRaycasts=false;
            GameObject.Find("option").GetComponent<CanvasGroup>().interactable=false;
            GameObject.Find("dialog").GetComponent<dialogue>().runoption=false;
        }else{
            SceneManager.LoadScene("GameOver");
            inventory.lastScene="";

        }
    }
}
