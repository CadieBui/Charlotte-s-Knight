using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// public enum PageClass {
//     page1,page2,page3,page4
// }
[CreateAssetMenu(fileName = "diaryContent", menuName = "diaryContent", order = 0)]
public class diaryContent : ScriptableObject 
{
    public Sprite diaryImg1;
    public Sprite diaryImg2;
    public Sprite diaryImg3;
    public Sprite diaryImg4;

    public int whichBook;

}
