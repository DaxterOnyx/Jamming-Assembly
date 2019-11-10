using UnityEngine;

public class Slot : MonoBehaviour
{
	public enum State
	{
		UNAVAILABLE = 0,
		USABLE = 1,
		LOCKED = 2,
		ROOTED = 3,
		SPECIAL
	}

	/// <summary>
	/// [déconseillé] préféré SetState ou Is...
	/// </summary>
	[SerializeField]
	private State state;
	public Sprite[] sprites;
	[SerializeField]
	private Vector2Int position;
	private Item item;
	[SerializeField]
	private GameObject gridPrefab;
	private GameObject grid;
	[SerializeField]
	private GameObject rootPrefab;
	private GameObject root;
	public bool CanAddItemSpecial;
	public bool isStuffSlot = false;

	internal bool IsBinded { get { return isLocked || IsRooted; } }
	internal bool IsUsable { get { return state == State.USABLE && item == null; } }

	public bool IsSpecial { get { return state == State.SPECIAL; } }
	internal bool IsUnvailable { get { return state == State.UNAVAILABLE; } }
	private bool IsRooted { get { return state == State.ROOTED; } }
	public bool isLocked { get { return state == State.LOCKED; } }

	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	internal void SetState(State p_state)
	{
		if (IsSpecial) {
			Debug.LogWarning("Try to change State on Special slot");
			return;
		}

		state = p_state;

		GetComponent<SpriteRenderer>().sprite = sprites[(int)state];
		switch (state) {
			case State.UNAVAILABLE:
				Debug.LogWarning("Try to set State Unvailable");
				break;
			case State.USABLE:
				KillGrid();
				KillRoot();
				break;
			case State.LOCKED:
				SpawnGrid();
				break;
			case State.ROOTED:
				SpawnRoot();
				break;
			case State.SPECIAL:
				Debug.LogError("Try to set State Special");
				break;
			default:
				Debug.LogError("Try to set State not defined");
				return;
		}
	}

	internal State GetState()
	{
		return state;
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

	internal bool CanAcceptStuff(Item item)
	{
		return this == StuffManager.Instance.GetSlot(item.itemData.type, 0) || this == StuffManager.Instance.GetSlot(item.itemData.type, 1);
	}

	private void OnMouseEnter()
	{
		if (CanAddItemSpecial || !IsSpecial)
			SelectionManager.Instance.SetCaseOver(this);
	}

	private void OnMouseExit()
	{
		if (CanAddItemSpecial || !IsSpecial)
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
		if (grid == null)
			grid = Instantiate(gridPrefab, transform);
		else
			grid.SetActive(true);
	}

	/// <summary>
	/// Hide chain on item
	/// </summary>
	internal void KillGrid()
	{
		if (grid != null) {
			grid.SetActive(false);
		}
	}

	/// <summary>
	/// Show root on item
	/// </summary>
	internal void SpawnRoot()
	{
		if (root == null)
			root = Instantiate(rootPrefab, transform);
		else
			root.SetActive(true);
	}

	/// <summary>
	/// Hide root on item
	/// </summary>
	internal void KillRoot()
	{
		if (root != null) {
			root.SetActive(false);
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
