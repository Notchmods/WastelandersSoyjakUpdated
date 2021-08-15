using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SoyAI : MonoBehaviour
{
    public Transform Escaper;
    public Lookattake Soylentaccess;
    public AudioSource[] Songs;
    bool consooming;
    bool patrooling;
    public Transform[] Patrolpoints;
    public bool p1;
    public bool p2;
    public bool p3;
    public bool p4;
    public bool p5;
    public bool p6; 
    public float range;
    bool soylentless;
    public bool FPSmodes;
    public bool spawnedyet;

    // Start is called before the first frame update
    void Start()
    {
        consooming = false;
        patrooling = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(FPSmodes == true)
        {
            Vector3 Players = Escaper.transform.position;
            transform.GetComponent<NavMeshAgent>().SetDestination(Players);
        }
        else
        {
        if(Soylentaccess.soylentbottles > 6)
        {
            soylentless = true;
        }else
        {
            soylentless = false;
        }
        if(soylentless == true)
        {
            Songs[1].enabled = true;
            Vector3 Players = Escaper.transform.position;
            transform.GetComponent<NavMeshAgent>().SetDestination(Players);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            range = 200f;
        }else
        { 
            if(soylentless == false )
            {
            range = 100f;
            if (Vector3.Distance(transform.position, Escaper.transform.position) < range)
            {
                Vector3 Players = Escaper.transform.position;
                transform.GetComponent<NavMeshAgent>().SetDestination(Players);
                patrooling = false;
            }else
            {
                patrooling = true;
                Vector3 Points1 = Patrolpoints[0].transform.position;
                Vector3 Points2 = Patrolpoints[1].transform.position;
                Vector3 Points3 = Patrolpoints[2].transform.position;
                Vector3 Points4 = Patrolpoints[3].transform.position;
                Vector3 Points5 = Patrolpoints[4].transform.position;
                Vector3 Points6 = Patrolpoints[5].transform.position;
                if (patrooling == true)
                {
                    //Detect whether they're close to the patrol points then change it
                    if (Vector3.Distance(transform.position, Patrolpoints[0].transform.position) < 10f)
                    {
                        p2 = true;
                        p1 = false;
                    }
                    if (Vector3.Distance(transform.position, Patrolpoints[1].transform.position) < 10f)
                    {
                        p3 = true;
                        p2 = false;
                    }
                    if (Vector3.Distance(transform.position, Patrolpoints[2].transform.position) < 10f)
                    {
                        p4 = true;
                        p3 = false;
                    }
                    if (Vector3.Distance(transform.position, Patrolpoints[3].transform.position) < 10f)
                    {
                        p5 = true;
                        p4 = false;
                    }
                    if (Vector3.Distance(transform.position, Patrolpoints[4].transform.position) < 10f)
                    {
                        p6 = true;
                        p5 = false;
                    }
                    if (Vector3.Distance(transform.position, Patrolpoints[5].transform.position) < 10f)
                    {
                        p6 = false;
                        p1 = true;
                    }
                    if (p1 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points1);
                    }
                    if (p2 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points2);
                    }
                    if (p3 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points3);
                    }
                    if (p4 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points4);
                    }
                    if (p5 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points5);
                    }
                    if (p6 == true)
                    {
                        transform.GetComponent<NavMeshAgent>().SetDestination(Points6);
                    }
                }
            }
            }
            if (consooming == false)
            {
                if (Vector3.Distance(transform.position, Escaper.transform.position) < 100f)
                {
                    Songs[1].enabled = true;
                }
                else
                {
                    Songs[1].enabled = false;
                }
            }
        }

        switch (Soylentaccess.soylentbottles)
        {
            case 1:
                transform.GetComponent<NavMeshAgent>().speed = 30;
                break;
            case 3:
                transform.GetComponent<NavMeshAgent>().speed = 40;
                break;
            case 5:
                transform.GetComponent<NavMeshAgent>().speed = 50;
                break;
        }
    }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (FPSmodes == false)
            {
                Escaper.transform.GetComponent<CharacterController>().enabled = false;
                Patrolpoints[6].gameObject.SetActive(true);
                consooming = true;
                patrooling = false; 
                StartCoroutine(Shock());
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Patrolpoints[5].gameObject.SetActive(true);
            StartCoroutine(ShockFPS());
        }
    }

    IEnumerator Shock()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);  
    }

    IEnumerator ShockFPS()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(6);
    }
}
