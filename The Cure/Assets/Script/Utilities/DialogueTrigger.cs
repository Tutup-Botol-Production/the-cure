using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    private int autodialog;

    private void Awake()
    {
        autodialog = PlayerPrefs.GetInt("autodialogOpened");
    }

    private void Start()
    {
        if(autodialog == 1 && gameObject.CompareTag("autodialog"))
        {
            ClearObject();
            FindObjectOfType<DialogueManager>().dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && gameObject.CompareTag("autodialog"))
        {
            PlayerPrefs.SetInt("autodialogOpened", 1);
            Invoke(nameof(TriggerDialogue), 1f);
            Invoke(nameof(ClearObject), 1.5f);
        }
    }

    public void ClearObject()
    {
        Destroy(gameObject);
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().dialogBox.SetActive(true);
        FindObjectOfType<DialogueManager>().dialogBox.GetComponent<Animator>().SetBool("isOpen", true);
        Invoke(nameof(DialogueStart), .5f);
    } 

    public void DialogueStart()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
