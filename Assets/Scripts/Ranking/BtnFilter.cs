using UnityEngine;
using System.Collections;

public class BtnFilter : MonoBehaviour {

	public bool IsOpen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Unfold(){
		transform.parent.FindChild("SprTri").gameObject.SetActive(true);
		IsOpen = true;
		TweenPosition.Begin(transform.parent.FindChild("Selection").gameObject ,0.5f, new Vector3(0, 0), false);
	}

	public void Fold(){
		transform.parent.FindChild("SprTri").gameObject.SetActive(false);
		IsOpen = false;
		TweenPosition.Begin(transform.parent.FindChild("Selection").gameObject ,0.5f, new Vector3(0, 400f), false);
	}

	public void OnClick(){
		if(IsOpen){
			Fold ();
		} else{
			Unfold();
		}
	}
}
