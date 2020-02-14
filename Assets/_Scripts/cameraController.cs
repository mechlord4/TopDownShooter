using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Vector3 targetPos;
    

    // Update is called once per frame
    void Update()
    {
        float t = .05f;
        Vector3 newPos =  new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, targetPos.y, t * Time.deltaTime) , -10);
        t *= .05f;
        transform.position = newPos;
    }
}
