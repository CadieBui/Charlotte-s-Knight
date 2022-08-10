using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CinemachineFollow : MonoBehaviour
{
    GameObject player = null;
    public string level;
    private Inventory inventory;
    private CanvasGroup dialog;//對話框

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        CinemachineVirtualCamera cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        if (cinemachineVirtualCamera != null)
        {
            cinemachineVirtualCamera.m_Follow = player.transform;
        }
        
        if (scene.name == "Level_1_1_princess")
        {
            player.GetComponent<player>().sceneName = "Level_1_1_princess";
        }
        else if (scene.name == "Level_1_2_Queen")
        {
            player.GetComponent<player>().sceneName = "Level_1_2_Queen";
        }
        else if (scene.name == "Level_1_3_castle")
        {
            player.GetComponent<player>().sceneName = "Level_1_3_castle";
        }
        else if (scene.name == "Level_2_town")
        {
            player.GetComponent<player>().sceneName = "Level_2_town";
        }
        else if (scene.name == "Level_3_1_cellar")
        {
            player.GetComponent<player>().sceneName = "Level_3_1_cellar";
        }
        else if (scene.name == "Level_3_forest")
        {
            player.GetComponent<player>().sceneName = "Level_3_forest";
        }

        if (scene.name == "Level_1_2_Queen" && inventory.lastScene == "castle")//上一關的皇宮&&此關卡是皇后房間
        {
            player.transform.position = new Vector3(-4.98f, 6f, 0);
        }
        else if (scene.name == "Level_1_3_castle" && inventory.lastScene == "princess")//上一關的公主房間&&此關卡是皇宮
        {
            player.transform.position = new Vector3(-13.98f, -5.29f, 0);
        }
        else if (scene.name == "Level_1_3_castle" && inventory.lastScene == "queen")//上一關的皇后房間&&此關卡是皇宮房間
        {
            player.transform.position = new Vector3(2.33f, 10.93f, 0);
        }
        else if (scene.name == "Level_2_town" && inventory.lastScene == "castle")
        {
            player.transform.position=new Vector3(-29f,-17.5f,0);
        }
        else if (scene.name == "Level_2_town" && inventory.lastScene == "")
        {
            player.transform.position = new Vector3(21.8f, 8.3f, 0);
            player.GetComponent<player>().autoWalkToBridge=false;
        }
        else if (scene.name == "Level_1_1_princess" && inventory.lastScene == "princess")
        {
            player.transform.position = new Vector3(4.37f, 2.67f, 0);
        }
        else if (scene.name == "Level_1_1_princess" && inventory.lastScene == "castle")
        {   //上一關的皇宮&&此關卡是公主房間
            dialog = GameObject.Find("dialog").GetComponent<CanvasGroup>();
            dialog.alpha = 0;
            dialog.blocksRaycasts = false;
            dialog.interactable = false;
            player.transform.position = new Vector3(2.33f, -3.91f, 0);
            player.transform.GetComponent<player>().not_move = false;//player可以移動

        }
        else if(scene.name == "Level_1_1_princess" && inventory.lastScene == "")
        {
            player.transform.position = new Vector3(4.37f, 2.67f, 0);
        }
        else if(scene.name == "Level_3_forest" && inventory.lastScene == "town")
        {
            player.transform.position = new Vector3(-15.9f, -33.2f, 0);
        }
        else if(scene.name == "Level_3_forest" && inventory.lastScene == "cellar")
        {
            player.transform.position = new Vector3(8.5f, -35.1f, 0);
        }
        else if(scene.name == "Level_3_forest" && inventory.lastScene == "")
        {
            player.transform.position = new Vector3(-17.3f, -34.4f, 0);
        }
        else if(scene.name == "Level_3_1_cellar" && inventory.lastScene == "forest")
        {
            player.transform.position = new Vector3(-8.88f, 2.67f, 0);
            player.GetComponent<player>().playerAni.SetBool("foward",true);
            player.GetComponent<player>().isGoTo3_1=true;
        }
        player.GetComponent<player>().isGameOver=false;

    }
    public void Restart()
    {
        if(player.GetComponent<player>().sceneName=="Level_3_1_cellar")
        {
            SceneManager.LoadScene("Level_3_forest");
            player.GetComponent<player>().lead_away = false;
            player.GetComponent<player>().not_move = false;
            player.GetComponent<player>().isGoTo3_1=false;
        }
        else if(player.GetComponent<player>().sceneName=="Level_3_forest")
        {
            SceneManager.LoadScene("Level_3_forest");
            player.GetComponent<player>().lead_away = false;
            player.GetComponent<player>().not_move = false;
        }
        else if(player.GetComponent<player>().sceneName=="Level_2_town"){
            SceneManager.LoadScene(player.GetComponent<player>().sceneName);
            player.GetComponent<player>().autoWalkToBridge=false;
            player.GetComponent<player>().not_move=false;
        }
        else {
            SceneManager.LoadScene("Level_1_1_princess");
            player.GetComponent<player>().not_move=false;

        }
        player.GetComponent<player>().isGameOver=true;
    }
}
