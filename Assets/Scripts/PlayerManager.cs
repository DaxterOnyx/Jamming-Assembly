using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    private static PlayerManager m_instance;
    public static PlayerManager Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<PlayerManager>();
            }
            if (m_instance == null)
            {
                GameObject newInstance = Instantiate(new GameObject());
                newInstance.name = "Player (Singleton)";
                m_instance = newInstance.AddComponent<PlayerManager>();
            }
            return m_instance;
        }
    }
    private List<GameObject> scrollingAreaList;
    private GameObject scrollingAreaB;
    private GameObject scrollingAreaI;
    private GameObject scrollingAreaF;
    public PlayerData playerData;
    public int life;
    public int defense;
    public int attack;
    public float speed;

    void Start()
    {
        scrollingAreaList = new List<GameObject>();
        //Setup Parameters
        speed = playerData.initialSpeed;
        attack = playerData.initialAtk;
        life = playerData.initialLife;
        defense = 0;
        //Creation of scrollingAreas
        scrollingAreaB = Instantiate(playerData.scrollingAreaBackground, transform);
        scrollingAreaList.Add(scrollingAreaB);
        scrollingAreaF = Instantiate(playerData.scrollingAreaForeground, transform);
        scrollingAreaList.Add(scrollingAreaF);
        scrollingAreaI = Instantiate(playerData.scrollingAreaItems, transform);
        scrollingAreaList.Add(scrollingAreaI);

        //Initialisation of speed
        SetSpeed(speed);
        Instantiate(playerData.testItem, scrollingAreaI.transform);
    }


    public void SetSpeed(float curSpeed)
    {
        foreach (var item in scrollingAreaList)
        {
            item.GetComponent<ScrollingScript>().speed = curSpeed;
        }

    }

}
