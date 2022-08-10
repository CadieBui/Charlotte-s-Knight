using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterRoom : MonoBehaviour
{   
    public CanvasGroup show;

    GameObject player;
    bool tmp;
    int times=0;
    // Start is called before the first frame update
    private void Awake() 
    {
        player=GameObject.Find("player");
    }
    private void Start() {
        tmp=false;
        show = GameObject.Find("進入房間").GetComponent<CanvasGroup>();
    }
    // Update is called once per frame
    private void Update()
    {
        times++;
        if(times>10){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            // SceneManager.LoadScene("Level_1_2_Queen");
            show.alpha=1;
            show.blocksRaycasts=true;
            show.interactable=true;
            player.transform.GetComponent<player>().not_move=true;
        }
    }

    public void OnMouseDown() {
        show.alpha=1;
        show.blocksRaycasts=true;
        show.interactable=true;
        player.transform.GetComponent<player>().not_move=true;
    }

    public void click(){
        show.alpha=1;
        show.blocksRaycasts=true;
        show.interactable=true;
        player.transform.GetComponent<player>().not_move=true;
    }
}
