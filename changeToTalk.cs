using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeToTalk : MonoBehaviour
{
    public Sprite original;
    public Sprite talk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="player"){
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=talk;
            transform.GetChild(0).position=new Vector3(5.81f,-2.44f,0);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.name=="player"){
            transform.GetChild(0).GetComponent<SpriteRenderer>().sprite=original;
            transform.GetChild(0).position=new Vector3(5.21f,-2.9f,0);
        }
    }
}
