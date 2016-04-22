using UnityEngine;
using System.Collections;

public class ItemBingo : MonoBehaviour {

//	public Color BGColor = Color.white;
	public BingoInfo.BingoBoard mBingoBoard;
	public BingoInfo.BingoBoard mNewBingoBoard;
	public bool IsCorrected;
	public bool IsAnimate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//		if(IsCorrected && !IsAnimate){
//			transform.FindChild("Background").GetComponent<UISprite>().color = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().defaultColor = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().hover = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().pressed = new Color(28f/255f, 150f/255f, 212f/255f);
//			if(mBingoBoard.playerId > 0){
//				transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
//			} else{
//				transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
//			}
//		}

	}

	public void Init(bool isReload){
		if(mNewBingoBoard.successYn.Equals("Y")){
			if(isReload && mBingoBoard.successYn.Equals("N")){
				mBingoBoard = mNewBingoBoard;
				Correct();
			} else{
				mBingoBoard = mNewBingoBoard;
				SetCorrected();
			}
		}
		mBingoBoard = mNewBingoBoard;
		if(mBingoBoard.playerId > 0){
			SetTilePlayer();
		} else{
			SetTileTeam();
		}

		if(mBingoBoard.walkYn.Equals("Y"))
			SetGuess(0);
		if(mBingoBoard.outYn.Equals("Y"))
			SetGuess(1);
	}

	void SetTilePlayer(){
		transform.FindChild("Player").gameObject.SetActive(true);
		transform.FindChild("Team").gameObject.SetActive(false);

		transform.FindChild("Player").FindChild("LblName").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.playerName : mBingoBoard.playerKorName;

		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 72;
		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 90;
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
			= Localization.language.Equals("English") ? mBingoBoard.teamName : mBingoBoard.teamKorName;
		transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().text
			= mBingoBoard.quizCondition;
	}

	public void Bingo(){
		transform.GetComponent<Animator>().SetTrigger("Bingo");
	}

	public void BingoFinish(){

	}

	public void Correct(){
		transform.GetComponent<Animator>().SetTrigger("Correct");
		transform.parent.parent.FindChild("Result").GetComponent<BingoResult>().Correct();
	}

	public void SetCorrected(){
		IsCorrected = true;
		transform.FindChild("Background").GetComponent<UISprite>().color = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().defaultColor = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().hover = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().pressed = new Color(28f/255f, 150f/255f, 212f/255f);
		if(mBingoBoard.playerId > 0){
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
		} else{
			transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
		}
	}

	public void SetGuess(int checkValue){
		if(checkValue == 0)
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrGetOnBase");
		else
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrOut");
	}

	public void BlastStar(){
		transform.FindChild("StarBlueBlast").gameObject.SetActive(true);
		transform.FindChild("StarBlueBlast").GetComponent<ParticleSystem>().Play();
	}

	public void BlastCoin(){
		transform.FindChild("CoinBlastCopper").gameObject.SetActive(true);
		transform.FindChild("CoinBlastCopper").GetComponent<ParticleSystem>().Play();
	}

	public void CorrectFinish(){
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().CheckBingo();
	}

	public void OnClick(){
//		IsCorrected = false;
//		Correct ();
//		transform.parent.parent.FindChild("Result").GetComponent<Animator>().SetTrigger("Result");
//		SetCorrected();
//		CorrectFinish();
	}




}
