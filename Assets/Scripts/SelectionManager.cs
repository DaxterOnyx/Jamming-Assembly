using UnityEngine;

public class SelectionManager : MonoBehaviour
{
	private static SelectionManager m_instance;
	public static SelectionManager Instance
	{
		get {
			if (m_instance == null)
				m_instance = FindObjectOfType<SelectionManager>();
			if (m_instance == null) {
				GameObject newInstance = Instantiate(new GameObject());
				newInstance.name = "SelectionManager (Singleton)";
				m_instance = newInstance.AddComponent<SelectionManager>();
			}

			return m_instance;
		}
	}

	internal void SelectItem(Item item)
	{
		if (item != currentItemOver)
			Debug.LogWarning("Select not current over Item");

		currentItemOver = item;
		isDragging = currentItemOver.SetInMouvement();
	}

	internal void DropItem(Item item)
	{
		if (!isDragging) {
			Debug.LogWarning("Drop not in draging Item");
			StopDragging();

			return;
		}
		if (item != currentItemOver) {
			Debug.LogWarning("Drop not current over Item");
			StopDragging();

			return;
		}
		if (currentSlotOver == null) {
			Debug.LogWarning("Drop in void");
			StopDragging();

			return;
		}
		if (currentSlotOver.IsUnvailable) {
			Debug.LogWarning("Slot is Unvailable");
			StopDragging();

			return;
		}
		if(!currentSlotOver.CanAcceptItem(item.size)) {
			Debug.LogWarning("item is to big");
			StopDragging();

			return;
		}
		if (!currentSlotOver.IsUsable) {
			Debug.LogWarning("Slot already taken");
			StopDragging();

			return;
		}

		item.SetSlots(InventoryManager.Instance.GetSlots(currentSlotOver.GetPosition().x, currentSlotOver.GetPosition().y,item.size));
		StopDragging();
	}

	private void StopDragging()
	{
		isDragging = false;
		currentSlotOver = null;
		currentItemOver.ResetMouvement();
		currentItemOver = null;
	}

	internal void SetItemOver(Item item)
	{
		if (!isDragging)
			currentItemOver = item;
	}

	private new Camera camera;
	private Slot currentSlotOver;
	private Item currentItemOver;
	private bool isDragging;

	public void Init()
	{
		camera = FindObjectOfType<Camera>();
	}

	public Vector2 MouseWorldPosition { get { return camera.ScreenToWorldPoint(Input.mousePosition); } }

	internal void SetCaseOver(Slot slot)
	{
		if (isDragging)
			currentSlotOver = slot;
	}

	private void Update()
	{
		if (isDragging)
			currentItemOver.transform.position = MouseWorldPosition;
	}
}
