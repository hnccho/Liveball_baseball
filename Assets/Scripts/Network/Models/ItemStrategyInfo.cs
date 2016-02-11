using UnityEngine;
using System.Collections;

public class ItemStrategyInfo {
	int _comboShieldYn;
	public int comboShieldYn {
		get {
			return _comboShieldYn;
		}
		set {
			_comboShieldYn = value;
		}
	}

//: 1,
	string _itemName;
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}

//: "콤보쉴드",
	float _multipleRatio;
	public float multipleRatio {
		get {
			return _multipleRatio;
		}
		set {
			_multipleRatio = value;
		}
	}

//: 1,
	int _betShieldYn;
	public int betShieldYn {
		get {
			return _betShieldYn;
		}
		set {
			_betShieldYn = value;
		}
	}

//: 0,
	int _itemCount;
	public int itemCount {
		get {
			return _itemCount;
		}
		set {
			_itemCount = value;
		}
	}

//: 10,
	int _itemId;
	public int itemId {
		get {
			return _itemId;
		}
		set {
			_itemId = value;
		}
	}

//: 1010,
	string _itemCode;//: "COMBO_SHIELD"

	public string itemCode {
		get {
			return _itemCode;
		}
		set {
			_itemCode = value;
		}
	}
}
