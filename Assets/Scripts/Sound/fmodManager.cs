using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodManager : MonoBehaviour

{
    [FMODUnity.EventRef]
    public string inputvoiceline;
    private static fmodManager m_instance;
    public static fmodManager Instance
    
    {
        get
        {
            if (m_instance == null)
                m_instance = FindObjectOfType<fmodManager>();
            if (m_instance == null)
            {
				Debug.LogError("Not Fmod MAnager instantiate");
            }

            return m_instance;
        }
    }

    public SoundData soundData;

    public void OnChangeDragging()
    {
        string inputsound = soundData.inputsound;
        FMODUnity.RuntimeManager.PlayOneShot(inputsound);
    }

    void voiceLine ()
    {
        FMODUnity.RuntimeManager.PlayOneShot(inputvoiceline);
    }

    void Start()
    {
        InvokeRepeating("voiceLine", 0, UnityEngine.Random.Range(10, 30));
    }
}
