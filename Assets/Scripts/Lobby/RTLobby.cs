using UnityEngine;
using System.Collections;

public class RTLobby : MonoBehaviour {

	GetEventsEvent mRTEvent;
	public GameObject mItemRT;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		mRTEvent = new GetEventsEvent(ReceivedRT);
		NetMgr.GetEvents(mRTEvent);
	}

	void ReceivedRT(){
		float width = 720f;
		for(int i = 0; i < mRTEvent.Response.data.Count; i++){
			Transform item = Instantiate(mItemRT).transform;
			item.parent = transform.FindChild("ScrollRT").transform;
			item.localPosition = new Vector3(width * i, 1f, 1f);
			item.localScale = new Vector3(1f, 1f, 1f);
			EventInfo data = mRTEvent.Response.data[i];

			item.FindChild("Top").FindChild("LblStadium").GetComponent<UILabel>().text = data.stadiumName;

			item.FindChild("Score").FindChild("Left").FindChild("LblScore").GetComponent<UILabel>().text
				= data.awayTeamRuns+"";
			item.FindChild("Score").FindChild("Right").FindChild("LblScore").GetComponent<UILabel>().text
				= data.homeTeamRuns+"";
			item.FindChild("Score").FindChild("Left").FindChild("LblTeam").GetComponent<UILabel>().text
				= data.awayTeam;
			item.FindChild("Score").FindChild("Right").FindChild("LblTeam").GetComponent<UILabel>().text
				= data.homeTeam;
			item.FindChild("Score").FindChild("Left").FindChild("SprEmblem").GetComponent<UISprite>().spriteName
				= data.awayTeamId+"";
			item.FindChild("Score").FindChild("Right").FindChild("SprEmblem").GetComponent<UISprite>().spriteName
				= data.homeTeamId+"";

			if(data.inningHalf.Equals("T")){
				item.FindChild("Score").FindChild("Left").FindChild("SprStar").gameObject.SetActive(true);
				item.FindChild("Score").FindChild("Right").FindChild("SprStar").gameObject.SetActive(false);

				item.FindChild("Players").GetComponent<UILabel>().text
					= "Top " + data.inning + UtilMgr.GetRoundString(data.inning);

				StartCoroutine(loadImage(data.hitterPhoto, item.FindChild("Players").FindChild("Left")
            				             .FindChild("Frame").FindChild("Photo").FindChild("TxtPlayer")));
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "B";
				StartCoroutine(loadImage(data.pitcherPhoto, item.FindChild("Players").FindChild("Right")
				                         .FindChild("Frame").FindChild("Photo").FindChild("TxtPlayer")));
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "P";

				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.hitterName;
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.pitcherName;
			} else{
				item.FindChild("Score").FindChild("Right").FindChild("SprStar").gameObject.SetActive(true);
				item.FindChild("Score").FindChild("Left").FindChild("SprStar").gameObject.SetActive(false);

				item.FindChild("Players").GetComponent<UILabel>().text
					= "Bottom " + data.inning + UtilMgr.GetRoundString(data.inning);

				StartCoroutine(loadImage(data.hitterPhoto, item.FindChild("Players").FindChild("Right")
				                         .FindChild("Frame").FindChild("Photo").FindChild("TxtPlayer")));
				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "B";
				StartCoroutine(loadImage(data.pitcherPhoto, item.FindChild("Players").FindChild("Left")
				                         .FindChild("Frame").FindChild("Photo").FindChild("TxtPlayer")));
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("SprPos").FindChild("Label").GetComponent<UILabel>().text = "P";

				item.FindChild("Players").FindChild("Right")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.hitterName;
				item.FindChild("Players").FindChild("Left")
					.FindChild("Frame").FindChild("Label").GetComponent<UILabel>().text = data.pitcherName;
			}
		}
		transform.FindChild("ScrollRT").GetComponent<UIScrollView>().ResetPosition();
	}

	IEnumerator loadImage(string url, Transform tf){
		WWW www = new WWW(url);
		yield return www;

		Texture2D texture = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
		www.LoadImageIntoTexture(texture);
		tf.GetComponent<UITexture>().mainTexture = texture;
		tf.GetComponent<UITexture>().color = Color.white;
	}
}
