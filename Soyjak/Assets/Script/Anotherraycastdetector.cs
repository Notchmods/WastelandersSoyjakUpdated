using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Anotherraycastdetector : MonoBehaviour
{
    public Transform Openthedoor;
    public Transform Clicktocollectthesoylent;
    public bool firstscene;
    public int soylentbottles;
    public Transform[] Scenes;
    public Text Soynumber;
    bool guns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(firstscene == true)
        {
            Previouslevelraycast();
        }else
        {
            Insidescene();
        } 
        //Shoot the gun
        if(guns == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Will shoot the gun if you press the left click
                Shootguns();
            }
        }
    }

    public void Previouslevelraycast()
    {
        RaycastHit See;
        if (Physics.Raycast(transform.position, transform.forward, out See, 30f))
        {
            if (See.transform.tag == "Walls")
            {
                Openthedoor.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    SceneManager.LoadScene(4);
                }
            }
            else
            {
                Openthedoor.gameObject.SetActive(false);
            }
        }
    }

    public void Insidescene()
    {
        RaycastHit See;
        if (Physics.Raycast(transform.position, transform.forward, out See, 8f))
        {
            if (See.transform.tag == "Save")
            {
                Openthedoor.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Time.timeScale = 0;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    if (soylentbottles < 8)
                    {
                        Scenes[0].gameObject.SetActive(true);
                    }else
                    {
                        Scenes[1].gameObject.SetActive(true);
                    }
                }
            }else
            {
                Openthedoor.gameObject.SetActive(false);
            }

            if (See.transform.tag == "Soylent")
            {
                Clicktocollectthesoylent.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    soylentbottles += 1;
                    Soynumber.text = soylentbottles.ToString();
                    See.transform.gameObject.SetActive(false);
                }
            }else
            {
                Clicktocollectthesoylent.gameObject.SetActive(false);
            }

            if(See.transform.tag == "Door")
            {
                Scenes[3].gameObject.SetActive(true);
                if (guns == true)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        SceneManager.LoadScene(9);
                    }
                } 
            }else
            {
                Scenes[3].gameObject.SetActive(false);
            }
        }
    }

    public void Gunshoot()
    {
        guns = true;
    }

    public void Shootguns()
    {
        RaycastHit Shot;
        if (Physics.Raycast(transform.position, transform.forward, out Shot, 50f))
        {
            Debug.Log(Shot.transform.name);
            if (Shot.transform.tag == "soy")
            {
                Shot.transform.gameObject.SetActive(false);
            }
        }
        transform.GetComponent<AudioSource>().Play();
        Scenes[2].transform.GetComponent<ParticleSystem>().Play();
    }
}
