using UnityEngine;
using System.Collections;

public class BtmInfo : MonoBehaviour {

	long mTotal;
//	public static int MaxSalary = 35000;
	int mCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SetBtmInfo(Transform scrollView){
		float listSize = scrollView.GetComponent<UIPanel>().height;
//		Debug.Log("listSize is "+listSize);
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
		int salaryLimit = transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.salaryLimit;

		transform.FindChild("Labels").FindChild("LblSmall").GetComponent<UILabel>().text
			= string.Format(UtilMgr.GetLocalText("LblRegEntryInfo"),
			                UtilMgr.AddsThousandsSeparator(avg+""), mCount);
		transform.FindChild("Labels").FindChild("LblBig").GetComponent<UILabel>().text
			= "$" + UtilMgr.AddsThousandsSeparator(mTotal+"") + " [999999]of $"
				+ UtilMgr.AddsThousandsSeparator(salaryLimit);

		transform.localPosition = new Vector3(0, (-202f -listSize));
	}

	public bool CheckSalary(){
		if(mTotal <= transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.salaryLimit)
			return true;

		return false;
	}

	public bool CheckFull(){
		if(mCount == 9)
			return true;
		
		return false;
	}
}
