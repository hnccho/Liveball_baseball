using UnityEngine;
using System.Collections;

public class BtnEditNick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.root.FindChild("Settings").FindChild("Body").FindChild("Rename").gameObject.SetActive(true);
	}
}
