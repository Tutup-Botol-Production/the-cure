using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public string moveScene;
    public LevelLoader levelLoader;

    [HideInInspector] public GameObject itemInteract = null;
    [HideInInspector] private bool isMenuOpen = false;

    [SerializeField] private GameObject subMenu;

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

    public void OnMenuBtnClick()
    {
        if (isMenuOpen)
        {
            Time.timeScale = 1;
            isMenuOpen = false;
            subMenu.SetActive(false);
        } else
        {
            Time.timeScale = 0;
            isMenuOpen = true;
            subMenu.SetActive(true);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
