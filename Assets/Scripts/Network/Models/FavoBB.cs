using UnityEngine;
using System.Collections;

public class FavoBB {
	int _teamSeq;
	public int teamSeq {
		get {
			return _teamSeq;
		}
		set {
			_teamSeq = value;
		}
	}

//":1,"
	string _teamCode;
	public string teamCode {
		get {
			return _teamCode;
		}
		set {
			_teamCode = value;
		}
	}

//":"LG","
	string _teamName;
	public string teamName {
		get {
			return _teamName;
		}
		set {
			_teamName = value;
		}
	}

//":"LG","
	string _teamFullName;
	public string teamFullName {
		get {
			return _teamFullName;
		}
		set {
			_teamFullName = value;
		}
	}

//":"LG 트윈스","
	string _imagePath;
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

//":"spos/team/","
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

//":"sports_team_baseball_lg.png","
	int _imageWidth;
	public int imageWidth {
		get {
			return _imageWidth;
		}
		set {
			_imageWidth = value;
		}
	}

//":200,"
	int _imageHeight;
	public int imageHeight {
		get {
			return _imageHeight;
		}
		set {
			_imageHeight = value;
		}
	}

//":200,"
	string _teamColor;
	public string teamColor {
		get {
			return _teamColor;
		}
		set {
			_teamColor = value;
		}
	}

//":"#c20e57","
	int _contentsType;//":2001

	public int contentsType {
		get {
			return _contentsType;
		}
		set {
			_contentsType = value;
		}
	}
}
