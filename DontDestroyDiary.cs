using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyDiary : MonoBehaviour
{
   private static DontDestroyDiary dontDestroyUI {get;set;}

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
