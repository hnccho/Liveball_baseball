using UnityEngine;
using System.Collections;

public class RTDirectionBtns : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		transform.parent.parent.parent.GetComponent<UICenterOnChild>().enabled = true;
//		transform.parent.parent.parent.GetComponent<UICenterOnChild>().onFinished = OnFinished;
		if(name.Equals("BtnLeft")){
			Vector3 ori = transform.parent.parent.parent.localPosition;
			transform.parent.parent.parent.localPosition = new Vector3(ori.x + 720f, ori.y, ori.z);
			Vector2 offset = transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset;
			transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset = new Vector2(offset.x - 720f, offset.y);
		} else if(name.Equals("BtnRight")){
			Vector3 ori = transform.parent.parent.parent.localPosition;
			transform.parent.parent.parent.localPosition = new Vector3(ori.x - 720f, ori.y, ori.z);
			Vector2 offset = transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset;
			transform.parent.parent.parent.GetComponent<UIPanel>().clipOffset = new Vector2(offset.x + 720f, offset.y);
		}
		transform.parent.parent.parent.GetComponent<UICenterOnChild>().Recenter();
	}

	void OnFinished(){
//		transform.parent.parent.parent.GetComponent<UICenterOnChild>().enabled = false;
	}
}
