using UnityEngine;

public class Slot : MonoBehaviour
{
	public enum State
	{
		UNAVAILABLE = 0,
		USABLE = 1,
		LOCKED = 3,
		SPECIAL
	}

	/// <summary>
	/// [déconseillé] préféré SetState ou Is...
	/// </summary>
	public State state;
	public Sprite[] sprites;
	[SerializeField]
	private Vector2Int position;
	private Item item;
	public GameObject gridPrefab;
	private GameObject grid;
	public bool CanAddItemSpecial = true;

	internal bool IsUnvailable { get { return state == State.UNAVAILABLE; } }
	internal bool IsBinded { get { return state == State.LOCKED; } }
	internal bool IsUsable { get { return state == State.USABLE && item == null; } }

	public bool IsSpecial { get { return state == State.SPECIAL; } }

	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	internal void SetState(State p_state)
	{
		if (IsSpecial)
			return;
		this.state = p_state;

		GetComponent<SpriteRenderer>().sprite = sprites[(int)state];
	}

	internal void SetItem(Item p_item)
	{
		item = p_item;
	}

	internal static Slot[] CreateArray(Slot slot)
	{
		return new Slot[] { slot };
	}

	internal Item GetItem()
	{
		return item;
	}

	private void OnMouseEnter()
	{
		if (CanAddItemSpecial && IsSpecial)
			SelectionManager.Instance.SetCaseOver(this);
	}

	private void OnMouseExit()
	{
		if (CanAddItemSpecial && IsSpecial)
			SelectionManager.Instance.SetCaseOver(null);
	}

	internal Vector2Int GetPosition()
	{
		return position;
	}

	//private void OnMouseOver()
	//{
	//	//print(InventoryManager.Instance.SlotPosition(SelectionManager.Instance.MouseWorldPosition,false));
	//}

	/// <summary>
	/// Show chain on item
	/// </summary>
	internal void SpawnGrid()
	{
		grid = Instantiate(gridPrefab, transform);
	}

	/// <summary>
	/// Hide chain on item
	/// </summary>
	internal void KillGrid()
	{
		if (grid != null) {
			Destroy(grid);
		}
	}

	internal void RemoveItem()
	{
		item = null;
	}

	internal bool CanAcceptItem(Vector2Int size)
	{
		if (IsSpecial)
			return true;

		bool isOk = true;
		for (int i = 0; i < size.x && isOk; i++) {
			for (int j = 0; j < size.y && isOk; j++) {
				isOk = InventoryManager.Instance.GetSlot(position.x + i, position.y + j).IsUsable;
			}
		}

		return isOk;
	}
}
