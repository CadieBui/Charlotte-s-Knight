using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeImage : MonoBehaviour
{
    public Sprite obj_img;
    private Inventory inventory;

    private void Start() 
    {
        inventory=GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        changeObject();
    }
    public void changeObject(){
        if(inventory.lastScene=="castle"){
            transform.GetComponent<SpriteRenderer>().sprite=obj_img;
        }
    }
}
