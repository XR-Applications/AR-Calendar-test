using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectParentControl : MonoBehaviour
{
    [SerializeField] float xRot = 5f;
    [SerializeField] float yRot = 5f;
    [SerializeField] float zRot = 5f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xRot * Time.deltaTime, yRot * Time.deltaTime, zRot * Time.deltaTime);
    }
}
