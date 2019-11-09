using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
public class InventoryData : ScriptableObject
{
	public int Width;
	public int Heigth;

	public float Gap;
	public float SlotSize;

	public GameObject SlotPrefab;
	
	public Vector2Int[] IsFree;
}

