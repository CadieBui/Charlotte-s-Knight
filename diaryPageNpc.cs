using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class diaryPageNpc : MonoBehaviour
{
    public diaryContent diaryContent;
    public CanvasGroup diary;//日記本
    public CanvasGroup diaryMenuCanvasGroup;//大menu
    public CanvasGroup diaryPageCanvasGroup;//要出現的內容
    public Image PageLeftImg;
    public Image PageRightImg;
    public int click;
    int whichBook;
    private DiaryItem isOpenDiary;
    bool[]  isClickNpc;

    private void Awake() {
        isOpenDiary = GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();
    }
    void Start()
    {
        click=0;
        diaryMenuCanvasGroup.alpha = 0;
        diaryMenuCanvasGroup.blocksRaycasts = false;
        diaryMenuCanvasGroup.interactable = false;
        PageLeftImg.sprite=diaryContent.diaryImg1;

        whichBook=diaryContent.whichBook;

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
    
  
}
