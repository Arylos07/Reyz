using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public bool DontDestroy;

    public int MinIndex;

    void Awake ()
    {
        if(DontDestroy == true)
            DontDestroyOnLoad(gameObject);
	}
	
    public void LoadScene(int levelnum)
    {
        LoadingScreenManager.LoadScene(levelnum);
        Init.ToMenu = false;
    }

    public void LoadMenuScene(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
        Init.ToMenu = false;
    }

    public void RandomLevel(int MaxIndex)
    {
        if (GameController.FirstLevelComplete != true)
            ManageScenes.FirstLevelError();

        if (GameController.FirstLevelComplete == true)
        {
            LoadingScreenManager.LoadScene(Mathf.RoundToInt(Random.Range(MinIndex, MaxIndex)));
            Init.ToMenu = false;
        }
    }
}
