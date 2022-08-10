using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour {
  private Inventory inventory; //Inventory腳本
  private DiaryItem diaryItem;

  public int i;
  public CanvasGroup show;
  GameObject player;
  public GameObject bird;
  public Sprite changeImg;
  public CanvasGroup canvasNotTrue;
  public GameObject DropNecklace;

  bool createObj=false;
  private void Start() {
    inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //找Inventory腳本下的變數
    player=GameObject.Find("player");
    diaryItem=GameObject.FindGameObjectWithTag("Player").GetComponent<DiaryItem>();
    
  }

  private void Update() {
    if(player.GetComponent<player>().sceneName == "Level_2_town"&&!createObj){
      DropNecklace=GameObject.Find("DropNecklace");
      bird=GameObject.Find("bird");
      createObj=true;
    }
    if (transform.parent.transform.childCount <=0) {

      //判斷slot的child有沒有東西
      if (inventory.isFull[i]==true) {
        //判斷slot的child有沒有東西
        inventory.isFull[i]=false; //判斷inventory腳本的isFull的位子有沒有東西
      }
    }

    else if(player.GetComponent<player>().isGameOver==true) {
      
        for(int i=0; i<inventory.slot.Length; i++) {
          //判斷那個格子裡面有沒有東西
          if(inventory.isFull[i]==true) {
            if (transform.parent.transform.childCount >0){
              // Debug.Log(transform.name);
              if(player.GetComponent<player>().sceneName == "Level_1_1_princess"||
              player.GetComponent<player>().sceneName == "Level_1_3_castle")
              {
                if(transform.name=="yellowKey(Clone)"||
                transform.name=="blackKey(Clone)"||
                transform.name=="queenFlower(Clone)"||
                transform.name=="bread(Clone)")
                {
                  Destroy(this.gameObject);
                  inventory.isFull[i]=false;
                }
              }
              if(player.GetComponent<player>().sceneName == "Level_2_town")
              {
                if(transform.name=="wood1(Clone)"||
                  transform.name=="rope(Clone)"||
                  transform.name=="necklace(Clone)"||
                  transform.name=="blackKey2(Clone)"||
                  transform.name=="knife(Clone)"){
                  Destroy(this.gameObject);
                  inventory.isFull[i]=false;
                }
                // if(transform.name=="bread(Clone)"&&transform.GetComponent<DiaryItem>().bird){
                //   Destroy(this.gameObject);
                //   inventory.isFull[i]=false;
                //   GameObject.Find("DropNecklace").GetComponent<SpriteRenderer>().enabled=true;
                //   GameObject.Find("bird").GetComponent<SpriteRenderer>().sprite=birdImg;
                // }
              }
              if(player.GetComponent<player>().sceneName == "Level_3_forest")
              {
                if(transform.name=="rope3_1(Clone)")
                {
                  Destroy(this.gameObject);
                  inventory.isFull[i]=false;
                }
              }
            } 
            break;
          }
        
      }
    }

  }

  public void DropItem() {
    foreach (Transform child in transform) {
      if (inventory.doorName=="rightDoor"&& child.gameObject.name=="yellowKey(Clone)") {
        GameObject.Find("click").GetComponent<AudioSource>().Play();
        inventory.isFull[i]=false; //判斷inventory腳本的isFull的位子有沒有東西
        show.alpha=1;
        show.interactable=true;
        show.blocksRaycasts=true;
        player.transform.GetComponent<player>().keyName=child.gameObject.name;
        player.transform.GetComponent<player>().not_move=true;
      }

      if (inventory.doorName=="wrongDoor"&& child.gameObject.name=="blackKey(Clone)") {
        GameObject.Find("click").GetComponent<AudioSource>().Play();
        inventory.isFull[i]=false; //判斷inventory腳本的isFull的位子有沒有東西
        show.alpha=1;
        show.interactable=true;
        show.blocksRaycasts=true;
        player.transform.GetComponent<player>().keyName=child.gameObject.name;
        player.transform.GetComponent<player>().not_move=true;
      }

      if (inventory.doorName=="wrongDoor"&& child.gameObject.name=="yellowKey(Clone)") {
        Debug.Log("wrongDoor & yellowKey");
        GameObject.Find("error").GetComponent<AudioSource>().Play();
        canvasNotTrue.alpha=1;
        canvasNotTrue.interactable=true;
        canvasNotTrue.blocksRaycasts=true;
      }

      if (inventory.doorName=="rightDoor"&& child.gameObject.name=="blackKey(Clone)") {
        Debug.Log("rightDoor & blackKey");
        GameObject.Find("error").GetComponent<AudioSource>().Play();
        canvasNotTrue.alpha=1;
        canvasNotTrue.interactable=true;
        canvasNotTrue.blocksRaycasts=true;
      }

      if (diaryItem.bird==true && child.gameObject.name=="bread(Clone)") {
        GameObject.Find("birdEffect").GetComponent<AudioSource>().Play();
        inventory.isFull[i]=false;
        Destroy(child.gameObject);
        DropNecklace.GetComponent<SpriteRenderer>().enabled=true;
        bird.transform.GetComponent<SpriteRenderer>().sprite=changeImg;
        bird.transform.position=new Vector3(26.23f, 8.12f, 0);
        bird.transform.GetComponent<clickNPC>().OnMouseDown();
      }

      if (diaryItem.bird==true && child.gameObject.name=="rope3_1(Clone)") {
        GameObject.Find("birdEffect").GetComponent<AudioSource>().Play();
        inventory.isFull[i]=false;
        Destroy(child.gameObject);
        DropNecklace.GetComponent<SpriteRenderer>().enabled=true;
        bird.transform.GetComponent<SpriteRenderer>().sprite=changeImg;
        bird.transform.position=new Vector3(26.23f, 8.12f, 0);
        bird.transform.GetComponent<clickNPC>().OnMouseDown();
      }
    }
  }
}