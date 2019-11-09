using UnityEngine;

public class Slot : MonoBehaviour
{
	public enum State
	{
		UNAVAILABLE = 0,
		USABLE = 1,
		TAKEN,
		LOCKED
	}

	/// <summary>
	/// [déconseillé] préféré SetState ou IsTaken
	/// </summary>
	public State state;
	public Sprite[] sprites;
	private Vector2Int position;
	private Item item;
	public GameObject gridPrefab;
	private GameObject grid;

	internal void SetPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	internal void SetState(State p_state)
	{
		this.state = p_state;

		GetComponent<SpriteRenderer>().sprite = sprites[(int)state];
	}

	internal bool isBinded
	{
		get {
			return state == State.LOCKED;
		}
	}

	internal void SetItem(Item p_item, bool changeState)
	{
		item = p_item;
		if (changeState)
			SetState(State.TAKEN);
	}

	internal static Slot[] CreateArray(Slot slot)
	{
		return new Slot[] { slot };
	}

	internal Item GetItem()
	{
		return item;
	}

	internal bool IsTaken
	{
		get {
			return state == State.TAKEN;
		}
	}

	public bool IsUnvailable { get { return state == State.UNAVAILABLE; }  }

	private void OnMouseEnter()
	{
		SelectionManager.Instance.SetCaseOver(this);
	}

	private void OnMouseExit()
	{
		SelectionManager.Instance.SetCaseOver(null);

	}
	private void OnMouseOver()
	{
		//print(InventoryManager.Instance.SlotPosition(SelectionManager.Instance.MouseWorldPosition,false));
	}

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
}
