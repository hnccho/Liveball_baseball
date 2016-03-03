using UnityEngine;
using System.Collections;

public class LoginRoot : SuperRoot {

	// Use this for initialization
	void Start () {
		base.Start();
		transform.FindChild("Terms").gameObject.SetActive(false);
		transform.FindChild("RegisterUsername").gameObject.SetActive(false);
		transform.FindChild("Terms").gameObject.SetActive(true);

		transform.FindChild("RegisterUsername").localPosition
			= new Vector3(0f, UtilMgr.GetScaledPositionY ());

		if(UtilMgr.IsMLB())
			transform.FindChild("SprTitle").GetComponent<UISprite>().spriteName = "logo_title1";
	}

	void Awake(){
		base.Awake();
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
	}
}
