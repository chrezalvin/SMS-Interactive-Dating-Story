using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string name;
    [TextArea] public string dialogue;
    public string animationParam = "";

}
