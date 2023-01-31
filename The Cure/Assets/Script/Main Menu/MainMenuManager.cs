using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public TextMeshProUGUI playBtn;
    private int lastScene;
    private void Awake()
    {
        //PlayerPrefs.DeleteKey("LastActiveScene");
        //Debug.Log(PlayerPrefs.GetInt("LastActiveScene"));
        lastScene = PlayerPrefs.GetInt("LastActiveScene", 0);
    }
    private void Start()
    {
        if(lastScene == 0)
        {
            playBtn.text = "Play";
        } else if(lastScene > 0)
        {
            playBtn.text = "Continue";
        }
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
