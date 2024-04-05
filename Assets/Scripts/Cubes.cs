using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private Rigidbody rb;
    private int cablePoint = 0;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] cablePoints = new GameObject[12];

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cablePoint = Random.Range(0, 12);
        Debug.Log(cablePoint);
    }

    void Update()
    {
        if (!rb.useGravity) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject == cablePoints[cablePoint]) {
            rb.useGravity = true;
            transform.position = other.gameObject.transform.position;
        }
    }
}