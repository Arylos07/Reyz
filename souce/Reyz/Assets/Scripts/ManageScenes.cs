using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScenes : MonoBehaviour
{

    public Text LevelError = null;

    private static GameObject ManagerObject;

    private void Awake()
    {
        ManagerObject = gameObject;
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }

    public static void FirstLevelError()
    {
        ManagerObject.GetComponent<ManageScenes>().LevelError.gameObject.SetActive(true);
        Debug.Log("Level Error: FirstLevelComplete != true.");
    }

    public void RecordScreen()
    {
        SceneManager.LoadScene("RecordScreen1");
    }

    public void QuitGame()
    {
        Debug.Log("Application.Quit()");
        Application.Quit();
    }
}
