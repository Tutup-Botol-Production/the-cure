using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [HideInInspector] public GameObject itemInteract = null;
    [HideInInspector] public bool isMenuOpen = false;

    [SerializeField] private GameObject subMenu;

    public void OnInteractBtnClick()
    {
        if (itemInteract != null)
        {
            Destroy(itemInteract);
        }
    }

    public void OnMenuBtnClick()
    {
        if (isMenuOpen)
        {
            subMenu.SetActive(false);
            isMenuOpen = false;
        } else
        {
            subMenu.SetActive(true);
            isMenuOpen = true;
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
