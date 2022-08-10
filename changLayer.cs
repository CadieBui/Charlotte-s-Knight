using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag=="changeLayer"){
            if(other.transform.name=="back"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-5;
            }else if(other.transform.name=="back(1)"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-15;
            }else if(other.transform.name=="back(2)"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-12;
            }else if(other.transform.name=="back(4)"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-8;
            }else if(other.transform.name=="back(6)"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-7;
            }else if(other.transform.name=="font"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=0;
            }else{
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=-2;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.tag=="changeLayer"){
            if(other.transform.name=="back"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=2;
            }else if(other.transform.name=="font"){
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=2;
            }else{
                transform.parent.transform.GetComponent<SpriteRenderer>().sortingOrder=2;
            }
        }
    }
}
