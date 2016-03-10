using UnityEngine;
using System.Collections;

public class AdjustBtmPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
			Vector3 pos = transform.localPosition;
			pos.y += UtilMgr.GetScaledPositionY()*2;
			transform.localPosition = pos;
	}
}
