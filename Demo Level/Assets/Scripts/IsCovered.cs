using UnityEngine;
using System.Collections;

public class IsCovered : MonoBehaviour {
	
	public int numInZone = 0;
	public bool blocked = false;
	
	void OnTriggerEnter(Collider other){
		if(!other.CompareTag("Player")){
			numInZone++;
			blocked = true;
		}
	}
	void Update(){
		if ((rigidbody != null) && rigidbody.IsSleeping()) 
       		rigidbody.WakeUp();
	}
	void OnTriggerExit(Collider other){
		if(!other.CompareTag("Player")){
			numInZone--;
			if (numInZone <= 1)
				blocked = false;
		}
	}
}
