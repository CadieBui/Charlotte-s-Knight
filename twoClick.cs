using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoClick : MonoBehaviour
{
    public Sprite obj1_img;
    public Sprite obj2_img;
    bool isClick=false;
    bool tmp;
    int times=0;
    int clickTime=0;
    GameObject player;
    private void Awake() 
    {
        player=GameObject.Find("player");
    }
    // Start is called before the first frame update
    void Start()
    {
        tmp=false;
        transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
    }

    // Update is called once per frame
    void Update()
    {
        times++;
        if(times>30&&!isClick){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
    }

    private void OnMouseDown() {
        if(player.GetComponent<player>().AllowClick&&!player.GetComponent<player>().ShowUI){
            clickTime++;
            if(clickTime==1){
                transform.parent.GetComponent<SpriteRenderer>().sprite=obj1_img;
                GameObject.Find("click").GetComponent<AudioSource>().Play();
            }
            else if(clickTime==2){
                transform.parent.GetComponent<SpriteRenderer>().sprite=obj2_img;
                isClick=true;
                transform.GetComponent<Pickup>().collect_Obj();
                GameObject.Find("click").GetComponent<AudioSource>().Play();
            }
        }
    }

}
