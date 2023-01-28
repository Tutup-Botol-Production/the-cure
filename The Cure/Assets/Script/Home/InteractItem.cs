using UnityEngine;

public class InteractItem : MonoBehaviour
{
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private string changeScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision Enter");
            gameManager.GetComponent<GameManager>().itemInteract = gameObject;

            if(gameObject.name == "Door")
            {
                gameManager.GetComponent<GameManager>().moveScene = changeScene;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision Exit");
            gameManager.GetComponent<GameManager>().itemInteract = null;
            gameManager.GetComponent<GameManager>().moveScene = null;
        }
    }
}
