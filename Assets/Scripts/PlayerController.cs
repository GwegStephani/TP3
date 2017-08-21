using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    private int currentCheckpointNumber = 2;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate() {
    }

    public string GetCurrentCheckpoint() {
        return "checkpoint" + currentCheckpointNumber.ToString();
    }

    public void IncreaseCheckpoint() {
        currentCheckpointNumber++;
    }
}
