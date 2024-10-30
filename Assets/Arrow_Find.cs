using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Find : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);

    }
}
