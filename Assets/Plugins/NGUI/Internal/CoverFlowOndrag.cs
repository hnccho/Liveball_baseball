using UnityEngine;
using System.Collections;

public class CoverFlowOndrag : MonoBehaviour {
	public Vector2 DefaultSize;
	public Vector2 MaxSize;
	public Vector2 Size;
	public float Gap;
	public float BenchmarkSize;
	// Use this for initialization

	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "item") {
//			Debug.Log("ss : " + (Mathf.Abs(other.transform.parent.position.x/transform.root.localScale.x)));
//			Debug.Log("sss : " + (Mathf.Abs(other.transform.parent.position.x/transform.root.localScale.x)/150));
//			Debug.Log("sssss : " + ((1-(Mathf.Abs(other.transform.parent.position.x/transform.root.localScale.x)/150))+1));
			if (other.gameObject.transform.GetComponent<UITexture> () != null)
			if ((Mathf.Abs (other.transform.parent.position.x / transform.root.localScale.x)) <= (Size.x / 2 + BenchmarkSize / 2)) {
				float num = (1 - (Mathf.Abs (other.transform.parent.position.x / transform.root.localScale.x) / (Size.x / 2 + BenchmarkSize / 2)));
				other.gameObject.transform.GetComponent<UITexture> ().SetRect ((DefaultSize.x*(1f-num))+(MaxSize.x*num),
				                                                     (DefaultSize.y*(1f-num))+(MaxSize.y*num));
				other.gameObject.transform.GetComponent<BoxCollider2D>().size = new Vector2((DefaultSize.x*(1f-num))+(MaxSize.x*num),
				                                                                  (DefaultSize.y*(1f-num))+(MaxSize.y*num));
				other.gameObject.transform.parent.GetComponent<UIPanel>().SetRect(
					other.gameObject.transform.GetComponent<BoxCollider2D>().size.x,
					other.gameObject.transform.GetComponent<BoxCollider2D>().size.y);
//				other.gameObject.transform.FindChild("shadow").GetComponent<UISprite>().SetRect(
//					other.gameObject.transform.GetComponent<BoxCollider2D>().size.x,
//					other.gameObject.transform.GetComponent<BoxCollider2D>().size.y
//					);

				float Gaps;
				if(other.transform.parent.position.x / transform.root.localScale.x>=0){
					Gaps = -Gap;
				}else{
					Gaps = Gap;
				}
			
			
				
					float Mark = BenchmarkSize*0.5f*0.5f;
				if(Mathf.Abs(other.transform.parent.position.x / transform.root.localScale.x)<=Mark){	
						if(other.gameObject.name =="Item 2"){
							}

					float here = Mathf.Abs(other.transform.parent.position.x / transform.root.localScale.x)/Mark;
					other.gameObject.transform.parent.localPosition = new Vector3((float.Parse(other.transform.parent.name.Replace("Item ","").ToString())*Size.x)-(here*Gaps),other.gameObject.transform.parent.localPosition.y);
						if(other.gameObject.name =="Item 2"){
				
						}
					}else{
						Mark = BenchmarkSize*0.5f*0.5f;
					float here = ((BenchmarkSize*0.5f)-Mathf.Abs(other.transform.parent.position.x / transform.root.localScale.x))/Mark;
					other.gameObject.transform.parent.localPosition = new Vector3((float.Parse(other.transform.parent.name.Replace("Item ","").ToString())*Size.x)-(here*Gaps),other.gameObject.transform.parent.localPosition.y);

					}

		
			}
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "item") {
			if(other.transform.parent.position.x <=0){
			other.transform.parent.name = "Item " + (int.Parse(other.transform.parent.name.Replace("Item ",""))+UIScrollView._CoverFlowCount).ToString();
			}else{
				other.transform.parent.name = "Item " + (int.Parse(other.transform.parent.name.Replace("Item ",""))-UIScrollView._CoverFlowCount).ToString();
			}
				if(other.gameObject.transform.GetComponent<UITexture> ()!=null){
				other.gameObject.transform.GetComponent<UITexture> ().SetRect (DefaultSize.x,
				                                                    DefaultSize.y);
				other.gameObject.transform.GetComponent<BoxCollider2D>().size = new Vector2(DefaultSize.x,
			                                                                  DefaultSize.y);
				other.gameObject.transform.parent.GetComponent<UIPanel>().SetRect(DefaultSize.x,
				                                                                  DefaultSize.y);
				other.gameObject.transform.parent.localPosition = new Vector3(float.Parse(other.transform.parent.name.Replace("Item ","").ToString())*Size.x,other.gameObject.transform.parent.localPosition.y);
//				other.gameObject.transform.FindChild("shadow").GetComponent<UISprite>().SetRect(DefaultSize.x,
//				                                                                                DefaultSize.y);
			}
			//Debug.Log("ss : " + (Mathf.Abs(other.transform.position.x/transform.root.localScale.x)));
		}
	}

}
