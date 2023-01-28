using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameManager gameManager;
    public Animator transition;
    public float transitionTime = 1f;
    
    public void LoadLevel()
    {
        StartCoroutine(LoadLevel(gameManager.moveScene));
    }

    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
