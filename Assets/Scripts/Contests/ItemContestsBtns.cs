using UnityEngine;
using System.Collections;

public class ItemContestsBtns : MonoBehaviour {

//	int mContestSeq;
	ContestListInfo mContestInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetContestSeq(ContestListInfo contestInfo){
//		mContestSeq = contestSeq;
		mContestInfo = contestInfo;
	}

	public void OnClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.RegisterEntry);
		UtilMgr.AnimatePageToLeft("Contests", "RegisterEntry");
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().InitRegisterEntry(mContestInfo);
	}
}
