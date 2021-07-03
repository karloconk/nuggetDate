using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.Rendering.Universal;

public class DialogueInteractable : MonoBehaviour
{
    [SerializeField] private string dialogueId; 
    Rigidbody2D _rb;
    [SerializeField] private bool isForced = false;
    [SerializeField] private Light2D _lightSource;

    private void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();  
        Invoke("SetupEvent", .2f);
    }

    private void SetupEvent()
    {
        //DialogueManager.Instance?.DialogueStarted.AddListener(DialogueStarted);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag(Global.PlayerTag))
        // {
        //     DialogueManager.Instance.currentDialogueID = dialogueId;
        //     DialogueManager.Instance.canInteract       = true;
        //     if (isForced)
        //     {
        //         DialogueManager.Instance.StartDialogue();
        //     }
        // }
        // if (_lightSource != null) _lightSource.color = Color.yellow;
    }

    private void DialogueStarted(string id)
    {
        if (id == dialogueId) _lightSource.gameObject.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(Global.PlayerTag))
        {
            // DialogueManager.Instance.canInteract = false;
            // DialogueManager.Instance.currentDialogueID = "";
            // DialogueManager.Instance.StopDialogue();
        }
        if (_lightSource != null) _lightSource.color = Color.white;
    }

}