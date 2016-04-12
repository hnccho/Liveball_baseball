using UnityEngine;
using System.Collections;

public class Profile : MonoBehaviour {

	GetProfileEvent mProfileEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(GetProfileEvent profileEvent){
		mProfileEvent = profileEvent;

		Transform infoTop = transform.FindChild("Scroll View").FindChild("InfoTop");
		if((mProfileEvent.Response.data.imageName != null)
		   && (mProfileEvent.Response.data.imageName.Length > 0))
			Debug.Log("Image is "+mProfileEvent.Response.data.imageName);


		infoTop.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text
			= mProfileEvent.Response.data.nick;

		infoTop.FindChild("LblAccountBalance").FindChild("Label").GetComponent<UILabel>().text
			= UtilMgr.AddsThousandsSeparator(mProfileEvent.Response.data.gold+"");
		infoTop.FindChild("LblAccountBalance").FindChild("Label").FindChild("Sprite").localPosition
			= new Vector3(-(infoTop.FindChild("LblAccountBalance").FindChild("Label").GetComponent<UILabel>().width+5),0);

		infoTop.FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().text
			= UtilMgr.AddsThousandsSeparator(mProfileEvent.Response.data.ticket+"");
		infoTop.FindChild("LblTickets").FindChild("Label").FindChild("Sprite").localPosition
			= new Vector3(-(infoTop.FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().width+5),0);

		infoTop.FindChild("LblRankingPoint").FindChild("Label").GetComponent<UILabel>().text
			= UtilMgr.AddsThousandsSeparator(mProfileEvent.Response.data.rankPoint+"");
		infoTop.FindChild("LblRankingPoint").FindChild("Label").FindChild("Label").localPosition
			= new Vector3(-(infoTop.FindChild("LblRankingPoint").FindChild("Label").GetComponent<UILabel>().width+10),0);

		UtilMgr.LoadUserImage(mProfileEvent.Response.data.photoUrl, infoTop.FindChild("Frame").FindChild("Photo")
		                      .FindChild("Texture").GetComponent<UITexture>());
		
	}
}
