using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int autodialog;
    public int bag;

    private void Awake()
    {
        autodialog = PlayerPrefs.GetInt("autodialogOpened");
        bag = PlayerPrefs.GetInt("bagTaken");
    }

    private void Start()
    {
        if(autodialog == 1 && gameObject.CompareTag("autodialog"))
        {
            ClearObject();
            FindObjectOfType<DialogueManager>().dialogBox.SetActive(false);
        } if(bag == 1)
        {
            ClearObject();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && gameObject.CompareTag("autodialog"))
        {
            PlayerPrefs.SetInt("autodialogOpened", 1);
            Invoke("TriggerDialogue", 1f);
            Invoke("ClearObject", 1.5f);
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
        Invoke("DialogueStart", .5f);
    } 

    public void DialogueStart()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
