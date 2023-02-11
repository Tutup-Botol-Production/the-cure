using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Animator quitBox;
    private int lastScene;
    private bool IsTrigger;
    private void Awake()
    {
        PlayerPrefs.DeleteKey("LastActiveScene");
        PlayerPrefs.DeleteKey("playerPosX");
        PlayerPrefs.DeleteKey("playerPosY");
        PlayerPrefs.DeleteKey("autodialogOpened");
        PlayerPrefs.DeleteKey("bagTaken");
        lastScene = PlayerPrefs.GetInt("LastActiveScene", 0);
    }

    public void Trigger()
    {
        IsTrigger = !IsTrigger;
        quitBox.SetBool("Start", IsTrigger);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToPlay()
    {
        if(lastScene == 0)
        {
            PlayerPrefs.SetInt("LastActiveScene", 1);
            levelLoader.GetComponent<LevelLoader>().LoadScene(lastScene + 1);
        } else if(lastScene > 0)
        {
            levelLoader.GetComponent<LevelLoader>().LoadScene(lastScene);
        }
    }
    
}
