using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueEntry
{
    public string speaker;
    public bool reversed;

    // Content-related
    [TextArea(5, 5)] 
    public string content;

    [Tooltip("Check this box to use the CPS below. Otherwise, will use the default.")] 
    public bool useCPS;

    [Range(0, 120)] 
    [Tooltip("Characters to reveal per second. Set this to 0 to disable the typewriting effect")] 
    public int CPS = 30;

}
