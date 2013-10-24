using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {
	public float grabDistance=2f;
	RaycastHit hit;
	GameObject hitObject;
	IsCovered blocked;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("grab")){
			if(hitObject!=null)
				drop ();
			else if(Physics.Raycast(transform.position,transform.forward,out hit,grabDistance)){
				if(hit.collider.gameObject.tag=="moveable")
					grab ();	
			}
		}
		if (hitObject!=null){
			if (Input.GetButtonDown("rotateR"))
				hitObject.transform.Rotate(Vector3.up, 45f);
			if (Input.GetButtonDown("rotateL"))
				hitObject.transform.Rotate(Vector3.up, -45f);
			if (Input.GetButtonDown("topDrop")){
				if(blocked.blocked)
					hitObject.transform.localPosition += Vector3.up;
				else
					drop();
			}
			if (Input.GetButtonDown("backDrop")){
				if(blocked.blocked)
					hitObject.transform.localPosition += Vector3.forward;
				else 
					drop();
					
			}
		}
	}
	
	void drop(){
		if (!blocked.blocked){
			hitObject.rigidbody.isKinematic = false;
			hitObject.renderer.material.color += new Color(0,0,0,.5f);
			hitObject.collider.isTrigger = false;
			hitObject.transform.parent=null; //drop the object
			hitObject.tag = "moveable";
			hitObject=null;  //and nullify the object pointed
		}
	}
	
	void grab(){
		hitObject = hit.collider.gameObject;
		blocked = hitObject.GetComponent<IsCovered>();
		hitObject.transform.parent = transform;
		hitObject.transform.localPosition += Vector3.up;
		hitObject.tag = "held";
		hitObject.renderer.material.color -= new Color(0,0,0,.5f);
		hitObject.rigidbody.isKinematic = true;
		hitObject.collider.isTrigger = true;
	}
}
