using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {
    private Rigidbody rb;
    private BoxCollider boxCollider;
    private SphereCollider sphereCollider;
    [SerializeField] private int cablePointIndex;
    [SerializeField] private float speed;

    void Start() {
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        cablePointIndex = Random.Range(0, 12);
        Debug.Log(cablePointIndex);
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
            // rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }

        if (other.gameObject == CablePointManager.Instance.GetCablePoints()[cablePointIndex]) {
            rb.useGravity = true;
            transform.position = other.gameObject.transform.position;
        }
    }


    public void SetSpeed(float speed) {
        this.speed = speed;
    }
}