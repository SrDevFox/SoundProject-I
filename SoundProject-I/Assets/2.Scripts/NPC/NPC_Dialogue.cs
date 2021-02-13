using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField] DialogueController dialogue;

    public List<PropertiesDialogue> properties = new List<PropertiesDialogue>();

    private void OnMouseDown()
    {
        dialogue.callDialogue?.Invoke(this.gameObject);
    }
}