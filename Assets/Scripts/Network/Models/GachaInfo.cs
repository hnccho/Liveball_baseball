using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GachaInfo {
	int _itemType;
	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}
	string _itemName;
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
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

	
	string _outMessage;
	public string outMessage {
		get {
			return _outMessage;
		}
		set {
			_outMessage = value;
		}
	}
	
	// "775296",
	int _outCode;
	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}
	
	// "982892",
	int _myNum;
	public int myNum {
		get {
			return _myNum;
		}
		set {
			_myNum = value;
		}
	}
	
	// "9432",
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
