using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private Key k1;
    [SerializeField] private Key k2;
    [SerializeField] private PlayerController p1;
    [SerializeField] private PlayerController p2;
    [SerializeField] private DialogueSystem system;
    [SerializeField] private Dialogue dialogue;
    private bool triggered;

    public void checkKey()
    {
        Debug.Log("Checking Key");
        if (k1.done && k2.done && p1.chestActive && p2.chestActive && !triggered)
        {
            triggered = true;
            triggerDialogue();
        }
    }

    private void triggerDialogue()
    {
        system.gameObject.SetActive(true);
        system.QueueDialogue(dialogue);
        p1.levelComplete();
        p2.levelComplete();
    }
}
