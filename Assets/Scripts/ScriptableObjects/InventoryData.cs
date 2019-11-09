using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "ScriptableObjects/InventoryData")]
public class InventoryData : ScriptableObject
{
	[OnChangedCall("Resize")]
	public int Width;
	[OnChangedCall("Resize")]
	public int Heigth;
	public GameObject SlotPrefab;
	[SerializeField]
	public bool[,] IsFree;

	private void Resize()
	{
		IsFree = new bool[Width, Heigth];
		for (int i = 0; i < Width; i++) {
			for (int j = 0; j < Heigth; j++) {

				IsFree[i, j] = false;
			}
		}
	}

}

public class OnChangedCallAttribute : PropertyAttribute
{
	public string methodName;
	public OnChangedCallAttribute(string methodNameNoArguments)
	{
		methodName = methodNameNoArguments;
	}
}

#if UNITY_EDITOR

[CustomPropertyDrawer(typeof(OnChangedCallAttribute))]
public class OnChangedCallAttributePropertyDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginChangeCheck();
		EditorGUI.PropertyField(position, property);
		if (EditorGUI.EndChangeCheck()) {
			OnChangedCallAttribute at = attribute as OnChangedCallAttribute;
			System.Reflection.MethodInfo method = property.serializedObject.targetObject.GetType().GetMethods().Where(m => m.Name == at.methodName).First();

			if (method != null && method.GetParameters().Count() == 0)// Only instantiate methods with 0 parameters
				method.Invoke(property.serializedObject.targetObject, null);
		}
	}
}

#endif
