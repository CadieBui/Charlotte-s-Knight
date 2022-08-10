using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diaryMenu : MonoBehaviour
{
    public CanvasGroup diaryMenuCanvasGroup;
   
    public CanvasGroup diaryMenuPalace;//PalaceBtn
    public CanvasGroup diaryMenuNpc;//NpcBtn


    public CanvasGroup diarySmallMenu;//SmallMenuBtn
    public CanvasGroup diarySmallMenuNpc;//SmallMenuNpcBtn
    public GameObject iconTitle;
    private DiaryItem isOpenDiary;

    // private bool isOpenPalaceMenu=false;
    void Start()
    {
        diaryMenuCanvasGroup.alpha = 1;
        diaryMenuCanvasGroup.blocksRaycasts = true;
        diaryMenuCanvasGroup.interactable = true;   
        
        isOpenDiary = GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();

    }
    void Update() {
      
        if(isOpenDiary.redBook==true||isOpenDiary.blueBook==true||isOpenDiary.queenTalk==true)
        {
            diaryMenuPalace.alpha=1;
            diaryMenuPalace.blocksRaycasts = true;
            diaryMenuPalace.interactable = true;
        }
        if(isOpenDiary.bird==true||isOpenDiary.npcFlowerShirt==true||isOpenDiary.npcSmile==true||isOpenDiary.npcOld==true||isOpenDiary.npcBeard==true||isOpenDiary.npcSad==true||isOpenDiary.npcHat==true||isOpenDiary.npcGlasses==true)
        {
            diaryMenuNpc.alpha=1;
            diaryMenuNpc.blocksRaycasts = true;
            diaryMenuNpc.interactable = true;
        }

    }
    public void palaceMenu()
    {
        GameObject.Find("click").GetComponent<AudioSource>().Play();

        diarySmallMenu.alpha=1;
        diarySmallMenu.blocksRaycasts = true;
        diarySmallMenu.interactable = true;
    }
    public void townMenu()
    {
        GameObject.Find("click").GetComponent<AudioSource>().Play();

        diarySmallMenuNpc.alpha=1;
        diarySmallMenuNpc.blocksRaycasts = true;
        diarySmallMenuNpc.interactable = true;
       
        iconTitle.SetActive(true);
    }
  
}

