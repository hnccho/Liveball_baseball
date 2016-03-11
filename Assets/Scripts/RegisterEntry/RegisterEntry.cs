using UnityEngine;
using System.Collections;

public class RegisterEntry : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitRegisterEntry(){

		for(int i = 0; i < transform.FindChild("Ground").FindChild("BtnPosition").childCount; i++){
			transform.FindChild("Ground").FindChild("BtnPosition")
				.GetChild(i).FindChild("Designated").gameObject.SetActive(false);
		}

	}
}
