using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    bool tmp;
    int times=0;
    // Start is called before the first frame update
    void Start()
    {
        tmp=false;
    }

    // Update is called once per frame
    void Update()
    {
        times++;
        if(times>30){
            tmp=!tmp;
            transform.GetComponent<BoxCollider2D>().isTrigger=tmp;
            times=0;
        }
    }

    private void OnMouseDown() {
        int num=transform.parent.transform.GetComponent<totalTool>().tool_num;
        Debug.Log(transform.parent.transform.GetComponent<totalTool>().border[0].transform.name);
        Image tmpBorder=transform.parent.transform.GetComponent<totalTool>().border[num];
        tmpBorder.transform.GetComponent<Image>().sprite=transform.GetComponent<SpriteRenderer>().sprite;
        transform.parent.transform.GetComponent<totalTool>().tool_num++;
    }
}
