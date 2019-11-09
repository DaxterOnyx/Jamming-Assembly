using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player m_instance;
    public static Player Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<Player>();
            }
            if (m_instance == null)
            {
                GameObject newInstance = Instantiate(new GameObject());
                newInstance.name = "Player (Singleton)";
                m_instance = newInstance.AddComponent<Player>();
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
        SetSpeed(speed);
    }


    public void SetSpeed(float curSpeed)
    {
        scrollingArea.GetComponent<ScrollingScript>().speed = curSpeed;
    }

}
