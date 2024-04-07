using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;
    [SerializeField] private int cablePoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] cablePoints = new GameObject[12];
    [SerializeField] private GameObject[] bottomPoints = new GameObject[12];

    void Start() {
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        //cablePoint = Random.Range(0, 12);
        Debug.Log(cablePoint);
    }

    void Update() {
        if (!rb.useGravity) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BottomPoint")) {
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }

        if (other.gameObject == cablePoints[cablePoint]) {
            rb.useGravity = true;
            transform.position = other.gameObject.transform.position;
        }
    }
}