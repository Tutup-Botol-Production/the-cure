using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public string moveScene;
    public GameObject itemInteract = null;
    public LevelLoader levelLoader;

    public void OnInteractBtnClick()
    {
        if (itemInteract != null && itemInteract.name != "Door")
        {
            Destroy(itemInteract);
        } else if(itemInteract.name == "Door")
        {
            levelLoader.GetComponent<LevelLoader>().LoadLevel();
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
