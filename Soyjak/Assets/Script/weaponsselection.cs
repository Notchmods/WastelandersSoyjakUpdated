using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponsselection : MonoBehaviour
{
    public Transform[] Weapons;
    public Lookattake Score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {

                Weapons[0].gameObject.SetActive(false);
                Weapons[1].gameObject.SetActive(true);
                Weapons[0].transform.GetComponent<gunswaying>().Equipped = false;
                Weapons[1].transform.GetComponent<gunswaying>().Equipped = true;
                Weapons[2].transform.GetComponent<Lookattake>().ammunition = 10;
            Weapons[2].transform.GetComponent<Lookattake>().Aemmunition.text = Weapons[2].transform.GetComponent<Lookattake>().ammunition.ToString();
                Weapons[2].transform.GetComponent<Lookattake>().MaxAemmunition.text = Weapons[2].transform.GetComponent<Lookattake>().maxammunition.ToString();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                    Weapons[0].gameObject.SetActive(true);
                    Weapons[1].gameObject.SetActive(false);
                    Weapons[0].transform.GetComponent<gunswaying>().Equipped = true;
                    Weapons[1].transform.GetComponent<gunswaying>().Equipped = false;
                     Weapons[2].transform.GetComponent<Lookattake>().ammunition = 30;
                Weapons[2].transform.GetComponent<Lookattake>().Aemmunition.text = Weapons[2].transform.GetComponent<Lookattake>().ammunition.ToString();
                    Weapons[2].transform.GetComponent<Lookattake>().MaxAemmunition.text = Weapons[2].transform.GetComponent<Lookattake>().maxammunition.ToString();
            }
        }
    }
