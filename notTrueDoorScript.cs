using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notTrueDoorScript : MonoBehaviour
{ 
    CanvasGroup canvas;
    void Start() {
       canvas = GameObject.Find("CanvasNotTrue").GetComponent<CanvasGroup>();
    }
    public void closeCanvas(){
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }
}
