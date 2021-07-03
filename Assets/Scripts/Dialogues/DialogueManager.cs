using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // [Header("Dialogues")]
    // [SerializeField] private DialoguesPerScene[] scenes;

    // private ScenesManager scenesManager;
    // public static DialogueManager Instance = null;
    // private DialogueSoundManager soundMGMT;

    // private int dialogueCounter;
    // private int sentenceCounter;
    // private ScriptableDialogue currentDialogue;
    // public string currentDialogueID;
    // public bool canInteract = false;
    // private bool hasStarted = false;
    // public UnityEvent<string> DialogueStarted;

    // [Header("UI")]
    // [SerializeField] private GameObject dialogHUD;
    // [SerializeField] private TMP_Text title_Text;
    // [SerializeField] private TMP_Text body_Text;
    // [SerializeField] private TMP_Text button_Text;
    // [SerializeField] private GameObject _wrapperImage;
    // [SerializeField] private Image _speakerImage;

    // [Header("Time")]
    // [SerializeField] private float _timeBetweenletters;

    // [Header("Cats/Expositors")]
    // [SerializeField] private Sprite[] _cats = new Sprite[0];
    // private List<string> catNames = new List<string>  {"ricardo", "ricardos"};

    // private List<string> normalStrings = new List<string>  {"good! let's spill some blood!", "excuse me", "#capitalism", "we can dash with left shift", "i bet there’s a lever somewhere that opens this door.", "look! a lever!", "perfect, a litter box!", "that milk looks like it could “heal” us in some way", "we’re free", "we’re so close to the surface I can feel it in our whiskers!", "freedom!", "*grumpy meow*"};

    // private bool IsLastDialogue => currentDialogue?.Dialogues.Length - 1 == dialogueCounter;
    // private bool IsLastSentence => currentDialogue?.Dialogues[dialogueCounter].dialogueBodySentences.Length - 1 == sentenceCounter;

    // void Start()
    // {
    //     scenesManager = FindObjectOfType<ScenesManager>();
    //     Instance = this;
    //     dialogueCounter = 0;
    //     sentenceCounter = 0;
    //     canInteract = false;
    //     currentDialogueID = "";
    //     hasStarted = false;
    //     dialogHUD.SetActive(false);
    //     soundMGMT = GetComponent<DialogueSoundManager>();
    //     _wrapperImage.SetActive(false);

    //     if (DialogueStarted == null) DialogueStarted = new UnityEvent<string>();
    // } 

    // void OnDestroy()
    // {
    //     Instance = null;
    // }

    // public void StartDialogue()
    // {
    //     _wrapperImage.SetActive(false);
    //     if (hasStarted)
    //     {
    //         ActionButton();
    //         return;
    //     }

    //     if (currentDialogueID.Equals(String.Empty) || !canInteract)
    //     {
    //         return;
    //     }
                
    //     hasStarted = true;
    //     dialogHUD.SetActive(true);
    //     DialogueStarted.Invoke(currentDialogueID);

    //     DialoguesPerScene sceneDialogues = this.GetCurrentSceneDialogues();
    //     if (sceneDialogues == null)
    //     {
    //         return;
    //     }

    //     ScriptableDialogue dialog = GetCurrentDialogue(sceneDialogues.dialogues, this.currentDialogueID);
    //     if (dialog == null)
    //     {
    //         return;
    //     } 

    //     if (dialog.Dialogues.Length > 0)
    //     {
    //         currentDialogue = dialog;
    //         ShowDialogue(currentDialogue.Dialogues[dialogueCounter]);
    //     }
    // }

    // public void StopDialogue()
    // {
    //     soundMGMT.StopPlay();
    //     dialogueCounter = 0;
    //     sentenceCounter = 0;
    //     hasStarted = false;
    //     this.title_Text.text  = String.Empty;
    //     this.body_Text.text   = String.Empty;
    //     this.button_Text.text = String.Empty;
    //     _wrapperImage.SetActive(false);
    //     dialogHUD.SetActive(false);
    // }

    // public void ContinueDialogue()
    // {
    //     dialogueCounter++;
    //     sentenceCounter = 0;
    //     ShowDialogue(currentDialogue.Dialogues[dialogueCounter]);
    // }

    // public void ContinueSentences()
    // {
    //     sentenceCounter++;
    //     ShowDialogue(currentDialogue?.Dialogues[dialogueCounter]);
    // }

    // private void ShowDialogue(Dialogue dialogue)
    // {        
    //     if(dialogue == null) return;
    //     this.title_Text.text  = dialogue.expositorName + ": ";
    //     this.title_Text.color = dialogue.textColour;

    //     this.GetSetImage(dialogue);

    //     if (dialogue.dialogueBodySentences.Length > 0)
    //     {
    //         this.body_Text.color = dialogue.textColour;
    //         StopAllCoroutines();
    //         StartCoroutine(WriteText(dialogue.dialogueBodySentences[this.sentenceCounter]));

    //         this.button_Text.text = GetButtonText(dialogue.dialogueBodySentences.Length, sentenceCounter);
    //     }
    // }

    // IEnumerator WriteText(string textToWrite)
    // {
    //     this.body_Text.text = "";
    //     bool played         = false;
    //     string textToEval   = textToWrite.ToLower().Replace("\n", "").Replace("\r", "");
    //     bool containedIn    = normalStrings.Contains(textToEval);

    //     foreach (var character in textToWrite.ToCharArray())
    //     {
    //         this.body_Text.text += character;
    //         if(containedIn)
    //         {
    //              if (!played)
    //              {
    //                 soundMGMT.PlayNormal(normalStrings.IndexOf(textToEval));   
    //              }
    //             played = true;
    //         } 
    //         else
    //         {
    //             soundMGMT.Play();
    //         }

    //         yield return new WaitForSeconds(_timeBetweenletters);
    //     }
    //     if(!containedIn)
    //     {
    //         yield return new WaitForSeconds(_timeBetweenletters);
    //         soundMGMT.StopPlay();
    //     }
    // }

    // public void ActionButton()
    // {
    //     if (IsLastDialogue && IsLastSentence)
    //     {
    //         StopDialogue();
    //         return;
    //     } 
    //     if ((IsLastDialogue && !IsLastSentence) || (!IsLastDialogue && !IsLastSentence))
    //     {
    //         ContinueSentences();
    //         return;
    //     }
    //     if (!IsLastDialogue && IsLastSentence)
    //     {
    //         ContinueDialogue();
    //         return;
    //     }
    // }

    // public string GetButtonText(int sentencesLength, int index)
    // {
    //     if (sentencesLength <= 1 || (index >= sentencesLength - 1 &&  IsLastDialogue))
    //     {
    //         return Global.OK;
    //     }
    //     return Global.Continue;
    // }

    // private DialoguesPerScene GetCurrentSceneDialogues()
    // {
    //     foreach (var scene in scenes)
    //     {
    //         if (scenesManager.CurrentScene.Equals(scene.sceneName))
    //         {
    //             return scene;
    //         }
    //     }
    //     return null;
    // }

    // private ScriptableDialogue GetCurrentDialogue(ScriptableDialogue[] sceneDialogues, string id)
    // {
    //     foreach (var dialogue in sceneDialogues)
    //     {
    //         if (dialogue.DialogueId.Equals(id))
    //         {
    //             return dialogue;
    //         }
    //     }
    //     return null;
    // }

    // private void GetSetImage(Dialogue dialogue)
    // {
    //     if(catNames.Contains(dialogue.expositorName.ToLower()))
    //     {
    //         int catIndex = catNames.FindIndex(cat => cat == dialogue.expositorName.ToLower());
    //         _wrapperImage.SetActive(true);
    //         _speakerImage.sprite = _cats[catIndex];
    //     }
    // }

}
