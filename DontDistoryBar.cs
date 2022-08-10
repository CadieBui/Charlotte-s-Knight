using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDistoryBar : MonoBehaviour
{
    private static DontDistoryBar dontDestroyUI {get;set;}
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
