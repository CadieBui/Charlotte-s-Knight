using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseHoverEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator BtnAni;
    public bool isClicked;
    private GameObject player;
 
    void Start()
    {
        player = GameObject.Find("player");
    }
    public void OnMouseEnter() {
        BtnAni.SetTrigger("hover");
    }
    public void OnMouseExit() {
        BtnAni.SetTrigger("idle");
    }
    public void OnMouseEnterDiary() {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }
    public void OnMouseExitDiary() {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void closeCanvas(){
        transform.GetComponentInParent<CanvasGroup>().alpha = 0;
        transform.GetComponentInParent<CanvasGroup>().interactable = false;
        transform.GetComponentInParent<CanvasGroup>().blocksRaycasts = false;
        isClicked = false;
        
        GameObject.Find("minuteButton").GetComponent<Image>().color=new Color(1,1,1,1);
        GameObject.Find("hourButton").GetComponent<Image>().color=new Color(1,1,1,1);
        player.GetComponent<clockTimeScript>().whichBtn="";
        player.GetComponent<clockTimeScript>().minuteTime=0;
        player.GetComponent<clockTimeScript>().hourTime=0;
        player.GetComponent<player>().ShowUI=false;
        for(int i=0;i<player.GetComponent<flowerMagicChange>().flower.Length;i++)
        {
            Image img=player.GetComponent<flowerMagicChange>().flower[i].GetComponent<Image>();
            Color tmpColor=img.color;
            tmpColor.a=0f;
            img.color=tmpColor;
        }
        GameObject.Find("3-1_magic").GetComponent<PickupBook>().isOpen=false;
        GameObject.Find("hourGO").transform.rotation=Quaternion.Euler(0,0,0);
        GameObject.Find("minuteGO").transform.rotation=Quaternion.Euler(0,0,0);
        GameObject.Find("click").GetComponent<AudioSource>().Play();
    }
    public void SelectedBtn(int whichBtn) {
        GameObject.Find("click").GetComponent<AudioSource>().Play();
        isClicked=true;
        transform.GetComponent<Image>().color=new Color(150/255f,159/255f,110/255f,255/255f);
        if(whichBtn==0)
        {
            GameObject.Find("hourButton").GetComponent<Image>().color=new Color(1,1,1,1);
            player.GetComponent<clockTimeScript>().whichBtn="minuteButton";

        }
        else if(whichBtn==1)
        {
            GameObject.Find("minuteButton").GetComponent<Image>().color=new Color(1,1,1,1);
            player.GetComponent<clockTimeScript>().whichBtn="hourButton";
        }
        
    }

    public void clockWise(){
        GameObject.Find("click").GetComponent<AudioSource>().Play();

        if(player.GetComponent<clockTimeScript>().whichBtn=="hourButton"&&player.GetComponent<clockTimeScript>().hourTime>-360&&player.GetComponent<clockTimeScript>().hourTime<=0)
        {
            player.GetComponent<clockTimeScript>().hourTime-=30f;
            GameObject.Find("hourGO").transform.rotation=Quaternion.Euler(0,0,player.GetComponent<clockTimeScript>().hourTime);
        }
        else if(player.GetComponent<clockTimeScript>().whichBtn=="minuteButton"&&player.GetComponent<clockTimeScript>().minuteTime>-360&&player.GetComponent<clockTimeScript>().minuteTime<=0)
        {
            player.GetComponent<clockTimeScript>().minuteTime-=30f;
            GameObject.Find("minuteGO").transform.rotation=Quaternion.Euler(0,0,player.GetComponent<clockTimeScript>().minuteTime);
        }
    }
    public void counterClockWise(){
        GameObject.Find("click").GetComponent<AudioSource>().Play();

        if(player.GetComponent<clockTimeScript>().whichBtn=="hourButton"&&player.GetComponent<clockTimeScript>().hourTime>=-360&&player.GetComponent<clockTimeScript>().hourTime<0)
        {
            player.GetComponent<clockTimeScript>().hourTime+=30f;
            GameObject.Find("hourGO").transform.rotation=Quaternion.Euler(0,0,player.GetComponent<clockTimeScript>().hourTime);

        }
        else if(player.GetComponent<clockTimeScript>().whichBtn=="minuteButton"&&player.GetComponent<clockTimeScript>().minuteTime>=-360&&player.GetComponent<clockTimeScript>().minuteTime<0)
        {
            player.GetComponent<clockTimeScript>().minuteTime+=30f;
            GameObject.Find("minuteGO").transform.rotation=Quaternion.Euler(0,0,player.GetComponent<clockTimeScript>().minuteTime);
        }
    }
}
