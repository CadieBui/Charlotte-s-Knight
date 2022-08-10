using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2_SoliderMove : MonoBehaviour
{
    public Vector3[] Pos;
    int begin=1;
    float speed=3;
    bool ReturnThePath=false;
    public Animator soliderAni;
    public string dir;
    public bool catchPlayer=false;
    public Vector3 catchPoint;
    public bool move=true;
    dialogue ismove;
    // Start is called before the first frame update
    void Start()
    {
        ismove=GameObject.Find("dialog").GetComponent<dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!ismove.islevel2talk){
            if(catchPlayer){
                transform.position=Vector3.MoveTowards(transform.position,catchPoint,Time.deltaTime*speed*1.5f);
                if(transform.position==catchPoint){
                    SceneManager.LoadScene("GameOver");
                    catchPlayer=false;
                }       
            }else{
                if(move){
                    if(!ReturnThePath){
                        if(begin<Pos.Length){
                            changeMove();
                            transform.position=Vector3.MoveTowards(transform.position,Pos[begin],Time.deltaTime*speed);
                            if(transform.position==Pos[begin]){
                                begin++;
                            }
                        }else{
                            ReturnThePath=true;
                            begin-=2;
                        }
                    }else{
                        if(begin>-1){
                            changeMove();
                            transform.position=Vector3.MoveTowards(transform.position,Pos[begin],Time.deltaTime*speed);
                            if(transform.position==Pos[begin]){
                                begin--;
                            }
                        }else{
                            ReturnThePath=false;
                            begin+=2;
                        }
                    }
                }
            }
        }
    }

    void changeMove(){
        switch(dir){
            case "right":
                soliderAni.SetBool("right", false);
                break;
            case "left":
                soliderAni.SetBool("left", false);
                break;
            case "back":
                soliderAni.SetBool("back", false);
                break;
            case "foward":
                soliderAni.SetBool("foward", false);
                break;
        }
        if(transform.position.y-Pos[begin].y<0){
            soliderAni.SetBool("back", true);
            dir="back";
        }else if(transform.position.y-Pos[begin].y>0){
            soliderAni.SetBool("foward", true);
            dir="foward";
        }else if(transform.position.x-Pos[begin].x>0){
            soliderAni.SetBool("left", true);
            dir="left";
        }else if(transform.position.x-Pos[begin].x<0){
            soliderAni.SetBool("right", true);
            dir="right";
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.name=="player"){
            catchPlayer=false;
            move=false;
        }
    }
}
