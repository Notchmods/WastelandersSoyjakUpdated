using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lastscript : MonoBehaviour
{
    public Transform[] Things;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Things[0]);
        StartCoroutine(Soyjacdancing());
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator Soyjacdancing()
    {
        yield return new WaitForSeconds(5f);
        Things[1].gameObject.SetActive(true);
        Things[2].gameObject.SetActive(true);
        Things[3].gameObject.SetActive(true);
        Things[4].gameObject.SetActive(true);
        Things[5].gameObject.SetActive(true);
    }
}
