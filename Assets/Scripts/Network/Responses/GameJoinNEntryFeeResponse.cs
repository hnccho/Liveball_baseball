using UnityEngine;
using System.Collections;

public class GameJoinNEntryFeeResponse : BaseResponse {
	JoinNEntryFee _data;

	public JoinNEntryFee data
	{
		get{ return _data;}
		set{ _data = value;}
	}
}
