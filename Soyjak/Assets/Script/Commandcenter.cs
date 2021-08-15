using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commandcenter : MonoBehaviour
{
    public bool Game;
    public bool FPSmode;
    public Transform[] Objects;
    int lightson;
    public bool asylum;
    // Start is called before the first frame update
    void Start()
    {
        if (Game == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FPSmode == true)
        {
            if(Objects[0].gameObject.activeInHierarchy == false)
            {
                int respawnposition = Random.Range(0, 4);
                Objects[0].transform.position = Objects[0].transform.GetComponent<SoyAI>().Patrolpoints[respawnposition].position;
                Objects[0].gameObject.SetActive(true);  
            }
            if(Objects[1].transform.GetComponent<SoyAI>().spawnedyet == false)
            {
                if (Objects[3].transform.GetComponent<Lookattake>().soylentbottles >= 5)
                {
                    Objects[1].gameObject.SetActive(true);
                    Objects[1].transform.GetComponent<SoyAI>().spawnedyet = true;
                }
            }
            if (Objects[4].transform.GetComponent<SoyAI>().spawnedyet == false)
            {
                if (Objects[3].transform.GetComponent<Lookattake>().soylentbottles >= 20    )
                {
                    Objects[4].gameObject.SetActive(true);
                    Objects[4].transform.GetComponent<SoyAI>().spawnedyet = true;
                }
            }
            
        }
        if (Time.timeScale == 0f)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(lightson == 1)
            {
                Objects[2].gameObject.SetActive(true);
                lightson = 0;
            }
            else
            {
                Objects[2].gameObject.SetActive(false);
                lightson = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            if(FPSmode == false)
            {
                if (asylum == false)
                {
                    Objects[3].gameObject.SetActive(true);
                }else
                {
                    Objects[16].gameObject.SetActive(true);
                }
            }else
            {
                Objects[5].gameObject.SetActive(true);
            }
        }

        if(asylum == true)
        {
            if(Objects[9].gameObject.activeInHierarchy == false&& Objects[10].gameObject.activeInHierarchy == false&& Objects[11].gameObject.activeInHierarchy == false&& Objects[12].gameObject.activeInHierarchy == false&& Objects[13].gameObject.activeInHierarchy == false)
            {
                Objects[14].gameObject.SetActive(true);
                Objects[15].gameObject.SetActive(false);
            }
        }
    }
    public void Startgame()
    {
        Game = false;
        Time.timeScale = 1;
    }

    public void Pancameratosoyjack()
    {
        Objects[0].gameObject.SetActive(true);
        Objects[1].gameObject.SetActive(false);
    }

    public void Panbacktoplayer()
    {
        Objects[0].gameObject.SetActive(false); 
        Objects[1].gameObject.SetActive(true);
    }

    public void Find7soylent()
    {
         Game = false;
        Time.timeScale = 1;
        Objects[4].gameObject.SetActive(false);
        Objects[5].gameObject.SetActive(true);
    }
    
    public void Opengates()
    {
       Objects[6].transform.GetComponent<Animator>().enabled = true;
        Objects[7].transform.GetComponent<Animator>().enabled = true;
        Objects[8].transform.GetComponent<Lookattake>().soylentbottles -= 7;
        Time.timeScale = 1;
    }

    public void Foundedexit()
    {
        Objects[9].gameObject.SetActive(true);
        Objects[10].gameObject.SetActive(true);
        Objects[11].gameObject.SetActive(true);
        Objects[12].gameObject.SetActive(true);
        Objects[13].gameObject.SetActive(true);
        Objects[14].gameObject.SetActive(true);
        Objects[15].gameObject.SetActive(true);
        Objects[16].gameObject.SetActive(true);
    }

    public void Foundedexitasylum()
    {
        Objects[0].gameObject.SetActive(true);
        Objects[1].gameObject.SetActive(true);
        Objects[3].gameObject.SetActive(true);
        Objects[4].gameObject.SetActive(true);
        Objects[5].gameObject.SetActive(true);
        Objects[6].gameObject.SetActive(true);
        Objects[7].gameObject.SetActive(true);
        Objects[8].gameObject.SetActive(true);
    }
}
