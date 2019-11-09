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
    private GameObject scrollingArea;
    public PlayerData playerData;
    public int life;
    public int defense;
    public int attack;
    public float speed;

    void Start()
    {

        speed = playerData.initialSpeed;
        attack = playerData.initialAtk;
        life = playerData.initialLife;
        scrollingArea = Instantiate(playerData.scrollingArea, transform);
        defense = 0;
        GameObject background = Instantiate(playerData.corridorBackground, scrollingArea.transform);
        Instantiate(playerData.testItem, scrollingArea.transform);
        SetSpeed(speed);
    }


    public void SetSpeed(float curSpeed)
    {
        scrollingArea.GetComponent<ScrollingScript>().speed = curSpeed;
    }

}
