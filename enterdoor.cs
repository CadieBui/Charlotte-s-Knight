using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterdoor : MonoBehaviour
{
    // Start is called before the first frame update
    public CanvasGroup show;
    GameObject player;
    bool tmp;
    int times=0;
    private void Awake() 
    {
        player=GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        times++;
        if(times>10){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
        
    }

    private void OnMouseDown() {
        if(player.GetComponent<player>().AllowClick&&!player.GetComponent<player>().ShowUI){
            // show.alpha=1;
            // show.blocksRaycasts=true;
            // show.interactable=true;
            // // show.transform.name=transform.name;
            // player.transform.GetComponent<player>().not_move=true;
            // SceneManager.LoadScene("Level_1_2_Queen");
            GameObject.Find("click").GetComponent<AudioSource>().Play();
        }
    }
}
