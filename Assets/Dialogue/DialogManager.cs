using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentences;
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)    
    {
        Debug.Log("Starting conversation with " + dialogue.name);       //show in debug

        animator.SetBool("isOpen",true);
        nameText.text = dialogue.name;

        sentences.Clear();     //clear the queus

        foreach (string sentence in dialogue.sentences) 
        {
            sentences.Enqueue(sentence);  //import all sentences in dialogue int queue
            //Debug.Log("ok");
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() 
    {
        if (sentences.Count == 0)
        {
            
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    public void EndDialogue()
    {
        Debug.Log("END of conversation ");
        animator.SetBool("isOpen", false);
    }

}
