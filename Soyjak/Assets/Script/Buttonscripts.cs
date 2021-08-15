using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttonscripts : MonoBehaviour
{
    public bool menu;
    // Start is called before the first frame update
    void Start()
    {
        if(menu == true)
        {
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Playgame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level2()
    {
        SceneManager.LoadScene(7);
    }

    public void Level3()
    {
        SceneManager.LoadScene(5);
    }


}
