using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillsetInfo {
	static Dictionary<string, string> SkillImgDic;

	public static Dictionary<string, string> GetSkillImgDic(){
		if(SkillImgDic == null){
			SkillImgDic = new Dictionary<string, string>();
			SkillImgDic.Add("SKILL_HIT", "skill_icon_b_1");
			SkillImgDic.Add("SKILL_2B", "skill_icon_b_2");
			SkillImgDic.Add("SKILL_3B", "skill_icon_b_3");
			SkillImgDic.Add("SKILL_HR", "skill_icon_b_4");
			SkillImgDic.Add("SKILL_BB", "skill_icon_b_5");
			SkillImgDic.Add("SKILL_HBP", "skill_icon_b_6");
			SkillImgDic.Add("SKILL_SB", "skill_icon_b_7");
			SkillImgDic.Add("SKILL_R", "skill_icon_b_9");
			SkillImgDic.Add("SKILL_RBI", "skill_icon_b_8");
			SkillImgDic.Add("SKILL_ER", "skill_icon_b_10");
			SkillImgDic.Add("SKILL_SAC", "skill_icon_b_11");
			SkillImgDic.Add("SKILL_SF", "skill_icon_b_12");

			SkillImgDic.Add("SKILL_W", "skill_icon_p_1");
			SkillImgDic.Add("SKILL_HOLD", "skill_icon_p_2");
			SkillImgDic.Add("SKILL_SAVE", "skill_icon_p_3");
			SkillImgDic.Add("SKILL_SO", "skill_icon_p_4");
			SkillImgDic.Add("SKILL_IP", "skill_icon_p_5");
			SkillImgDic.Add("SKILL_CG", "skill_icon_p_6");
			SkillImgDic.Add("SKILL_SHO", "skill_icon_p_7");
			SkillImgDic.Add("SKILL_GIDP", "skill_icon_p_9");
			SkillImgDic.Add("SKILL_PK", "skill_icon_p_8");
		}
		return SkillImgDic;
	}
//
//	public class Skillset{
//		public string korName;
//		public string engName;
//		public string korDesc;
//		public string engDesc;
//		public string code;
//
//		public Skillset(string k, string e, string c){
//			kor = k; eng = e; code = c;
//		}
//	}

	int _itemClass;
	public int itemClass {
		get {
			return _itemClass;
		}
		set {
			_itemClass = value;
		}
	}

//2,
	int _itemLevel;
	public int itemLevel {
		get {
			return _itemLevel;
		}
		set {
			_itemLevel = value;
		}
	}

//2,
	int _color;
	public int color {
		get {
			return _color;
		}
		set {
			_color = value;
		}
	}

//1,			x			4	홈런	SKILL_HR
	int _position;
	public int position {
		get {
			return _position;
		}
		set {
			_position = value;
		}
	}

//1,			1:타자관련, 2:투수관련			5	포볼	SKILL_BB
	int _point;
	public int point {
		get {
			return _point;
		}
		set {
			_point = value;
		}
	}

//20,			P
	string _addPoint;
	public string addPoint {
		get {
			return _addPoint;
		}
		set {
			_addPoint = value;
		}
	}

//"0.2",
	string _itemText;
	public string itemText {
		get {
			return _itemText;
		}
		set {
			_itemText = value;
		}
	}

//"단타",
	long _dockingCardId;
	public long dockingCardId {
		get {
			return _dockingCardId;
		}
		set {
			_dockingCardId = value;
		}
	}

//1459422059505,
	int _dockingCardSlot;
	public int dockingCardSlot {
		get {
			return _dockingCardSlot;
		}
		set {
			_dockingCardSlot = value;
		}
	}

//1,
	int _memSeq;
	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}

//10006,
	long _itemSeq;
	public long itemSeq {
		get {
			return _itemSeq;
		}
		set {
			_itemSeq = value;
		}
	}

//1466409114609,
	int _itemType;
	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

//3,
	long _itemId;
	public long itemId {
		get {
			return _itemId;
		}
		set {
			_itemId = value;
		}
	}

//2100320102,
	long _itemFK;
	public long itemFK {
		get {
			return _itemFK;
		}
		set {
			_itemFK = value;
		}
	}

//2100320102,
	int _useYn;
	public int useYn {
		get {
			return _useYn;
		}
		set {
			_useYn = value;
		}
	}

//1,			카드에 장착여부			16	삼진	SKILL_SO
	string _itemName;
	public string itemName {
		get {
			return _itemName;
		}
		set {
			_itemName = value;
		}
	}

	string _itemNameKor;

	public string itemNameKor {
		get {
			return _itemNameKor;
		}
		set {
			_itemNameKor = value;
		}
	}

//"단타",
	string _itemDesc;
	public string itemDesc {
		get {
			return _itemDesc;
		}
		set {
			_itemDesc = value;
		}
	}

	string _itemDescKor;

	public string itemDescKor {
		get {
			return _itemDescKor;
		}
		set {
			_itemDescKor = value;
		}
	}

//"해당 경기에서 단타를 기록",
	string _imagePath;
	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

//"shop/",SKILL_SHO
	string _imageName;
	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

//"skill_red_pak.png",DP
	string _itemCode;//"SKILL_H"

	public string itemCode {
		get {
			return _itemCode;
		}
		set {
			_itemCode = value;
		}
	}

	int _dockingYn;

	public int dockingYn {
		get {
			return _dockingYn;
		}
		set {
			_dockingYn = value;
		}
	}
}
