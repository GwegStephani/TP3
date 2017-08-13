using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vine : MonoBehaviour {

    public float angle;
    public float speed;
    public Vector3 direction;

    private Quaternion qStart;
    private Quaternion qEnd;

	// Use this for initialization
	void Start () {
        qStart = Quaternion.AngleAxis(angle, direction);
        qEnd = Quaternion.AngleAxis(-angle, direction);
	}

	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Lerp(qStart, qEnd, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
	}
}
