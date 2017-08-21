using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(VRTK_HeadsetCollision))]
public class HeadsetCollision : MonoBehaviour {

    [Tooltip("The VRTK Headset Collision script to use when determining headset collisions. If this is left blank then the script will need to be applied to the same GameObject.")]
    public VRTK_HeadsetCollision headsetCollision;

    private PlayerController playerController;

	// Use this for initialization
	void Start () {
        playerController = GameObject.Find("VRTKScripts").GetComponent<PlayerController>();
	}

    protected virtual void OnEnable() {
        headsetCollision = (headsetCollision != null ? headsetCollision : GetComponentInChildren<VRTK_HeadsetCollision>());

        headsetCollision.HeadsetCollisionDetect += new HeadsetCollisionEventHandler(OnHeadsetCollisionDetect);
        headsetCollision.HeadsetCollisionEnded += new HeadsetCollisionEventHandler(OnHeadsetCollisionEnded);
    }

    protected virtual void OnDisable() {
        headsetCollision.HeadsetCollisionDetect -= new HeadsetCollisionEventHandler(OnHeadsetCollisionDetect);
        headsetCollision.HeadsetCollisionEnded -= new HeadsetCollisionEventHandler(OnHeadsetCollisionEnded);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void HandlGoalHit() {
        playerController.IncreaseCheckpoint();
        HandleResetHit();
    }

    private void HandleResetHit() {

        // get start object
        GameObject startObject = GameObject.Find(playerController.GetCurrentCheckpoint());
        Debug.Log(playerController.GetCurrentCheckpoint());

        // get start location
        Vector3 startLocation = startObject.transform.position;

        // teleport to start location
        //playAreaTransform.position = startLocation;
        VRTK_BasicTeleport basicTPScript = this.GetComponent<VRTK_BasicTeleport>();
        basicTPScript.ForceTeleport(startLocation);

    }

    protected virtual void OnHeadsetCollisionDetect(object sender, HeadsetCollisionEventArgs e) {
        // get name of object collided with
        GameObject collidedObject = e.collider.gameObject;

        switch(collidedObject.name) {
        case "Reset":
            HandleResetHit();
            break;
        case "Goal":
            HandleResetHit();
            break;
        default:
            break;
        }
    }

    protected virtual void OnHeadsetCollisionEnded(object sender, HeadsetCollisionEventArgs e) {
        
    }
}
