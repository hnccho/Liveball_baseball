using UnityEngine;
using System.Collections;

public class BtnRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		UISprite sprite = transform.FindChild("Sprite").GetComponent<UISprite>();
		sprite.color = new Color(1f, 1f, 1f, 1f);
		sprite.transform.localPosition = new Vector3(-66f, -4f, 0f);

		UILabel label = transform.FindChild("LblRandom").GetComponent<UILabel>();
		label.transform.localPosition = new Vector3(-40f, -4f, 0f);

		sprite = transform.FindChild("Background").GetComponent<UISprite>();
		sprite.flip = UIBasicSprite.Flip.Both;

		StartCoroutine("BtnAnim");

//		DialogueMgr.ShowDialogue("title", "a\ndkdkdjfkdjfkd\nkdkdkdkdkd\ndkdkdkdk\nd\nddd\nddd\nd", DialogueMgr.DIALOGUE_TYPE.Alert, "", "", "Confirm", null);

//		DialogueMgr.ShowExitDialogue(null);
	}

	IEnumerator BtnAnim()
	{
		yield return new WaitForSeconds(0.5f);

		UISprite sprite = transform.FindChild("Sprite").GetComponent<UISprite>();
		sprite.color = new Color(1f, 1f, 1f, 150f/255f);
		sprite.transform.localPosition = new Vector3(-66f, 0f, 0f);
		
		UILabel label = transform.FindChild("LblRandom").GetComponent<UILabel>();
		label.transform.localPosition = new Vector3(-40f, 0f, 0f);
		
		sprite = transform.FindChild("Background").GetComponent<UISprite>();
		sprite.flip = UIBasicSprite.Flip.Horizontally;

		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().Randomize();
	}
}
