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
            if (m_instance == null) {
				Debug.LogError("Singleton PlayerManager not found");

			}
			return m_instance;
        }
    }
    private List<GameObject> scrollingAreaList;
    private GameObject scrollingAreaB;
    private GameObject scrollingAreaI;
    private GameObject scrollingAreaF;
    public PlayerData playerData;
    private GameObject corridorItem;
    public int life;
    public int defense;
    public int attack;
    public float speed;
    public Vector2 timeRangeSpawn;
    private float timeCounter;

    void Start()
    {
        corridorItem = playerData.corridorItem;
        scrollingAreaList = new List<GameObject>();
        //Setup Parameters
        speed = playerData.initialSpeed;
        attack = playerData.initialAtk;
        life = playerData.initialLife;
        defense = 0;
        timeCounter = UnityEngine.Random.Range(timeRangeSpawn.x, timeRangeSpawn.y);
        //Creation of scrollingAreas
        scrollingAreaB = Instantiate(playerData.scrollingAreaBackground, transform);
        scrollingAreaList.Add(scrollingAreaB);
        scrollingAreaF = Instantiate(playerData.scrollingAreaForeground, transform);
        scrollingAreaList.Add(scrollingAreaF);
        scrollingAreaI = Instantiate(playerData.scrollingAreaItems, transform);
        scrollingAreaList.Add(scrollingAreaI);

        //Initialisation of speed
        SetSpeed(speed);
    }
    private void Update()
    {
        if (timeCounter <= 0f)
        {
            timeCounter = UnityEngine.Random.Range(timeRangeSpawn.x, timeRangeSpawn.y);
            Instantiate(corridorItem, scrollingAreaI.transform).GetComponent<CorridorItem>().Init();
        }
        else
        {
            timeCounter -= Time.deltaTime;
        }

    }

    public void SetSpeed(float curSpeed)
    {
        foreach (var item in scrollingAreaList)
        {
            item.GetComponent<ScrollingScript>().speed = curSpeed;
        }

    }

}
