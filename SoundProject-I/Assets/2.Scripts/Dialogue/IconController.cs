using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IconController
{
    public Image IconPrimary;
    public Image IconNpc;

    public void ChangeIcon(NPC_Dialogue propertiesOfDialogue, int index)
    {
        
        IconPrimary.sprite = propertiesOfDialogue.properties[index].iconPlayerSprite;
        IconNpc.sprite = propertiesOfDialogue.properties[index].iconNpcSprite;
    }

    public void DisableIcon()
    {
        IconPrimary.enabled = (IconPrimary.sprite == null) ? false : true;
        IconNpc.enabled = (IconNpc.sprite == null) ? false : true;
    }  

}
