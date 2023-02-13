using UnityEngine;

public class InteractItem : MonoBehaviour
{
    [SerializeField] private GameObject interactBtn;
    [SerializeField] private GameObject gameManager;

    private int bag;

    private void Awake()
    {
        bag = PlayerPrefs.GetInt("bagTaken");
    }

    private void Start()
    {
        if (bag == 1 && gameObject.CompareTag("bag"))
        {
            ClearObject();
        }
    }

    public void ClearObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision Enter");
            gameManager.GetComponent<GameManager>().itemInteract = gameObject;

            if(gameObject.CompareTag("main door"))
            {
                PlayerPrefs.SetFloat("playerPosX", collision.transform.position.x);
                PlayerPrefs.SetFloat("playerPosY", collision.transform.position.y);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision Exit");
            gameManager.GetComponent<GameManager>().itemInteract = null;
        }
    }
}
