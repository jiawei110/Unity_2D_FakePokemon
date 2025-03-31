using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerShop : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
