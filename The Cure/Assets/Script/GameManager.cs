using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public LevelLoader levelLoader;
    public Animator TextInjector;
    public GameObject triggerDoor;
    public GameObject itemInteract = null;

    [HideInInspector] private bool isMenuOpen = false;
    [SerializeField] private GameObject subMenu;

    private int objective;
    private int injector;


    private void Update()
    {
        objective = PlayerPrefs.GetInt("objective", 0);
        injector = PlayerPrefs.GetInt("injectorTaken", 0);
        if(objective == 2)
        {
            triggerDoor.SetActive(true);
        }
        else
        {
            triggerDoor.SetActive(false);
        }
    }

    public void OnInteractBtnClick()
    {
        if (itemInteract != null && itemInteract.name != "Door")
        {
            if(itemInteract.name == "Injector" && injector == 0)
            {
                PlayerPrefs.SetInt("injectorTaken", 1);
                PlayerPrefs.SetInt("objective", objective + 1);
                TextInjector.SetTrigger("Injector");

            } if(itemInteract.name == "Bag")
            {
                PlayerPrefs.SetInt("bagTaken", 1);
                PlayerPrefs.SetInt("objective", objective + 1);
                Invoke(nameof(ClearItem), 1f);
            }

            itemInteract.GetComponent<DialogueTrigger>().TriggerDialogue();

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
