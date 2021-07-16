using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public string dialogID;
    public string expositorName;
    public DialogueePosition position;
    public string[] dialogueBody;

    public Dialogue(string id, string name,DialogueePosition position, string[] body)
    {
        this.dialogID = id;
        this.expositorName = name;
        this.dialogueBody  = body;
        this.position = position;
    }
}