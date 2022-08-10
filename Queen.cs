using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public GameObject dialog;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            OnMouseDown();
        }
    }

    private void OnMouseDown() {
        dialog.transform.GetComponent<dialogue>().level1_2();
    }
}
