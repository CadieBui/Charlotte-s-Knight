using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class smallDiaryPage : MonoBehaviour
{
    // public CanvasGroup diary;

    public diaryContent diaryContent;
    public CanvasGroup diaryPageCanvasGroup;//筆記本
    public GameObject nextBtn;
    public GameObject prevBtn;
    public Image LeftImg;
    public Image RightImg;
    public int click;
    int whichBook;
    GameObject player;


    void Start()
    {
        click=0;
        LeftImg.sprite=diaryContent.diaryImg1;
        RightImg.sprite=diaryContent.diaryImg2;
        whichBook=diaryContent.whichBook;
        player=GameObject.Find("player");

    }

    public void nextPage() {
        if(click==0){
            GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

            prevBtn.SetActive(true);
            nextBtn.SetActive(false);

            LeftImg.sprite=diaryContent.diaryImg3;
            RightImg.sprite=diaryContent.diaryImg4;
            click++;
        }
    }

    public void lastPage() {
        if(click==1){
            GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

            nextBtn.SetActive(true);
            prevBtn.SetActive(false);
            LeftImg.sprite=diaryContent.diaryImg1;
            RightImg.sprite=diaryContent.diaryImg2;
            click--;
        }
        
    }
    public void closeMenu() {
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
        player.GetComponent<player>().ShowUI=false;
        diaryPageCanvasGroup.alpha = 0;
        diaryPageCanvasGroup.blocksRaycasts = false;
        diaryPageCanvasGroup.interactable = false;
    }
  
}
