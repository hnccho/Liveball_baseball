using UnityEngine;
using System.Collections;

public class ItemBingo : MonoBehaviour {

//	public Color BGColor = Color.white;
	public BingoInfo.BingoBoard mBingoBoard;
	public bool IsCorrected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsCorrected){
			transform.FindChild("Background").GetComponent<UISprite>().color = new Color(28f/255f, 150f/255f, 212f/255f);
			transform.GetComponent<UIButton>().defaultColor = new Color(28f/255f, 150f/255f, 212f/255f);
			transform.GetComponent<UIButton>().hover = new Color(28f/255f, 150f/255f, 212f/255f);
			transform.GetComponent<UIButton>().pressed = new Color(28f/255f, 150f/255f, 212f/255f);
			if(mBingoBoard.playerId > 0){
				transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
			} else{
				transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
			}
		}

	}

	public void Init(){
		if(mBingoBoard.playerId > 0){
			SetTilePlayer();
		} else{
			SetTileTeam();
		}

//		if(mBingoBoard.photoUrl.Equals("Y")){
//			SetCorrected();
//		}
	}

	void SetTilePlayer(){
		transform.FindChild("Player").gameObject.SetActive(true);
		transform.FindChild("Team").gameObject.SetActive(false);

		transform.FindChild("Player").FindChild("LblName").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.playerName : mBingoBoard.playerKorName;


		UtilMgr.LoadImage(mBingoBoard.photoUrl,
		                  transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
	}

	void SetTileTeam(){
		transform.FindChild("Player").gameObject.SetActive(false);
		transform.FindChild("Team").gameObject.SetActive(true);

		if(!UtilMgr.IsMLB()){
			transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().width = 74;
			transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().height = 60;
		}
		transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().spriteName = mBingoBoard.teamId+"";
		transform.FindChild("Team").FindChild("LblName").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.teamName : mBingoBoard.teamName;
		transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().text
			= mBingoBoard.quizCondition;
	}

	public void Correct(){
		transform.GetComponent<Animator>().SetTrigger("Correct");
		Debug.Log("Correct");
	}

	public void SetCorrected(){
		IsCorrected = true;
	}

	public void BlastStar(){
		transform.FindChild("StarBlueBlast").gameObject.SetActive(true);
		transform.FindChild("StarBlueBlast").GetComponent<ParticleSystem>().Play();
	}

	public void CorrectFinish(){
		transform.GetComponent<Animator>().SetTrigger("Idle");
		transform.FindChild("StarBlueBlast").gameObject.SetActive(false);
//		transform.localScale = new Vector3(1f, 1f, 1f);
	}

	public void OnClick(){
		IsCorrected = false;
		Correct ();
	}


}
