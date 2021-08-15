 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lookattake : MonoBehaviour
{
    public Transform[] objects;
    public Text Soynumber;
    public int soylentbottles;
    public bool FPSscene;
    float range;
    public int ammunition;
    public Text Aemmunition;
    public Text MaxAemmunition;
    public int maxammunition;
    // Start is called before the first frame update
    void Start()
    {
        if(FPSscene == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(FPSscene == true)    
        {
            if (objects[0].transform.GetComponent<gunswaying>().Equipped == true)
            {
                maxammunition = 30;
            }else
            {
                maxammunition = 10;
            }
            Soynumber.text = soylentbottles.ToString();
            Aemmunition.text = ammunition.ToString();
            MaxAemmunition.text = maxammunition.ToString();
            RaycastHit shooted;
            if (Input.GetMouseButtonDown(0))
            {
                if(ammunition > 0)
                {
                    if (objects[2].transform.GetComponent<gunswaying>().Equipped == true)
                    {
                        objects[3].transform.GetComponent<ParticleSystem>().Play();
                        objects[2].transform.GetComponent<AudioSource>().Play();
                        range = 50f;
                        ammunition -= 1;
                    }
                    if (objects[0].transform.GetComponent<gunswaying>().Equipped == true)
                    {
                        objects[0].transform.GetComponent<AudioSource>().Play();
                        objects[1].transform.GetComponent<ParticleSystem>().Play();
                        range = 100f;
                        ammunition -= 1;
                    }
                    if (Physics.Raycast(transform.position, transform.forward, out shooted, range))
                    {
                        Debug.Log(shooted.transform.gameObject.name);
                        if (shooted.transform.tag == "soy")
                        {
                            shooted.transform.gameObject.SetActive(false);
                            soylentbottles += 1;
                        }
                    }
                }
            }

            if(ammunition <= 0)
            {
                StartCoroutine(Reload());
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());   
            }
        }else
        {
        Soynumber.text = soylentbottles.ToString();
        RaycastHit Looked;
       if(Physics.Raycast(transform.position,transform.forward,out Looked,50f))
        {
            if (Looked.transform.tag == "Gate")
            {
                objects[0].gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (soylentbottles >= 7)    
                    {
                        objects[8].gameObject.SetActive(true);
                        Time.timeScale = 0;
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                    }
                    else
                    {
                        objects[3].gameObject.SetActive(false);
                        objects[5].gameObject.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
            }
            else
            {
                objects[0].gameObject.SetActive(false);
            }
            if (Looked.transform.tag == "soy")
            {
                objects[6].gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Looked.transform.gameObject.SetActive(false);
                    soylentbottles += 1;
                }
            }else
            {
                objects[6].gameObject.SetActive(false);
            }
            if (soylentbottles >= 7)
            {
                objects[4].gameObject.SetActive(false);
                objects[7].gameObject.SetActive(true);
            }else
            {
                objects[7].gameObject.SetActive(false);
            }
        }
    }
}
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2f);
        ammunition = maxammunition;
    }
}
    