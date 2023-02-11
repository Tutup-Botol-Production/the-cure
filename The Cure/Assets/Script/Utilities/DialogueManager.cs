using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    
    public GameObject dialogBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public float typeSpeed;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence)
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    void EndOfDialogue()
    {
        dialogBox.GetComponent<Animator>().SetBool("isOpen", false);

        Invoke("CloseDialogue", 1f);

    }

    void CloseDialogue()
    {
        dialogBox.SetActive(false);
    }


}
