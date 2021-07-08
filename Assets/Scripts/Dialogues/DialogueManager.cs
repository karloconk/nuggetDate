using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogues and prefabs")]
    [SerializeField] private SceneDialogues _sceneDialogues;
    [SerializeField] private Sprite _backgroundImage;
    [SerializeField] private Dialogee[] _dialogees = new Dialogee[0];
    [SerializeField] private Dialogue[] _dialogues;

    [Header("Text colour")]
    [SerializeField] private Color textColour;
    
    private DialogueSoundManager soundMGMT;

    private int dialogueCounter;
    private int sentenceCounter;
    private Dialogue currentDialogue;
    public string currentDialogueID;

    [Header("UI")]
    [SerializeField] private GameObject dialogHUD;
    [SerializeField] private TMP_Text title_Text;
    [SerializeField] private TMP_Text body_Text;
    [SerializeField] private GameObject _leftExpositor;
    [SerializeField] private GameObject _middleExpositor;
    [SerializeField] private GameObject _rightExpositor;
    [SerializeField] private TMP_Text button_Text;
    [SerializeField] private TMP_Text button2_Text;
    [SerializeField] private TMP_Text button3_Text;

    private float _timeBetweenletters;
    private CSVParser _parser = new CSVParser();

    void Start()
    {
        dialogHUD.SetActive(false);
        soundMGMT = GetComponent<DialogueSoundManager>();
        this._dialogues = _parser.Parse(_sceneDialogues);
    }

    public void StartDialog()
    {
        dialogHUD.SetActive(true);
    }

    public void EndDialog()
    {
        soundMGMT.StopPlay();
        dialogueCounter = 0;
        sentenceCounter = 0;
        this.title_Text.text  = String.Empty;
        this.body_Text.text   = String.Empty;
        this.button_Text.text = String.Empty;
        dialogHUD.SetActive(false);
    }

    public void ContinueDialogueEvent()
    {
        dialogueCounter++;
        sentenceCounter = 0;
    }

    public void ContinueSentences()
    {
        sentenceCounter++;
    }

    private void ShowDialogue(Dialogue dialogue)
    {        
        if(dialogue == null) return;
        this.title_Text.text  = dialogue.expositorName + ": ";
        this.title_Text.color = textColour;
        this.body_Text.color  = textColour;

        this.GetSetImage(dialogue);

        if (dialogue.dialogueBody.Length > 0)
        {
            StopAllCoroutines();
            StartCoroutine(WriteText(dialogue.dialogueBody[this.sentenceCounter]));

            // Do something with buttons
        }
    }

    IEnumerator WriteText(string textToWrite)
    {
        this.body_Text.text = "";

        foreach (var character in textToWrite.ToCharArray())
        {
            this.body_Text.text += character;
            soundMGMT.Play();

            yield return new WaitForSeconds(_timeBetweenletters);
        }
        soundMGMT.StopPlay();
    }

    private void GetSetImage(Dialogue dialogue)
    {
        foreach (var dialogee in _dialogees)
        {
            if(dialogee.codename == dialogue.expositorName)
            {

            }
        }
    }

}
