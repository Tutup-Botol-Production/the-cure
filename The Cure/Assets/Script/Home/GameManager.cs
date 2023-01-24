using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject itemInteract = null;

    public void OnInteractBtnClick()
    {
        if (itemInteract != null)
        {
            Destroy(itemInteract);
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
