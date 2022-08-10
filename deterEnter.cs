using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class deterEnter : MonoBehaviour {
  public CanvasGroup show; //確認進入房間的視窗
  GameObject player;
  private Inventory inventory;

  private void Awake() {
    player=GameObject.Find("player");
  }

  // Start is called before the first frame update
  void Start() {
    inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>(); //找Inventory腳本下的變數
  }

  public void enter() {
    player.transform.GetComponent<player>().not_move=false;
    GameObject.Find("click").GetComponent<AudioSource>().Play();

    switch (player.GetComponent<player>().sceneName) {
      case "Level_1_1_princess": 
        if (player.GetComponent<player>().keyName=="yellowKey(Clone)"&& inventory.lastScene=="") {
          Destroy(GameObject.Find("yellowKey(Clone)"));
          SceneManager.LoadScene("Level_1_3_castle");
          inventory.lastScene="princess";
          player.GetComponent<player>().keyName="";
          break;
        }
        else if (player.GetComponent<player>().keyName=="blackKey(Clone)") {
          Destroy(GameObject.Find("blackKey(Clone)"));
          SceneManager.LoadScene("GameOver");
          inventory.lastScene="";
          player.GetComponent<player>().keyName="";
          break;
        }
      break;

      case "Level_1_3_castle": 
        if (inventory.lastScene=="princess") {
          SceneManager.LoadScene("Level_1_2_Queen");
          inventory.lastScene="castle";
          break;
        }
        else if(inventory.lastScene=="queen")
        {
          SceneManager.LoadScene("Level_1_1_princess");
          inventory.lastScene="castle";
          break;

        }
        break;

      case "Level_1_2_Queen": 
        SceneManager.LoadScene("Level_1_3_castle");
        inventory.lastScene="queen";
        break;
      case "Level_2_town": 
        // SceneManager.LoadScene("Level_3_forest");
        inventory.lastScene="town";
        GameObject.Find("dialog").GetComponent<dialogue>().scene2to3();
        break;
      case "Level_3_forest":
      if(player.transform.GetComponent<player>().isGoTo3_1==false)
        {
          inventory.lastScene="forest";
          player.transform.GetComponent<player>().NotIdol();
          player.transform.GetComponent<player>().NotMove();
          SceneManager.LoadScene("Level_3_1_cellar");
          break;
        }
        break;
      case "Level_3_1_cellar":
        SceneManager.LoadScene("Level_3_forest");
        inventory.lastScene="cellar";
        break;
      default: 
        break;

    }

    show.alpha=0;
    show.blocksRaycasts=false;
    show.interactable=false;

    player.transform.GetComponent<player>().ShowUI=false;
    player.transform.GetComponent<player>().NotMove();
    player.transform.GetComponent<player>().NotIdol();
    player.transform.GetComponent<player>().playerAni.SetBool("F",true);
  }

  public void exit() {
    player.transform.GetComponent<player>().not_move=false;
    GameObject.Find("click").GetComponent<AudioSource>().Play();
    show.alpha=0;
    show.blocksRaycasts=false;
    show.interactable=false;
    player.transform.GetComponent<player>().ShowUI=false;
  }
}