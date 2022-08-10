using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.transform.name=="player"){
            GameObject.Find("flower").GetComponent<clickNPC>().clicknum++;
        }
    }
}
