using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Dialog", menuName = "NPC Dialog")]
public class NPCdialoge : ScriptableObject
{
    public string npcName;
    public Sprite nopcPortrait;
    public string[] dialogLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.5f;
    

}
