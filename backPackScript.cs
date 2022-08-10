using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backPackScript : MonoBehaviour
{
    public CanvasGroup UIGroup;
    public void Show() {
        if(UIGroup.alpha==0){
            UIGroup.alpha=1;
            UIGroup.blocksRaycasts=true;
            UIGroup.interactable=true;
        }
        else{
            UIGroup.alpha=0;
            UIGroup.blocksRaycasts=false;
            UIGroup.interactable=false;
        }
    }
}
