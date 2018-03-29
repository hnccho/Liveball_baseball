using UnityEngine;
using System.Collections;

public class EntryListInfo {
	int _memSeq;
	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

	int _rankPoint;

	public int rankPoint {
		get {
			return _rankPoint;
		}
		set {
			_rankPoint = value;
		}
	}

//1,				
	int _rank;
	public int rank {
		get {
			return _rank;
		}
		set {
			_rank = value;
		}
	}

//1,			// rank 번호	
	int _contestSeq;
	public int contestSeq {
		get {
			return _contestSeq;
		}
		set {
			_contestSeq = value;
		}
	}

//190,
	// contest 번호	
	string _imagePath;
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

//"",
	// 이미지 profile path
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

//"",
	string _name;
	public string name {
		get {
			return _name;
		}
		set {
			_name = value;
		}
	}

//"charlie",
	// nick name	
	int _entrySeq;
	public int entrySeq {
		get {
			return _entrySeq;
		}
		set {
			_entrySeq = value;
		}
	}

//65,			// 엔트리Id 번호	
	float _fantasyPoint;//138.6

	public float fantasyPoint {
		get {
			return _fantasyPoint;
		}
		set {
			_fantasyPoint = value;
		}
	}

	int _gameOverPlayers;

	public int gameOverPlayers {
		get {
			return _gameOverPlayers;
		}
		set {
			_gameOverPlayers = value;
		}
	}

	string _photoUrl;

	public string photoUrl {
		get {
			return _photoUrl;
		}
		set {
			_photoUrl = value;
		}
	}
}
