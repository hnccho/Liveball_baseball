using UnityEngine;
using System.Collections;

public class BingoResult : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Result(){
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().Reload();
	}

	public void Bingo(){
		transform.FindChild("Label").gameObject.SetActive(false);
		transform.FindChild("SprTxt").gameObject.SetActive(true);
		transform.FindChild("SprTxt").GetComponent<UISprite>().width = 269;
		transform.FindChild("SprTxt").GetComponent<UISprite>().height = 69;
		transform.FindChild("SprTxt").GetComponent<UISprite>().spriteName = "rt_bingo_txt_bingo";
		transform.GetComponent<Animator>().SetTrigger("Result");
	}

	public void Correct(){
		transform.FindChild("Label").gameObject.SetActive(false);
		transform.FindChild("SprTxt").gameObject.SetActive(true);
		transform.FindChild("SprTxt").GetComponent<UISprite>().width = 215;
		transform.FindChild("SprTxt").GetComponent<UISprite>().height = 56;
		transform.FindChild("SprTxt").GetComponent<UISprite>().spriteName = "rt_bingo_txt_great";
		transform.GetComponent<Animator>().SetTrigger("Result");
	}

	public void PowerTime(){
		transform.FindChild("Label").gameObject.SetActive(false);
		transform.FindChild("SprTxt").gameObject.SetActive(true);
		transform.FindChild("SprTxt").GetComponent<UISprite>().width = 370;
		transform.FindChild("SprTxt").GetComponent<UISprite>().height = 54;
		transform.FindChild("SprTxt").GetComponent<UISprite>().spriteName = "rt_bingo_txt_powertime";
		transform.GetComponent<Animator>().SetTrigger("Result");
	}

	public void SocketResult(SocketMsgInfo info){
		transform.FindChild("Label").gameObject.SetActive(true);
		transform.FindChild("SprTxt").gameObject.SetActive(false);
		if(info.data.value > 0){ //Out
			transform.FindChild("Label").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrOut")+"!";
		} else{
			transform.FindChild("Label").GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrGetOnBase")+"!";
		}

		if(transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.inningHalf.Equals("T")){
			foreach(PlayerInfo player in 
			        transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.away.hit){
//				Debug.Log("T info id : "+info.playerId+", player id : "+player.playerId);
				if(player.playerId == info.data.playerId){
					transform.FindChild("Label").FindChild("LblPlayer").GetComponent<UILabel>().text
						= Localization.language.Equals("English") ? player.playerName : player.korName;
					break;
				}
			}
		} else{
			foreach(PlayerInfo player in 
			        transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().mLineupEvent.Response.data.home.hit){
//				Debug.Log("B info id : "+info.playerId+", player id : "+player.playerId);
				if(player.playerId == info.data.playerId){
					transform.FindChild("Label").FindChild("LblPlayer").GetComponent<UILabel>().text
						= Localization.language.Equals("English") ? player.playerName : player.korName;
					break;
				}
			}
		}

		transform.GetComponent<Animator>().SetTrigger("Result");
	}
}
