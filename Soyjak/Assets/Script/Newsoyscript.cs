using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Newsoyscript : MonoBehaviour
{
    public Transform[] Patrolpoint;
    public Transform Player;
    public Transform Jumpscare;
    public bool finalscene;
    bool p1;
    bool p2;
    bool p3;
    // Start is called before the first frame update
    void Start()
    {
        p1 = true;   
    }

    // Update is called once per frame
    void Update()
    {
        //Detects whether it's the final scene or not
        if (finalscene == false)
        {
            //Stops patrolling and chases player when player is close to certain distance
            Vector3 Playerposition = Player.transform.position;
            if (Vector3.Distance(transform.position, Player.position) < 8f)
            {
                transform.GetComponent<NavMeshAgent>().SetDestination(Playerposition);
                transform.GetComponent<AudioSource>().enabled = true;
            }else
            {
                Patrolling();
                transform.GetComponent<AudioSource>().enabled = false;
            }
        }else
        {
            Vector3 Playerposition = Player.transform.position;
            transform.GetComponent<NavMeshAgent>().SetDestination(Playerposition);
            transform.GetComponent<AudioSource>().enabled = true;
        }
    }

    public void Patrolling()
    {
        //Detecting player's distance
        //Patrol points
        Vector3 Patrolpoint1 = Patrolpoint[0].transform.position;
        Vector3 Patrolpoint2 = Patrolpoint[1].transform.position;
        Vector3 Patrolpoint3 = Patrolpoint[2].transform.position;
        //Patrolling
        if (Vector3.Distance(transform.position, Patrolpoint[0].transform.position) < 1f)
        {
            p2 = true;
            p1 = false;
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint1);
        }
        if (Vector3.Distance(transform.position, Patrolpoint[1].transform.position) < 1f)
        {
            p3 = true;
            p2 = false;
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint2);
        }
        if (Vector3.Distance(transform.position, Patrolpoint[2].transform.position) < 1f)
        {
            p1 = true;
            p3 = false;
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint3);
        }
        //Moving to patrolpoints
        if (p1 == true)
        {
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint1);
        }
        if (p2 == true)
        {
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint2);
        }
        if (p3 == true)
        {
            transform.GetComponent<NavMeshAgent>().SetDestination(Patrolpoint3);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            Jumpscare.gameObject.SetActive(true);
            StartCoroutine(Endgame());
        }
    }
    IEnumerator Endgame()
    {
        yield return new WaitForSeconds(3f);
        Player.gameObject.SetActive(false);
        SceneManager.LoadScene(8);
    }
    
    public void Finalscene()
    {
        finalscene = true;
    }
}
