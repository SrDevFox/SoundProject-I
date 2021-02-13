using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public delegate void CallDialogue(GameObject gameObjectCalling);
    public CallDialogue callDialogue;
    [SerializeField] NPC_Dialogue propertiesOfDialogue;
    [SerializeField] IconController iconController;

    public Text text;
    public GameObject canvasDialogue;
    public GameObject NextButton;

    int index;

    public void StartDialogue(GameObject gameObjectCalling)
    {
        canvasDialogue.SetActive(true);
        iconController.IconPrimary.enabled = true;
        propertiesOfDialogue = gameObjectCalling.GetComponent<NPC_Dialogue>();
        NextButton.SetActive(true);

        index = 0;

        iconController.ChangeIcon(propertiesOfDialogue, index);
        iconController.DisableIcon();

        text.text = GetPhrase();

        callDialogue -= StartDialogue;
    }

    public void RunningDialogue()
    {
        index++;
        if(index < propertiesOfDialogue.properties.Count)
            NextPhrase();
        else
            EndDialogue();
    }

    void NextPhrase()
    {
        text.text = GetPhrase();
        iconController.ChangeIcon(propertiesOfDialogue, index);
        iconController.DisableIcon();
    }

    void EndDialogue () 
    {  
        iconController.IconPrimary.enabled = false;
        canvasDialogue.SetActive (false);
        NextButton.SetActive(false);
        callDialogue += StartDialogue;
    }

    string GetPhrase() => propertiesOfDialogue.properties[index].phrase;

    private void OnEnable () => callDialogue += StartDialogue;

    private void OnDisable () => callDialogue -= StartDialogue;
    
}