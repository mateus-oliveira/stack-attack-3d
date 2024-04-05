using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablePoint : MonoBehaviour
{
    private BoxCollider boxCollider;

    private void OnDrawGizmos()
    {
        if (boxCollider == null)
            boxCollider = GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.size);
        }
    }
}