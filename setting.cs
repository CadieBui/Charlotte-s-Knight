using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public Sprite original;
    public Sprite next;
    bool isDone=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pointDown(){
        isDone=!isDone;
        if(isDone){
            if(transform.name=="volume"){
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Pause();
            }else{
                Application.Quit();
            }
        }else{
            if(transform.name=="volume"){
                GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            }
        }
        Changeimage();
    }
    void Changeimage(){
        if(transform.GetComponent<Image>().sprite==original){
            transform.GetComponent<Image>().sprite=next;
        }else{
            transform.GetComponent<Image>().sprite=original;
        }
    }
}
