using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunswaying : MonoBehaviour
{
    private Vector3 Initialposition;
    public bool Equipped;
    public float ammunition;
    // Start is called before the first frame update
    void Start()
    {
        Initialposition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Mouse X") *0.5f;
        float movementY = Input.GetAxis("Mouse Y") *0.5f;
        Vector3 Finalpos = new Vector3(movementX,movementY,0f);
        transform.localPosition = Vector3.Lerp(transform.localPosition,Finalpos+Initialposition,Time.deltaTime*1f);
    }
}
