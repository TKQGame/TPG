using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    


    void Start()
    {

    }
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene("Test");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        SceneManager.LoadScene("Exit");
        Debug.Log("Exit");
    }


    public void BackInMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
