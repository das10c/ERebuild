using UnityEngine;
using System.Collections;

public class StamBar : MonoBehaviour {
	
	public float currStam = 100;
	private float maxStam = 100;
	private float stamBarLength;
	GUIStyle style = new GUIStyle();
	public float mass = 0f;
	GameObject heldObj;
	
	// Use this for initialization
	void Start () {
		stamBarLength = Screen.width/2;

		Texture2D texture = new Texture2D(1, 1);
		Color color = new Color(.1f, .8f, .3f);
        texture.SetPixel(1, 1, color);
		texture.Apply();
		style.normal.background = texture;
		style.alignment = TextAnchor.MiddleCenter;
	}
	
	// Update is called once per frame
	void Update () {
		if (currStam <= 0 && mass > 0)
			FPSInputController.stopped = true;
		else
			FPSInputController.stopped = false;
		if((Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))){
			AdjCurrStam(-.05f*getMass());
		}
		else
			AdjCurrStam(0f);
		if(Input.GetButtonUp("grab"))
			getMass();
		if(Input.GetButton("sleep"))
			currStam = maxStam;
		}
	
	void OnGUI(){
		GUI.TextArea(new Rect(10, 10, 55, 20), "Stamina");
		GUI.Box(new Rect(80, 10, stamBarLength, 20), " ",style);
	}
	
	public void AdjCurrStam (float adj) {
   		currStam += adj;
   		if(currStam < 0)
        	currStam = 0;
   		if(currStam > maxStam)
        	currStam = maxStam;
   		if(maxStam < 1)
        	maxStam = 1;
   		stamBarLength = (Screen.width / 2) * (currStam / (float)maxStam);
	}
	
	public float getMass(){
		heldObj = GameObject.FindGameObjectWithTag("held");
		if (heldObj != null)
			mass = heldObj.rigidbody.mass;
		else
			mass = 0f;
		return mass;
	}
		
}
