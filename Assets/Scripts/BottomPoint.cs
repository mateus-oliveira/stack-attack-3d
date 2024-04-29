using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPoint : MonoBehaviour {
    private BoxCollider boxCollider;

    private void OnDrawGizmos() {
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Cube")) {
            other.gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                0.5f,
                -3.77f
            );
            BottomCubesManager.Instance.AddCube(other.gameObject);
        }
    }
}