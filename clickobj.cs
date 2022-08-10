using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickobj : MonoBehaviour
{
    public Sprite obj_img;
    bool isClick=false;
    bool tmp;
    int times=0;
    GameObject player;
    public bool isCollectObj;

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
        if(player.transform.GetComponent<player>().AllowClick&&!isClick){
            transform.GetComponent<SpriteRenderer>().sprite=obj_img;
            if(transform.name=="07-木桌_0")
            {
                GameObject.Find("drawer").GetComponent<AudioSource>().Play();
            }
            else if (transform.name=="DropNecklace")
            {
                transform.GetComponent<SpriteRenderer>().enabled=false;
            }
            isClick=true;
            if(isCollectObj){
                transform.GetComponent<Pickup>().collect_Obj();
            }
           
        }
    }
}
