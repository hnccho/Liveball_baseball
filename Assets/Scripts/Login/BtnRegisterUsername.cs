using UnityEngine;
using System.Collections;

public class BtnRegisterUsername : MonoBehaviour {

//	LoginEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		DialogueMgr.ShowDialogue("title", "body", DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}
}
