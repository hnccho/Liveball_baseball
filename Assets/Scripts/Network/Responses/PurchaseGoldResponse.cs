using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PurchaseGoldResponse : BaseResponse {
	CardInvenInfo _data;

	public CardInvenInfo data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
