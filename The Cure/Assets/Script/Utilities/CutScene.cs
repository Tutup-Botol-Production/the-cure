using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    double waitTime;

    private void StartScene()
    {
        SceneManager.LoadScene("Home");
    }

    void Awake()
    {
        if(PlayerPrefs.GetInt("LastActiveScene") == 1)
        {
            PlayerPrefs.SetInt("LastActiveScene", 2);
        }
    }
    void Start()
    {
        waitTime = GetComponent<PlayableDirector>().duration;

        Invoke(nameof(StartScene), (float)waitTime);
    }
}
