using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Savesystem : MonoBehaviour
{
    public bool[] Finishscene;
    public GameObject[] Savedobject;
    int levels;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Scene activescene = SceneManager.GetActiveScene();
        string scenename = activescene.name;
        if (Finishscene[0] == true)
        {
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }

        if (Finishscene[1] == true)
        {
            PlayerPrefs.SetInt("Level", 2);
            PlayerPrefs.Save();
        }

        if (scenename == "Menu")
        {
           if(Savedobject[0].activeInHierarchy == true)
            {
                levels = PlayerPrefs.GetInt("Level");
                Debug.Log(levels);
                if(levels == 1) 
                {
                    Savedobject[1].gameObject.SetActive(false);
                }
                if (levels == 2)
                {
                      Savedobject[1].gameObject.SetActive(false);
                    Savedobject[2].gameObject.SetActive(false);
                }
            }
        }
       
    }
}
