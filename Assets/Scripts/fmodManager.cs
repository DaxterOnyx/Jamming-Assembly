using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fmodManager : MonoBehaviour

{
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
}
