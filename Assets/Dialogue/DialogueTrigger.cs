using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public BattleSystem battleSystem;

    public void TriggerDialogue()
    {
        if (battleSystem.state == BattleState.PLAYERTURN)
        {
            FindObjectOfType<DialogManager>().StartDialogue(dialogue);
        }
    }
}
