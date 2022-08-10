using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockTimeScript : MonoBehaviour
{
    public float hourTime;
    public float minuteTime;
    public string whichBtn;
    public GameObject player;
    public bool frame;
    public GameObject fakeTree;
    public GameObject dialog;

    void Start()
    {
        player = GameObject.Find("player");
    }
    public void Update(){
        if(Mathf.Abs(hourTime/30)==player.GetComponent<magicClockScript>().hourTime[player.GetComponent<flowerMagicChange>().correctTime]&&
         Mathf.Abs(minuteTime/30)==player.GetComponent<magicClockScript>().minuteTime[player.GetComponent<flowerMagicChange>().correctTime])
        {
            frame=true;
            if(frame==true){
                Debug.Log("correct");
                GameObject.Find("correctSound").GetComponent<AudioSource>().Play();
                frame=false;
                player.GetComponent<flowerMagicChange>().correctTime++;
                if(player.GetComponent<flowerMagicChange>().correctTime==6){
                    fakeTree.SetActive(true);
                    dialog.GetComponent<dialogue>().End();
                }
            }
           
        }
        
    }
}
