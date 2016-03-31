using UnityEngine;
using System.Collections;

public class ProfileBtns : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(name.Equals("BtnSettings")){
			transform.root.FindChild("Settings").GetComponent<Settings>().Init();
		}
	}
}
