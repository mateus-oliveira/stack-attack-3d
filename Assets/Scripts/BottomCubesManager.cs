using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCubesManager : MonoBehaviour {
    //[SerializeField] private GameObject[] cubes = new GameObject[12];
    [SerializeField] private HashSet<GameObject> cubes = new HashSet<GameObject>();

    private static BottomCubesManager _instance;

    public static BottomCubesManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<BottomCubesManager>();

                if (_instance == null) {
                    GameObject singletonObject = new GameObject("BottomCubesManager");
                    _instance = singletonObject.AddComponent<BottomCubesManager>();
                }
            }

            return _instance;
        }
    }

    public void AddCube(GameObject obj) {
        cubes.Add(obj);
        if (cubes.Count == 12) {
            foreach (GameObject go in cubes) {
                Destroy(go);
            }
        }

        foreach (GameObject go in cubes) {
            Debug.Log(go.name + " Count: " + cubes.Count);
        }
    }

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}
