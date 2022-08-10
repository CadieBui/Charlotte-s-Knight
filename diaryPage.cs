using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class diaryPage : MonoBehaviour
{
    public diaryContent diaryContent;
    public CanvasGroup diary;//日記本
    public CanvasGroup diaryMenuCanvasGroup;//大menu
    public CanvasGroup diaryPageCanvasGroup;//要出現的內容
    public GameObject nextBtn;
    public GameObject prevBtn;
    public Image PageLeftImg;
    public Image PageRightImg;
    public int click;
    int whichBook;
    GameObject player;


    void Start()
    {
        click=0;
        
        PageLeftImg.sprite=diaryContent.diaryImg1;
        PageRightImg.sprite=diaryContent.diaryImg2;
        whichBook=diaryContent.whichBook;
        player=GameObject.Find("player");

    }

    public void nextPage() {
        if(click==0){
            GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

            prevBtn.SetActive(true);
            nextBtn.SetActive(false);

            PageLeftImg.sprite=diaryContent.diaryImg3;
            PageRightImg.sprite=diaryContent.diaryImg4;
            click++;
           
        }
    }
    
    public void lastPage() {
        if(click==1){
            GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

            nextBtn.SetActive(true);
            prevBtn.SetActive(false);

            PageLeftImg.sprite=diaryContent.diaryImg1;
            PageRightImg.sprite=diaryContent.diaryImg2;
            click--;
        }
        
    }

    public void backToMenu() {
        GameObject.Find("click").GetComponent<AudioSource>().Play();
        diaryMenuCanvasGroup.alpha = 1;
        diaryMenuCanvasGroup.blocksRaycasts = true;
        diaryMenuCanvasGroup.interactable = true;

        diaryPageCanvasGroup.alpha = 0;
        diaryPageCanvasGroup.blocksRaycasts = false;
        diaryPageCanvasGroup.interactable = false;
    }
     public void closeMenu() {
        GameObject.Find("click").GetComponent<AudioSource>().Play();
        player.GetComponent<player>().ShowUI=false;

        diary.alpha = 0;
        diary.blocksRaycasts = false;
        diary.interactable = false;
    }
  
}
