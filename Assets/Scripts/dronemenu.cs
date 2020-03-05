using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dronemenu : MonoBehaviour
{
    float speed ;
    public GameObject drone;
    // Update is called once per frame
    private void Start() {
        speed = Time.deltaTime +2 ;
    }
    void Update()
    {
        drone.transform.Rotate(Vector3.right * speed);
    }
}
