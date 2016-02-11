using UnityEngine;
using System.Collections;

public class ListItemBase
{
	public ListItemBase Prev;
	public ListItemBase Next;
	
	public ListItemBase()
	{
		Prev = Next = null;
	}
}

public class UIListItem : ListItemBase {
	public enum Status
	{
		None,
		MovedToHead,
		MovedToTail
	}
	
	public int Index;
	public GameObject Target;
	Status mStatus;
	
	public UIListItem()
	{
		Index = -1;
		Target = null;
	}
	
    /// <summary>
    /// index를 설정한다.
    /// </summary>
    /// <param name="index"></param>
	public void SetIndex( int index )
	{
		if( Index != index )
		{
			Index = index;
			if( Target != null )
			{
				//Debug.Log("target : " + Target );
				
				if( Target.GetComponent< cUIScrollListBase >() == null ){
					Target.AddComponent<cUIScrollListBase>();
				}

				cUIScrollListBase scr = Target.GetComponent< cUIScrollListBase >();
				scr.ListItem = this;
			}
		}		
	}	

	public void MoveToHead()
	{
		mStatus = Status.MovedToHead;
	}

	public void MoveToTail()
	{
		mStatus = Status.MovedToTail;
	}

	public Status GetStatus()
	{
		return mStatus;
	}

	public void SetStatus(Status status)
	{
		mStatus = status;
	}
}

public class cUIScrollListBase : MonoBehaviour
{
    public UIListItem ListItem;

	public UIListItem GetListItem()
	{
		return ListItem;
	}
}
