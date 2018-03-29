using UnityEngine;
using System.Collections;

public class Notice : MonoBehaviour {

	NoticeEvent mNoticeEvent;
	int mPage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mPage = 1;
		mNoticeEvent = new NoticeEvent(ReceivedNotice);
		NetMgr.GetNotice(mNoticeEvent);
	}
	
	void ReceivedNotice(){
		int cnt = mNoticeEvent.Response.data.Count;
		if(cnt < 1) return;
		
		transform.root.FindChild("Notice").gameObject.SetActive(true);
		Set(mPage-1);
	}

	void Set(int cnt){
		Transform box = transform.root.FindChild("Notice").FindChild("Box");
		
		box.FindChild("SprTop").FindChild("LblTitle").GetComponent<UILabel>().text
			= mNoticeEvent.Response.data[cnt].title;

		box.FindChild("SprBtm").FindChild("LblCenter").GetComponent<UILabel>().text
			= mPage + "[999999] / " + mNoticeEvent.Response.data.Count;
		
		if(mNoticeEvent.Response.data[cnt].attached != null
		   && mNoticeEvent.Response.data[cnt].attached.Length > 6){
			box.FindChild("BtnBody").FindChild("Label").gameObject.SetActive(false);
			box.FindChild("BtnBody").FindChild("Texture").gameObject.SetActive(true);
			StartCoroutine(SetNoticeImg(mNoticeEvent.Response.data[cnt].attached));
		} else{
			box.FindChild("BtnBody").FindChild("Label").gameObject.SetActive(true);
			box.FindChild("BtnBody").FindChild("Texture").gameObject.SetActive(false);
			box.FindChild("BtnBody").FindChild("Label").GetComponent<UILabel>().text
				= mNoticeEvent.Response.data[cnt].announce;
		}
	}

	public void NextClick(){
		if(mPage >= mNoticeEvent.Response.data.Count) return;
		++mPage;
		Set (mPage-1);

	}

	public void PrevClick(){
		if(mPage <= 1) return;
		--mPage;
		Set (mPage-1);
	}

	public void CloseClick(){
		gameObject.SetActive(false);
		transform.root.FindChild("Lobby").GetComponent<Lobby>().CheckAttendance();
	}

	public void BodyClick(){
		if(mNoticeEvent.Response.data[mPage-1].url != null
		   && mNoticeEvent.Response.data[mPage-1].url.Length > 6){
			Application.OpenURL(mNoticeEvent.Response.data[mPage-1].url);
		}
	}
	
	IEnumerator SetNoticeImg(string url){
		WWW www = new WWW(url);
		yield return www;
		if(www.error == null && www.isDone){
			Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
			www.LoadImageIntoTexture(temp);
			transform.FindChild("Box").FindChild("BtnBody").FindChild("Texture").GetComponent<UITexture>()
				.mainTexture = temp;
			
			www.Dispose();
		}
	}
}
