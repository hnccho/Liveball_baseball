using UnityEngine;
using System.Collections;

public class AdjustListSize : MonoBehaviour {

	public bool DontResetPosition;

	// Use this for initialization
	void Start () {
		UIScrollView scrollView = GetComponent<UIScrollView>();

		if(scrollView != null){
			UtilMgr.ResizeList(gameObject);
			if(!DontResetPosition)
				scrollView.ResetPosition();
		}
	}
}
