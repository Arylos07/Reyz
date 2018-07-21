using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public Button ThisButton;

    public void SaveRecord()
    {
        SaveLoad.Save();
        ThisButton.interactable = false;
    }
}
