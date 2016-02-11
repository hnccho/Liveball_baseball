using UnityEngine;
using System.Collections;

public class StoreGachaInfo {
	string _itemName;

	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}
	string _imagePath;
	
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}
	int _itemValue;
	
	public int itemValue {
		get {
			return _itemValue;
		}
		set {
			_itemValue = value;
		}
	}
	int _itemType;
	
	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

	string _outMessage;
	
	public string outMessage {
		get {
			return _outMessage;
		}
		set {
			_outMessage = value;
		}
	}
	int _outCode;
	
	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

	int _myNum;
	
	public int myNum {
		get {
			return _myNum;
		}
		set {
			_myNum = value;
		}
	}

	string _itemCode;
	
	public string itemCode {
		get {
			return _itemCode;
		}
		set {
			_itemCode = value;
		}
	}

}
