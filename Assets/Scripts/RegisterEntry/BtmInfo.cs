using UnityEngine;
using System.Collections;

public class BtmInfo : MonoBehaviour {

	long mTotal;
	const long MaxSalary = 35000l;
	int mCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetBtmInfo(Transform scrollView){
		mCount = 0;
		long avg = 0;
		mTotal = 0;
		for(int i = 0; i < scrollView.childCount; i++){
			ItemPosition item = scrollView.GetChild(i).GetComponent<ItemPosition>();
			if((item.GetPlayerInfo() != null) && (item.mState == BtnPosition.STATE.Designated)){
				mCount++;
				mTotal += item.GetPlayerInfo().salary;
			}
		}
		if(mCount > 0)
			avg = mTotal / mCount;
		else
			avg = mTotal;

		transform.FindChild("Labels").FindChild("LblSmall").GetComponent<UILabel>().text
			= string.Format(UtilMgr.GetLocalText("LblRegEntryInfo"),
			                UtilMgr.AddsThousandsSeparator(avg+""), mCount);
		transform.FindChild("Labels").FindChild("LblBig").GetComponent<UILabel>().text
			= "$" + UtilMgr.AddsThousandsSeparator(mTotal+"") + " [999999]of $35,000";
	}

	public bool CheckSalary(){
		if(mTotal <= MaxSalary)
			return true;

		return false;
	}

	public bool CheckFull(){
		if(mCount == 9)
			return true;
		
		return false;
	}
}
