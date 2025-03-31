using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_collide_event : MonoBehaviour
{
    public DialogueSystem system;
    public DialogueTriggerShop dialogue;
    public DialogManager controlDialogue;


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name == "NPC") 
        {
            Debug.Log("NPC trigger");
            system.state = State.ORDERING;
            dialogue.TriggerDialogue();


        }
        if (other.name == "NPC_weapon") 
        {
            Debug.Log("NPC weapon trigger");
            system.state = State.ORDERING;
            system.onShow_weaponset();
            dialogue.TriggerDialogue();
        }
        if (other.name == "NPC_healStation")
        {
            Debug.Log("NPC healStation trigger");
            system.state = State.ORDERING;
            dialogue.TriggerDialogue();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.name == "NPC") 
        {
            Debug.Log("NPC left");
            system.state = State.WALKING;
            controlDialogue.EndDialogue();
            
        }
        if (other.name == "NPC_weapon")
        {
            Debug.Log("NPC weapon trigger");
            system.state = State.WALKING;
            controlDialogue.EndDialogue();
        }
        if (other.name == "NPC_healStation")
        {
            Debug.Log("NPC_healStation left");
            system.state = State.WALKING;
            controlDialogue.EndDialogue();
        }
    }
}
