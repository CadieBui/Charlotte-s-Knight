using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class flowerMagicChange : MonoBehaviour
{
    public GameObject[] flower;
    GameObject player;
    public int frame;
    GameObject magicClock;
    public int correctTime=0;
    public bool isStop=false;
   
    void Start()
    {
        player = GameObject.Find("player");
        
    }

    public IEnumerator colorChange(){
        
        for(int i=0;i<player.GetComponent<magicClockScript>().hourTime.Length;i++)
        {
            for(int j=0;j<flower.Length;j++)
            {
                if(i==correctTime)
                { 
                    Image tmp=flower[j].GetComponent<Image>();
                    Color tmpColor=tmp.color;
                    if(player.GetComponent<magicClockScript>().minuteTime[i]==float.Parse(flower[j].transform.name))
                    {
                        if(tmpColor.a<=1f)
                        {
                            tmpColor.a+=0.5f*Time.deltaTime;
                            tmp.color=tmpColor;
                        }
                    }
                    
                }
            }
        }
        yield return new WaitForSeconds(3);

        for(int i=0;i<player.GetComponent<magicClockScript>().hourTime.Length;i++)
        {
            for(int j=0;j<flower.Length;j++)
            {
                if(i==correctTime)
                { 
                    Image tmp=flower[j].GetComponent<Image>();
                    Color tmpColor=tmp.color;
                    if(player.GetComponent<magicClockScript>().minuteTime[i]==float.Parse(flower[j].transform.name))
                    {
                        if(tmpColor.a>=0)
                        {
                            tmpColor.a-=0.9f* Time.deltaTime;
                            tmp.color=tmpColor;
                        }
                    }

                    if(player.GetComponent<magicClockScript>().hourTime[i]==float.Parse(flower[j].transform.name))
                    {
                        if(tmpColor.a<=1f)
                        {
                            tmpColor.a+=0.5f* Time.deltaTime;
                            tmp.color=tmpColor;
                        }
                    }
                }
            }
        }

        yield return new WaitForSeconds(2);
        for(int i=0;i<player.GetComponent<magicClockScript>().hourTime.Length;i++)
        {
            for(int j=0;j<flower.Length;j++)
            {
                if(i==correctTime)
                { 
                    Image tmp=flower[j].GetComponent<Image>();
                    Color tmpColor=tmp.color;
                    if(player.GetComponent<magicClockScript>().hourTime[i]==float.Parse(flower[j].transform.name))
                    {
                        if(tmpColor.a>=0)
                        {       
                            tmpColor.a-=0.9f* Time.deltaTime;
                            tmp.color=tmpColor;
                            isStop=true;
                        }
                    }
                }
            }
        }

    }
    bool b3=false;
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="Level_3_forest"){
            if(!b3){
                if(GameObject.Find("3-1_magic")!=null)
                {
                    magicClock=GameObject.Find("3-1_magic");
                    b3=true;
                }
            }
            if(GameObject.Find("3-1_magic")!=null){
                if(magicClock.GetComponent<PickupBook>().isOpen&&isStop==false){
                    StartCoroutine(colorChange());
                }
            } 
        }
    }
}
