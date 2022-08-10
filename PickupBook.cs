using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBook : MonoBehaviour
{
    public CanvasGroup showDiary;
    bool tmp;
    int times=0;
    GameObject player;
    public bool isOpen=false;
    private DiaryItem isOpenDiary;
    private void Start() {
        tmp=false;
        player=GameObject.Find("player");
        isOpenDiary = GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();
    }

    private void Update() {
        times++;
        if(times>5){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
   }
   
    public void OnMouseDown() {//click判斷
        player.GetComponent<player>().ShowUI=true;
        isOpen=true;
        switch (this.gameObject.name)
        {
            case "02-畫框_信_0":
                showDiary.alpha=1;
                showDiary.interactable=true;
                showDiary.blocksRaycasts=true;
                break;
            case "12-藍日記":
                showDiary.alpha=1;
                showDiary.interactable=true;
                showDiary.blocksRaycasts=true;
                isOpenDiary.blueBook=true;
                GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
                break;
            case "13-粉日記":
                showDiary.alpha=1;
                showDiary.interactable=true;
                showDiary.blocksRaycasts=true;
                isOpenDiary.redBook=true;
                GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
                break;
            case "flower":
                isOpenDiary.npcHat=true;
                break;
            case "artisan":
                isOpenDiary.npcGlasses=true;
                break;
            case "boy":
                isOpenDiary.npcSad=true;
                break;
            case "girl":
                isOpenDiary.npcFlowerShirt=true;
                break;
            case "man":
                isOpenDiary.npcBeard=true;
                break;
            case "woman":
                isOpenDiary.npcSmile=true;
                break;
            case "older":
                isOpenDiary.npcOld=true;
                break;   
            case "bird":
                isOpenDiary.bird=true;
                break;
            case "clockWall":
                showDiary.alpha=1;
                showDiary.interactable=true;
                showDiary.blocksRaycasts=true;
                break; 
            case "3-1_magic":
                showDiary.alpha=1;
                showDiary.interactable=true;
                showDiary.blocksRaycasts=true;
                player.GetComponent<flowerMagicChange>().isStop=false;
                break;      
            default:
                break;

        }
    
    }
     public void closeLetter() {
        player.GetComponent<player>().ShowUI=false;

        showDiary.alpha = 0;
        showDiary.blocksRaycasts = false;
        showDiary.interactable = false;
    }
}
