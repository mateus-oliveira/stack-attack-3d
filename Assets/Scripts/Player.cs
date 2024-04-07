using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody rb;
    [SerializeField] private float maxDistance;
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask layerMask;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        // Horizontal move
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Jump
        if(Input.GetKeyDown(KeyCode.UpArrow) && this.GroundCheck()) {
            rb.AddForce(transform.up*jumpForce, ForceMode.Impulse);
        } 
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*maxDistance, boxSize);
    }

    bool GroundCheck() {
        return Physics.BoxCast(
            transform.position,
            boxSize,
            -transform.up,
            transform.rotation,
            maxDistance,
            layerMask
        );
    }
}
