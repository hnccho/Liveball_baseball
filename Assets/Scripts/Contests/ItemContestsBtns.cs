using UnityEngine;
using System.Collections;

public class ItemContestsBtns : MonoBehaviour {

	int mContestSeq;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetContestSeq(int contestSeq){
		mContestSeq = contestSeq;
	}

	public void OnClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.RegisterEntry);
		UtilMgr.AnimatePageToLeft("Contests", "RegisterEntry");
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().InitRegisterEntry(mContestSeq);
	}
}
