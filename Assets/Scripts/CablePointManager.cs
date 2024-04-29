using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CablePointManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cablePoints = new GameObject[12];

    private static CablePointManager _instance;

    public static CablePointManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<CablePointManager>();

                if (_instance == null) {
                    GameObject singletonObject = new GameObject("CablePointManager");
                    _instance = singletonObject.AddComponent<CablePointManager>();
                }
            }

            return _instance;
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


    public GameObject[] GetCablePoints(){
        return cablePoints;
    }
}