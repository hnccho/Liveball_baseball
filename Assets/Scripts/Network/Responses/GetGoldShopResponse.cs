using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GetGoldShopResponse : BaseResponse {
	List<ShopGoldInfo> _data;

	public List<ShopGoldInfo> data {
		get {
			return _data;
		}
		set {
			_data = value;
		}
	}
}
