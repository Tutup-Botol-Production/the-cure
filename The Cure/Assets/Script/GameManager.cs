using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Animator TextInjector;

    public GameObject itemInteract = null;
    [HideInInspector] private bool isMenuOpen = false;

    [SerializeField] private GameObject subMenu;

    public void OnInteractBtnClick()
    {
        if (itemInteract != null && itemInteract.name != "Door")
        {
            if(itemInteract.name == "Injector")
            {
                itemInteract.GetComponent<DialogueTrigger>().TriggerDialogue();
                TextInjector.SetTrigger("Injector");
            } if(itemInteract.name == "Bag")
            {
                itemInteract.GetComponent<DialogueTrigger>().TriggerDialogue();
                Invoke("ClearItem", 1f);
                PlayerPrefs.SetInt("bagTaken", 1);
            }
        } else if (itemInteract.CompareTag("main door"))
        {
            levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
        } else if (itemInteract.CompareTag("reys door"))
        {
            levelLoader.GetComponent<LevelLoader>().LoadPrevLevel();
        }
    }

    void ClearItem()
    {
        Destroy(itemInteract);
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
        Time.timeScale = 1;
        levelLoader.GetComponent<LevelLoader>().LoadScene(0);
    }
}
