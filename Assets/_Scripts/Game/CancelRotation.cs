using UnityEngine;
using System.Collections;

public class CancelRotation : MonoBehaviour {

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - transform.parent.position;
    }
	// Update is called once per frame
	void Update() {
        transform.position = transform.parent.position+offset;
        transform.rotation = Quaternion.identity;
	}
}
