using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private Rigidbody rb;
    private bool isGrounded;
    [SerializeField] private int cablePoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private GameObject[] cablePoints = new GameObject[12];
    [SerializeField] private GameObject[] bottomPoints = new GameObject[12];

    void Start() {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
        //cablePoint = Random.Range(0, 12);
        Debug.Log(cablePoint);
    }

    void Update() {
        if (!rb.useGravity) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (isGrounded) {
            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BottomPoint")) {
            isGrounded = true;
        }

        if (other.gameObject == cablePoints[cablePoint]) {
            rb.useGravity = true;
            transform.position = other.gameObject.transform.position;
        }
    }
}