using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class Init : MonoBehaviour
{
    public GameObject Controller;
    public GameObject Console;
    public Camera MapCam;
    public GameObject SaveManager;
    public GameObject SceneController;

    public static bool ToMenu = true;

    public Image fadeOverlay;
    public float fadeDuration;

    private void Start()
    {
        fadeOverlay.canvasRenderer.SetAlpha(0.0f);
    }

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("GameController") == null)
            Instantiate(Controller, transform.position, transform.rotation);

        if (GameObject.FindGameObjectWithTag("Console") == null)
            Instantiate(Console, transform.position, transform.rotation);

        if (GameObject.FindGameObjectWithTag("MapCamera") == null)
        {
            Instantiate(MapCam, transform.position, transform.rotation);
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("MapCamera"));
            //GameObject.FindGameObjectWithTag("MapCamera").SetActive(false);
            //MapCam = GameController.MapCamera;
        }

        if (GameObject.FindGameObjectWithTag("SaveLoad") == null)
            Instantiate(SaveManager, transform.position, transform.rotation);

        if (GameObject.FindGameObjectWithTag("SceneController") == null)
            Instantiate(SceneController, transform.position, transform.rotation);

        SaveLoad.Load();

        //Manually load main menu

        if (ToMenu == true)
        {
            if (File.Exists(Application.dataPath + "/load.dat"))
            {
                Invoke("MainMenu", 4f);
            }
            else if(!File.Exists(Application.dataPath + "/load.dat"))
            {
                SceneManager.LoadScene("Error");
            }
        }
    }
    public void MainMenu()
    {
        //fadeOverlay.CrossFadeAlpha(1.0f, fadeDuration, true);
        Invoke("MainMenuLoad", 0f);
    }

    public void MainMenuLoad()
    {
        SceneManager.LoadScene(1);
    }
}
