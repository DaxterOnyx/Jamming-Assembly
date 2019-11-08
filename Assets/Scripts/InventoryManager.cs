using UnityEngine;

public class InventoryManager : MonoBehaviour
{
	private static InventoryManager m_instance;
	public static InventoryManager Instance
	{
		get { return m_instance; }
	}
}
