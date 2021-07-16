using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

class CSVParser
{
    private char lineCarriage  = '\n';
    private char enclosingChar = '"';
    private string[] fieldsSeparator = {"\",\""};
    private int nameIndex     = 0;
    private int positionIndex = 3;
    private int languageIndex = 4;
    private int languageModifier = 0;
    private int bodyIndex => languageIndex + languageModifier;

    public Dialogue[] Parse(SceneDialogues dialoguesS, Language language = Language.English)
    {
        if(dialoguesS == null)
        {
            return null;
        }

        languageModifier = (int)language;
        List<Dialogue> dialogues = new List<Dialogue>();

        foreach (var csvFile in dialoguesS.dialoguesForScene)
        {
            dialogues.AddRange(GetDialogues(csvFile));
        }

        return dialogues.ToArray();
    }

    private List<Dialogue> GetDialogues(TextAsset csv)
    {
        string[] rows = csv.text.Split(lineCarriage);

        List<Dialogue> dialogues      = new List<Dialogue>();
        List<string> currentSentences = new List<string>();

        string currentName = "";
        string currentID   = "";
        DialogueePosition currentpos = DialogueePosition.Left;
        for (int i = 1; i < rows.Length; i++)
        {
            string[] row = rows[i].Split(fieldsSeparator, StringSplitOptions.None);
            currentpos = GetPosEnum(row[positionIndex]);
            currentID  = row[0];
            if (!row[nameIndex].Equals(currentName))
            {
                if (i > 1)
                {
                    dialogues.Add(new Dialogue(currentID, currentName, currentpos, currentSentences.ToArray()));
                }
                currentSentences.Clear();
                currentName = row[nameIndex];
            }
            currentSentences.Add(row[bodyIndex]);
        }
        dialogues.Add(new Dialogue(currentID, currentName, currentpos, currentSentences.ToArray()));

        return dialogues.Count != 0 ? dialogues : null;
    }

    private DialogueePosition GetPosEnum(string codename)
    {
        switch (codename.ToLower())
        {
            case "left":
                return DialogueePosition.Left;
            case "mid":
                return DialogueePosition.Middle;
            case "right":
                return DialogueePosition.Right;
            default:
                return DialogueePosition.Left;
        }
    }

}
