using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIDraggablePanel2 : UIScrollView
{
    //=====================================================================
    //
    // Fields & Properties - UI
    //
    //=====================================================================

    /// <summary>
	/// UIGrid - 아이템 부모 
    /// </summary>
//    public UIGrid Grid;
	public enum EArrangement
	{
		Vertical,
		Horizontal,
	}
	public EArrangement Arrangement;
	public float CellWidth;
	public float CellHeight;
	public int LineCount;

    /// <summary>
    /// 프리팹
    /// </summary>
    public GameObject TemplatePrefab;

    //=====================================================================
    //
    // Fields - Variable
    //
    //=====================================================================

    /// <summary>
    /// 총 아이템의 개수
    /// </summary>
    private int ItemCount;

    /// <summary>
    /// 첫 부분과 끝 부분의 아이템. grid 영역의 크기를 구하기 위함.
    /// </summary>
    private Transform mFirstTemplate = null;
    private Transform mLastTemplate = null;

    /// <summary>
    /// 첫 부분과 끝 부분의 위치
    /// </summary>
    private Vector3 mFirstPosition = Vector3.zero;
    private Vector3 mPrevPosition = Vector3.zero;
    
    /// <summary>
    /// 관리 리스트
    /// </summary>
    private List<UIListItem> mList = new List<UIListItem>();

    /// <summary>
    /// 화면에 보여질 최소한의 개수 
    /// </summary>
    private int mMinShowCount;

    //=====================================================================
    //
    // Fields & Properties - Events
    //
    //=====================================================================
        
    public delegate void ChangeIndexDelegate(UIListItem item, int index);
    private ChangeIndexDelegate mCallback;

    //=====================================================================
    //
    // Fields & Properties - Get & Set
    //
    //=====================================================================
        
    /// <summary>
    /// 머리를 가리킨다.
    /// </summary>
    private UIListItem Head { get { return mList.Count <= 0 ? null : mList[0]; } }

    /// <summary>
    /// 꼬리를 가리킨다.
    /// </summary>
    private UIListItem Tail { get { return mList.Count <= 0 ? null : mList[mList.Count - 1]; } }

    /// <summary>
    /// 화면에 보일 수 있는 가로 개수
    /// </summary>
    private int maxCol 
	{ 
		get 
		{ 
			if( Arrangement == EArrangement.Vertical )
			{
				return LineCount; 
			}
			else
			{
				return Mathf.CeilToInt(panel.clipRange.z / CellWidth);
			}
		} 
	}

    /// <summary>
    /// 화면에 보일 수 있는 세로 개수
    /// </summary>
    private int maxRow 
	{
		get 
		{ 
			if( Arrangement == EArrangement.Vertical )
			{
				return Mathf.CeilToInt(panel.clipRange.w / CellHeight);
			}
			else
			{
				return LineCount;
			}
		} 
	}
//	{ get { return  } }

    //=====================================================================
    //
    // Methods - UIDraggablePanel override
    //
    //=====================================================================

    /// <summary>
    /// Calculate the bounds used by the widgets.
    /// </summary>
    public new Bounds bounds
    {
        get
        {
            if (!mCalculatedBounds)
            {
                mCalculatedBounds = true;
                mBounds = CalculateRelativeWidgetBounds2(mTrans, mFirstTemplate, mLastTemplate);
            }
            return mBounds;
        }
    }

    public override void Awake()
    {
        base.Awake();
    }

	public override void Start()
    {
        base.Start();
        mFirstPosition = mTrans.localPosition;
        mPrevPosition = mTrans.localPosition;
    }
    
	public override void OnDestroy()
    {
		base.OnDestroy();
        RemoveAll();
    }

    /// <summary>
    /// 아이템을 생성한다.
    /// </summary>
    /// <param name="count"></param>
    /// <param name="callback"></param>
    public void Init(int count, ChangeIndexDelegate callback)
    {
        mCallback = callback;

        ItemCount = count;
        SetTemplate(count);

        RemoveAll();
        mList.Clear();

        //화면에 보여질 개수
		if( Arrangement == EArrangement.Vertical )
        	mMinShowCount = maxCol * (maxRow + 1);
		else
        	mMinShowCount = (maxCol + 1) * maxRow;

        int makeCount = Mathf.Min(count, mMinShowCount);

        GameObject obj = null;
        UIListItem prevItem = null;
		//Debug.Log ("makecout : " + makeCount);
        for (int i = 0; i < makeCount; i++)
        {
//			Debug.Log(gameObject+ " :  " + TemplatePrefab );
            obj = NGUITools.AddChild(gameObject, TemplatePrefab);

            if( obj.GetComponent<UIDragScrollView>() == null )
				obj.AddComponent<UIDragScrollView>().scrollView = this;

            UIListItem item = new UIListItem();
            item.Target = obj;
			//item.Target.AddComponent<cUIScrollListBase>();
            item.SetIndex(i);
            mList.Add(item);

            item.Prev = prevItem;
            item.Next = null;
            if (prevItem != null)
                prevItem.Next = item;
            prevItem = item;

            mCallback(item, i);
        }
        UpdatePosition();
    }

    /// <summary>
    /// Restrict the panel's contents to be within the panel's bounds.
    /// </summary>
//    public override bool RestrictWithinBounds(bool instant)
//    {
//        Vector3 constraint = panel.CalculateConstrainOffset(bounds.min, bounds.max);
//
//        if (constraint.magnitude > 0.001f)
//        {
//            if (!instant && dragEffect == DragEffect.MomentumAndSpring)
//            {
//                // Spring back into place
//                SpringPanel.Begin(panel.gameObject, mTrans.localPosition + constraint, 13f, UpdateCurrentPosition);
//            }
//            else
//            {
//                // Jump back into place
//                MoveRelative(constraint);
//                mMomentum = Vector3.zero;
//                mScroll = 0f;
//            }
//            return true;
//        }
//        return false;
//    }

    /// <summary>
    /// Changes the drag amount of the panel to the specified 0-1 range values.
    /// (0, 0) is the top-left corner, (1, 1) is the bottom-right.
    /// </summary>
    public override void SetDragAmount(float x, float y, bool updateScrollbars)
    {
        base.SetDragAmount(x, y, updateScrollbars);

        UpdateCurrentPosition();
    }

    /// <summary>
    /// Move the panel by the specified amount.
    /// </summary>
    public override void MoveRelative(Vector3 relative)
    {
        base.MoveRelative(relative);
        UpdateCurrentPosition();
    }

    //=====================================================================
    //
    // Methods - UIDraggablePanel2
    //
    //=====================================================================

    /// <summary>
    /// 꼬리부분을 머리부분으로 옮긴다. 
    /// </summary>
    public void TailToHead()
    {
		int cnt = Arrangement == EArrangement.Vertical ? maxCol : maxRow;
		for (int i = 0; i < cnt; i++)
        {
            UIListItem item = Tail;

            if (item == null)
                return;

            if (item == Head)
                return;

            if (item.Prev != null)
                item.Prev.Next = null;

            item.Next = Head;
            item.Prev = null;

            Head.Prev = item;

            mList.RemoveAt(mList.Count - 1);
            mList.Insert(0, item);
		
			item.MoveToHead();
        }
    }

    /// <summary>
    /// 머리 부분을 꼬리 부분으로 옮긴다. 
    /// </summary>
    public void HeadToTail()
    {
		int cnt = Arrangement == EArrangement.Vertical ? maxCol : maxRow;
		for (int i = 0; i < cnt; i++)
        {
            UIListItem item = Head;

            if (item == null)
                return;

            if (item == Tail)
                return;

            item.Next.Prev = null;
            item.Next = null;
            item.Prev = Tail;

            Tail.Next = item;

            mList.RemoveAt(0);
            mList.Insert(mList.Count, item);

			item.MoveToTail();
        }
    }
    
    /// <summary>
    /// 실제 아이템 양 끝쪽에 임시 아이템을 생성 후 cllipping 되는 영역의 bound를 구한다.
    /// </summary>
    /// <param name="count"></param>
    private void SetTemplate(int count)
    {
        if (mFirstTemplate == null)
        {
            GameObject firstTemplate = NGUITools.AddChild(gameObject, TemplatePrefab);
            firstTemplate.SetActive(false);
            mFirstTemplate = firstTemplate.transform;
            mFirstTemplate.name = "first rect";
        }

        if (mLastTemplate == null)
        {
            GameObject lastTemplate = NGUITools.AddChild(gameObject, TemplatePrefab);
            lastTemplate.SetActive(false);
            mLastTemplate = lastTemplate.transform;
            mLastTemplate.name = "last rect";
        }
		float firstX = panel.baseClipRegion.x - ((panel.baseClipRegion.z - CellWidth) * 0.5f);
		float firstY = panel.baseClipRegion.y + ((panel.baseClipRegion.w - CellHeight + panel.clipSoftness.y) * 0.5f);
		if( Arrangement == EArrangement.Vertical )
		{
			mFirstTemplate.localPosition = new Vector3( firstX,
			                                           firstY,
			                                           0 );	//처음위치
			mLastTemplate.localPosition = new Vector3( firstX + (LineCount-1) * CellWidth, 
			                                          firstY - CellHeight * (count/LineCount), 0); //끝위치
		}
		else
		{
			mFirstTemplate.localPosition = new Vector3( firstX,
			                                           firstY,
			                                           0 );	//처음위치
			mLastTemplate.localPosition = new Vector3( firstX + CellWidth * (count/LineCount),
			                                          firstY - (LineCount-1) * CellHeight, 
			                                          0); //끝위치
		}

		mCalculatedBounds = true;
		mBounds = CalculateRelativeWidgetBounds2(mTrans, mFirstTemplate, mLastTemplate);
		
		Vector3 constraint = panel.CalculateConstrainOffset(bounds.min, bounds.max);
		SpringPanel.Begin(panel.gameObject, mTrans.localPosition + constraint, 13f).onFinished = UpdateCurrentPosition;
		
	}

    /// <summary>
    /// 아이템들의 재사용을 위하여 위치를 조절한다.
    /// </summary>
    public void UpdateCurrentPosition()
    {
        Vector3 currentPos = mFirstPosition - mTrans.localPosition;
		if (Arrangement == EArrangement.Vertical)
        {
            bool isScrollUp = currentPos.y > mPrevPosition.y;
			int col = maxCol;

            if (isScrollUp)
            {
				int headIndex = (int)(-currentPos.y / CellHeight) * col;  //가로줄의 맨 처음 
				headIndex = Mathf.Clamp(headIndex, 0, ItemCount - col);

                if (Head != null && Head.Index != headIndex && headIndex <= ItemCount - mList.Count)
                {
                    // 꼬리 -> 처음.
                    TailToHead();
                    SetIndexHeadtoTail(headIndex);
                    UpdatePosition();
                }
            }
            else
            {
                //가로줄의 맨 오른쪽
				int tailIndex = (Mathf.CeilToInt((-currentPos.y + panel.clipRange.w) / CellHeight) * col) -1; 
                tailIndex = Mathf.Clamp(tailIndex, 0, ItemCount - 1);

                if (Tail != null && Tail.Index != tailIndex && tailIndex >= mList.Count)
                {
                    // 처음 -> 꼬리.
                    HeadToTail();
                    SetIndexTailtoHead(tailIndex);
                    UpdatePosition();
                }
            }
        }
		else
		{
			bool isScrollUp = currentPos.x > mPrevPosition.x;
			int row = maxRow;

			if (isScrollUp)
			{
				int headIndex = (int)(currentPos.x / CellWidth) * row;  //세로줄의 맨 처음 
				headIndex = Mathf.Clamp(headIndex, 0, ItemCount - row);
				
				if (Head != null && Head.Index != headIndex && headIndex <= ItemCount - mList.Count)
				{
					// 꼬리 -> 처음.
					TailToHead();
					SetIndexHeadtoTail(headIndex);
					UpdatePosition();
				}
			}
			else
			{
				//세로줄의 맨 오른쪽
				int tailIndex = (Mathf.CeilToInt((currentPos.x + panel.clipRange.z) / CellWidth) * row) -1; 
				tailIndex = Mathf.Clamp(tailIndex, 0, ItemCount - 1);
				
				if (Tail != null && Tail.Index != tailIndex && tailIndex >= mList.Count)
				{
					// 처음 -> 꼬리.
					HeadToTail();
					SetIndexTailtoHead(tailIndex);
					UpdatePosition();
				}
			}
		}
        mPrevPosition = currentPos;
    }

    /// <summary>
    /// head부터 index를 재 정리한다.
    /// </summary>
    /// <param name="headIndex"></param>
    public void SetIndexHeadtoTail(int headIndex)
    {

        UIListItem item = null;
        int index = -1;
        for (int i = 0; i < mList.Count; i++)
        {
            index = i + headIndex;
            item = mList[i];
            item.SetIndex(index);

            mCallback(item, index);
        }
    }

    /// <summary>
    /// tail부터 index를 재 정리한다.
    /// </summary>
    /// <param name="tailIndex"></param>
    public void SetIndexTailtoHead(int tailIndex)
    {
        UIListItem item = null;
        int index = -1;
        int cnt = mList.Count;
        for (int i = 0; i < cnt; i++)
        {
            index = tailIndex - i;
            item = mList[cnt - i - 1];
            item.SetIndex(index);
            mCallback(item, index);
        }
    }

    /// <summary>
    /// 아이템들의 위치를 정한다.
    /// </summary>
    private void UpdatePosition()
    {
		float firstX, firstY;
		firstX = panel.baseClipRegion.x - ((panel.baseClipRegion.z - CellWidth) * 0.5f);
		firstY = panel.baseClipRegion.y + ((panel.baseClipRegion.w - CellHeight + panel.clipSoftness.y) * 0.5f);

		if( Arrangement == EArrangement.Vertical )
		{
			//Debug.Log("ononon");
			int col = maxCol;
	        for (int i = 0; i < mList.Count; i++)
	        {

	            Transform t = mList[i].Target.transform;

	            Vector3 position = Vector3.zero;
	           
	        	//index를 기준으로 위치를 다시 잡는다. ( % 연산은 쓰지 않고 계산.)
				int div = mList[i].Index / col;
				int remain = mList[i].Index - ( col * div );
				//Debug.Log(firstY + " : " +div+" : "+CellHeight+ " : " +mList[i].Index+ " : " +col);
				position.x += firstX + (remain * CellWidth);
				position.y -= -firstY + (div * CellHeight);

				t.localPosition = position;
				t.name = string.Format("item index:{0}", mList[i].Index);
			}
		}
		else
		{
			int row = maxRow;
			for (int i = 0; i < mList.Count; i++)
			{
				Transform t = mList[i].Target.transform;
				
				Vector3 position = Vector3.zero;
				//index를 기준으로 위치를 다시 잡는다. ( % 연산은 쓰지 않고 계산.)
				int div = mList[i].Index / row;
				int remain = mList[i].Index - ( row * div );

				position.x += firstX + (div * CellWidth);
				position.y -= -firstY + (remain * CellHeight);
				
				t.localPosition = position;
//				Debug.Log( t.localPosition );
				t.name = string.Format("item index:{0}", mList[i].Index);
			}
		}
    }

    /// <summary>
    /// 해당 아이템을 삭제한다.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(UIListItem item)
    {
        if (item.Prev != null)
        {
            item.Prev.Next = item.Next;
        }

        if (item.Next != null)
        {
            item.Next.Prev = item.Prev;
        }

        UIListItem tmp = item.Next as UIListItem;
        int idx = item.Index;
        int tempIdx;
        while (tmp != null)
        {
            tempIdx = tmp.Index;
            tmp.Index = idx;
            mCallback(tmp, tmp.Index);

            idx = tempIdx;
            tmp = tmp.Next as UIListItem;

        }

        UIListItem tail = Tail;
        mList.Remove(item);

        if (ItemCount < mMinShowCount)
        {
            GameObject.DestroyImmediate(item.Target);
        }
        else
        {
            if (item == tail || Tail.Index >= ItemCount - 1)
            {
                // add head
                Head.Prev = item;
                item.Next = Head;
                item.Prev = null;
                item.Index = Head.Index - 1;
                mList.Insert(0, item);
                mCallback(item, item.Index);

                Vector3 constraint = panel.CalculateConstrainOffset(bounds.min, bounds.max);
				SpringPanel.Begin(panel.gameObject, mTrans.localPosition + constraint, 13f).onFinished = UpdateCurrentPosition;
            }
            else
            {
                // add tail
                Tail.Next = item;
                item.Prev = Tail;
                item.Next = null;
                item.Index = Tail.Index + 1;
                mList.Add(item);

                mCallback(item, item.Index);
            }
        }

        UpdatePosition();
    }

    /// <summary>
    /// 아이템 모두 삭제한다.
    /// </summary>
    public void RemoveAll()
    {
        UIListItem item = null;
        for (int i = 0; i < mList.Count; i++)
        {
            item = mList[i];
            GameObject.DestroyImmediate(item.Target);
        }

        mList.Clear();
    }

    /// <summary>
    /// 해당 인덱스에 아이템을 추가한다.
    /// </summary>
    /// <param name="index"></param>
    public void AddItem(int index)
    {
        // 아직 필요없어서 추후 필요하면 구현 -_-)~....
    }

    /// <summary>
    /// scroll영역을 계산한다.
    /// </summary>
    /// <param name="root"></param>
    /// <param name="firstTemplate"></param>
    /// <param name="lastTemplate"></param>
    /// <returns></returns>
	static public Bounds CalculateRelativeWidgetBounds2( Transform root, Transform firstTemplate, Transform lastTemplate )
	{
		if( firstTemplate==null || lastTemplate==null )
			return new Bounds(Vector3.zero, Vector3.zero);
		
		UIWidget[] widgets1 = firstTemplate.GetComponentsInChildren<UIWidget>(true) as UIWidget[];
		UIWidget[] widgets2 = lastTemplate.GetComponentsInChildren<UIWidget>(true) as UIWidget[];
		if( widgets1.Length==0 || widgets2.Length==0 )
			return new Bounds(Vector3.zero, Vector3.zero);
		
		Vector3 vMin = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 vMax = new Vector3(float.MinValue, float.MinValue, float.MinValue);
		
		Matrix4x4 toLocal = root.worldToLocalMatrix;
		bool isSet = false;
		Vector3 v;
		
		int nMax1 = widgets1.Length;
		for( int i=0; i<nMax1; ++i )
		{
			UIWidget w = widgets1[i];
			
			Vector3[] corners = w.worldCorners;
			
			for (int j = 0; j < 4; ++j)
			{
				v = toLocal.MultiplyPoint3x4(corners[j]);
				vMax = Vector3.Max(v, vMax);
				vMin = Vector3.Min(v, vMin);
			}
			isSet = true;
		}
		
		int nMax2 = widgets2.Length;
		for( int i=0; i<nMax2; ++i )
		{
			UIWidget w = widgets2[i];
			
			Vector3[] corners = w.worldCorners;
			
			for (int j = 0; j < 4; ++j)
			{
				v = toLocal.MultiplyPoint3x4(corners[j]);
				vMax = Vector3.Max(v, vMax);
				vMin = Vector3.Min(v, vMin);
			}
			isSet = true;
		}
		
		if (isSet)
		{
			Bounds b = new Bounds(vMin, Vector3.zero);
			b.Encapsulate(vMax);
			return b;
		}
		
		return new Bounds(Vector3.zero, Vector3.zero);
		
	}
}