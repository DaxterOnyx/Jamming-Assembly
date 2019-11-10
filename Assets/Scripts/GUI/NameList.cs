using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameList : MonoBehaviour
{
    private List<GameObject> icons;
    public GameObject text;

    public void Fill(Item item)
    {
        icons = new List<GameObject>();
        foreach (var effect in item.effectList)
        {
            GameObject temp = Instantiate(text, transform);
            temp.GetComponent<Text>().text = effect.displayName;
            icons.Add(temp);
        }
    }

    public void Empty()
    {
        foreach (var item in icons)
        {
            Destroy(item);
        }
    }
}
