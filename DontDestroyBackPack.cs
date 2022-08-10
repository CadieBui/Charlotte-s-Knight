using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DontDestroyBackPack : MonoBehaviour
{    
    private static DontDestroyBackPack dontDestroyUI {get;set;}

    void Awake() {
        DontDestroyOnLoad(this.gameObject);    

        if(dontDestroyUI==null){
            dontDestroyUI=this;

        }
        
        else {
            Destroy(this.gameObject);
        }
    }
}
