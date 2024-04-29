using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour {

    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("SpawnCubePrefab", 0f, 5f);
    }

    // Update is called once per frame
    void Update() {
        
    }


    private void SpawnCubePrefab() {
        GameObject instance = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);

        Cube cube = instance.GetComponent<Cube>();
        if (cube != null) {
            cube.SetSpeed(speed);
        }
    }


    void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(spawnPosition, new Vector3(1f, 1f, 1f));
    }
}
