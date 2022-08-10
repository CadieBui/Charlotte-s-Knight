using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cellar : MonoBehaviour
{
    bool hasAutoTalk=false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasAutoTalk){
            Invoke("toTrue" , 2f);
            hasAutoTalk=true;
        }
    }

    void toTrue(){
        GameObject.Find("player").GetComponent<player>().autoTalkToWanta=true;
        GameObject.Find("player").GetComponent<player>().playerAni.SetBool("foward", true);
        Destroy(this.gameObject.GetComponent<cellar>());
    }
    
}
