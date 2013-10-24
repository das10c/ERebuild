using UnityEngine;
using System.Collections;

public class Quake : MonoBehaviour {
	
	bool quake = false;
	
	void OnGUI (){
      if (GUI.Button (new Rect(10,35,200,20), "Earthquake")){
		quake= !quake;
		}
	}
	
    void OnCollisionStay(Collision collisionInfo) {
		
		if(quake){
				Debug.Log(collisionInfo.collider.rigidbody.name);
            	collisionInfo.collider.rigidbody.AddForce(Vector3.up*50);
        	}
	
	}
}
