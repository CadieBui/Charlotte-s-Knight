using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using UnityEngine.EventSystems;

public class startBtn : MonoBehaviour
{
    public CanvasGroup loadingSceneCanvas;//loadingScene的canvas
    public GameObject loadingScene;//loadingScene的GO
    public Text progressText;//loadingScene的文字
    public Slider slider;//loadingScene的滑桿
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointEnter(){
        transform.localScale=new Vector3(1.2f,1.2f,1.2f);
    }
    public void PointExit(){
        transform.localScale=new Vector3(1f,1f,1f);
    }

    public void PointDown(){
        // SceneManager.LoadScene("Level_1_1_princess");
        StartCoroutine(LoadAsynchronously(6));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)//loadingScene
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingSceneCanvas.alpha=1;
        loadingSceneCanvas.blocksRaycasts=true;
        loadingSceneCanvas.interactable=true;

        loadingScene.SetActive(true);
        while(!operation.isDone)
        {
            float progress=Mathf.Clamp01(operation.progress/.9f);
            slider.value=progress;
            Debug.Log("progress"+progress);
            loadingSceneCanvas.alpha=0;
            loadingSceneCanvas.blocksRaycasts=false;
            loadingSceneCanvas.interactable=false;

            loadingScene.SetActive(false);

            progressText.text=progress*100f+"%";
            yield return null;
        }
    }
}
