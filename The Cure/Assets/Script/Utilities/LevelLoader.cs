using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadScene(int sceneNumber = 0) => StartCoroutine(LoadLevel(sceneNumber));
    public void LoadNextLevel(int moveScene = 1) => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + moveScene));
    public void LoadPrevLevel(int moveScene = 1) => StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - moveScene));



    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
