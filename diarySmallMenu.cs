using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diarySmallMenu : MonoBehaviour
{
    public CanvasGroup diary;//筆記本

    public CanvasGroup Menu;//大menu
    public CanvasGroup SmallMenu;//小menu
    public CanvasGroup SmallMenuNpc;//小menu

    public CanvasGroup diaryContentRed;//diary 內容
    public CanvasGroup diaryContentBlue;//diary 內容
    public CanvasGroup diaryContentQueen;//diary 內容
    public CanvasGroup[] diaryContentNpc;//diary 內容


    public CanvasGroup diaryMenuRedBtn;//RedBtn
    public CanvasGroup diaryMenuBlueBtn;//BlueBtn
    public CanvasGroup diaryMenuQueenBtn;//QueenBtn
    public GameObject[] iconNpc;

    private DiaryItem isOpenDiary;//判斷有沒有打開筆記本

    void Start()
    {
        isOpenDiary = GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();
    }
    void Update() {
        if(diary.alpha==1){
            if(isOpenDiary.redBook==true){
                diaryMenuRedBtn.alpha = 1;
                diaryMenuRedBtn.blocksRaycasts = true;
                diaryMenuRedBtn.interactable = true;
            }
            if(isOpenDiary.blueBook==true){
                diaryMenuBlueBtn.alpha = 1;
                diaryMenuBlueBtn.blocksRaycasts = true;
                diaryMenuBlueBtn.interactable = true;
            }
            //皇后房間
            if(isOpenDiary.queenTalk==true){
                diaryMenuQueenBtn.alpha = 1;
                diaryMenuQueenBtn.blocksRaycasts = true;
                diaryMenuQueenBtn.interactable = true;
            }
            if(isOpenDiary.npcHat==true)
            {
                iconNpc[0].SetActive(true);
            
            }
            if(isOpenDiary.npcGlasses==true)
            {
                iconNpc[1].SetActive(true);
            
            }
            if(isOpenDiary.npcOld==true)
            {
                iconNpc[2].SetActive(true);
            
            }
            if(isOpenDiary.npcBeard==true)
            {
                iconNpc[3].SetActive(true);
                
            }
            if(isOpenDiary.npcSmile==true)
            {
                iconNpc[4].SetActive(true);
                
            }
            if(isOpenDiary.npcSad==true)
            {
                iconNpc[5].SetActive(true);
                
            }
            if(isOpenDiary.npcFlowerShirt==true)
            {
                iconNpc[6].SetActive(true);
                
            }
            if(isOpenDiary.bird==true)
            {
                iconNpc[7].SetActive(true);
            
            }
        }
    }
  

    public void menu1()
    {
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenu.alpha = 0;
        SmallMenu.blocksRaycasts = false;
        SmallMenu.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentRed.alpha = 1;
        diaryContentRed.blocksRaycasts = true;
        diaryContentRed.interactable = true;
        
    }
    public void menu2()
    {   
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenu.alpha = 0;
        SmallMenu.blocksRaycasts = false;
        SmallMenu.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;
        
        diaryContentBlue.alpha = 1;
        diaryContentBlue.blocksRaycasts = true;
        diaryContentBlue.interactable = true;
        
    }
    public void menu3()
    {
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenu.alpha = 0;
        SmallMenu.blocksRaycasts = false;
        SmallMenu.interactable = false;
        
        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentQueen.alpha = 1;
        diaryContentQueen.blocksRaycasts = true;
        diaryContentQueen.interactable = true;
    }
    public void NpcHat()
    {        
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[0].alpha = 1;
        diaryContentNpc[0].blocksRaycasts = true;
        diaryContentNpc[0].interactable = true;
    }
    public void npcGlasses()
    {    
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
    
        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[1].alpha = 1;
        diaryContentNpc[1].blocksRaycasts = true;
        diaryContentNpc[1].interactable = true;
    }
    public void NpcOld()
    {        
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[2].alpha = 1;
        diaryContentNpc[2].blocksRaycasts = true;
        diaryContentNpc[2].interactable = true;
    }
    public void NpcBeard()
    {        
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[3].alpha = 1;
        diaryContentNpc[3].blocksRaycasts = true;
        diaryContentNpc[3].interactable = true;
    }
    public void NpcSmile()
    {        
        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[4].alpha = 1;
        diaryContentNpc[4].blocksRaycasts = true;
        diaryContentNpc[4].interactable = true;
    }
    public void NpcSad()
    {  
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
      
        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[5].alpha = 1;
        diaryContentNpc[5].blocksRaycasts = true;
        diaryContentNpc[5].interactable = true;
    }
    public void NpcFlowerShirt()
    {        
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();

        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[6].alpha = 1;
        diaryContentNpc[6].blocksRaycasts = true;
        diaryContentNpc[6].interactable = true;
    }
    public void NpcBird()
    {       
        GameObject.Find("bookEffect").GetComponent<AudioSource>().Play();
 
        SmallMenuNpc.alpha = 0;
        SmallMenuNpc.blocksRaycasts = false;
        SmallMenuNpc.interactable = false;

        Menu.alpha = 0;
        Menu.blocksRaycasts = false;
        Menu.interactable = false;

        diaryContentNpc[7].alpha = 1;
        diaryContentNpc[7].blocksRaycasts = true;
        diaryContentNpc[7].interactable = true;
    }
   
}
