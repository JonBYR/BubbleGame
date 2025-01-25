using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //required to have Quest object as public
public class Quest
{
    public bool isActive;
    public string title;
    public string description;
    public string reward;
    public GameObject NPC;
}
