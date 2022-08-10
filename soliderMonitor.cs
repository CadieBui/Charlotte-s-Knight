using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soliderMonitor : MonoBehaviour
{
    string level;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        level=GameObject.Find("dialog").GetComponent<dialogue>().level;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(level=="2"){
            if(transform.parent.GetComponent<level2_SoliderMove>().dir==transform.name){
                if(!GameObject.Find("player").GetComponent<player>().isInvisible){
                    transform.parent.GetComponent<level2_SoliderMove>().catchPlayer=true;
                    GameObject.Find("player").GetComponent<player>().not_move=true;
                    transform.parent.GetComponent<level2_SoliderMove>().catchPoint=GameObject.Find("player").transform.position;
                    SceneManager.LoadScene("GameOver");
                    inventory.isClickWood=false;
                    inventory.countClickWood=0;
                    GameObject.Find("artisan").GetComponent<clickNPC>().woodnum=0;
                }
            }
        }else if(level=="1-3"){
            if(transform.parent.GetComponent<fixedPointMove>().dir==transform.name){
                if(!GameObject.Find("player").GetComponent<player>().isInvisible){
                    transform.parent.GetComponent<fixedPointMove>().catchPlayer=true;
                    GameObject.Find("player").GetComponent<player>().not_move=true;
                    transform.parent.GetComponent<fixedPointMove>().catchPoint=GameObject.Find("player").transform.position;
                    SceneManager.LoadScene("GameOver");
                    inventory.lastScene="";

                }
            }
        }
    }
}
