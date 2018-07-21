using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSaveDelete : MonoBehaviour
{
    public GameObject DeletePanel;

    public Button DeleteButton;

    public void InvokeDelete()
    {
        DeletePanel.SetActive(true);
        if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile.sav") == true)
            DeleteButton.interactable = true;

        else if (System.IO.File.Exists(Application.persistentDataPath + "/saveFile.sav") == false)
            DeleteButton.interactable = false;
    }

    public void ConfirmDelete()
    {
        SaveLoad.Delete();
    }

    public void CancelDelete()
    {
        DeletePanel.SetActive(false);
    }
}
