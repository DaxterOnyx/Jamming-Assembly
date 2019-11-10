using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconList : MonoBehaviour
{
    private List<GameObject> icons;
    public GameObject icon;

   public void Fill(Item item)
    {
        icons = new List<GameObject>();
        foreach (var effect in item.effectList)
        {
            GameObject temp = Instantiate(icon, transform);
            temp.GetComponent<Image>().sprite = effect.icon;
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
