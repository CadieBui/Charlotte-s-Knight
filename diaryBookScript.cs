using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryBookScript : MonoBehaviour
{
    public CanvasGroup diaryGroup;
    public CanvasGroup diaryMenuGroup;
    public CanvasGroup diarySmallMenu;
    public CanvasGroup diarySmallMenuNpc;
    public CanvasGroup diaryContent;
    public CanvasGroup diaryContent1;

    public CanvasGroup diaryContent2;

    public CanvasGroup diaryContent3;

    public CanvasGroup diaryContent4;

    public CanvasGroup diaryContent5;

    public CanvasGroup diaryContent6;

    public CanvasGroup diaryContent7;

    public CanvasGroup diaryContent8;

    public CanvasGroup diaryContent9;
    public CanvasGroup diaryContent10;



    GameObject player;

    private void Start() {
        player=GameObject.Find("player");

    }
    public void Show() {
        if(diaryGroup.alpha==0){
            GameObject.Find("click").GetComponent<AudioSource>().Play();

            diaryGroup.alpha=1;
            diaryGroup.blocksRaycasts=true;
            diaryGroup.interactable=true;

            diaryMenuGroup.alpha=1;
            diaryMenuGroup.blocksRaycasts=true;
            diaryMenuGroup.interactable=true;       
            player.transform.GetComponent<player>().ShowUI=true;

        }
        else if(diaryGroup.alpha==1){
            GameObject.Find("click").GetComponent<AudioSource>().Play();

            diaryGroup.alpha=0;
            diaryGroup.blocksRaycasts=false;
            diaryGroup.interactable=false;

            diaryMenuGroup.alpha=0;
            diaryMenuGroup.blocksRaycasts=false;
            diaryMenuGroup.interactable=false;
            
            diarySmallMenu.alpha=0;
            diarySmallMenu.blocksRaycasts=false;
            diarySmallMenu.interactable=false;
    
            diarySmallMenuNpc.alpha=0;
            diarySmallMenuNpc.blocksRaycasts=false;
            diarySmallMenuNpc.interactable=false;

            player.transform.GetComponent<player>().ShowUI=false;
            diaryContent.alpha=0;
            diaryContent.blocksRaycasts=false;
            diaryContent.interactable=false;
            diaryContent1.alpha=0;
            diaryContent1.blocksRaycasts=false;
            diaryContent1.interactable=false;
            diaryContent2.alpha=0;
            diaryContent2.blocksRaycasts=false;
            diaryContent2.interactable=false;
            diaryContent3.alpha=0;
            diaryContent3.blocksRaycasts=false;
            diaryContent3.interactable=false;
            diaryContent4.alpha=0;
            diaryContent4.blocksRaycasts=false;
            diaryContent4.interactable=false;
            diaryContent5.alpha=0;
            diaryContent5.blocksRaycasts=false;
            diaryContent5.interactable=false;
            diaryContent6.alpha=0;
            diaryContent6.blocksRaycasts=false;
            diaryContent6.interactable=false;
            diaryContent7.alpha=0;
            diaryContent7.blocksRaycasts=false;
            diaryContent7.interactable=false;
            diaryContent8.alpha=0;
            diaryContent8.blocksRaycasts=false;
            diaryContent8.interactable=false;
            diaryContent9.alpha=0;
            diaryContent9.blocksRaycasts=false;
            diaryContent9.interactable=false;
            diaryContent10.alpha=0;
            diaryContent10.blocksRaycasts=false;
            diaryContent10.interactable=false;
            player.transform.GetComponent<player>().ShowUI=false;

        }
    }
}
