using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;//prefab圖
    public Animator BtnAni;

    private int keydown=0;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();//找Inventory腳本下的變數
        BtnAni=GameObject.Find("backPackImg").GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKeyDown("k")&&keydown==0){
            print("get inventory");
            for(int i=0;i<inventory.slot.Length;i++){   
                //判斷那個格子裡面有沒有東西
                if(inventory.isFull[i]==false){   
                    Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                    inventory.isFull[i]=true;
                    break;  
                } 
            }
            keydown=1;
        }
   }

    public void collect_Obj(){
        for(int i=0;i<inventory.slot.Length;i++)
        {   
            //判斷那個格子裡面有沒有東西
            if(inventory.isFull[i]==false)
            {   
                BtnAni.SetTrigger("shake");                
                BtnAni.SetTrigger("idle");
                GameObject.Find("getInventoryEffect").GetComponent<AudioSource>().Play();
                Instantiate(itemButton,inventory.slot[i].transform,false);//把prefab的圖片放進去slot裡面
                inventory.isFull[i]=true;
                // Destroy(gameObject);//刪掉object
                break;  
            } 
        }
    }
}
