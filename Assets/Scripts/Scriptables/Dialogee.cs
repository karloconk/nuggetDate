using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogee : ScriptableObject
{
    public string DisplayName = "New Dialogee";
    public string codename    = "default";
    public Sprite Normal;
    public Sprite Neutral;
    public Sprite Happy;
    public Sprite Sad;
    public Sprite Angry;
    public Sprite Scared;
}