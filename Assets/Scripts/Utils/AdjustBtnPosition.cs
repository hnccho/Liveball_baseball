using UnityEngine;
using System.Collections;

public class AdjustBtnPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		UIButton btn = GetComponent<UIButton>();
//		if(btn != null){
			Vector3 pos = transform.localPosition;
			pos.y += UtilMgr.GetScaledPositionY()*2;
			transform.localPosition = pos;
//		}
	}
}
