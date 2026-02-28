using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultManager : MonoBehaviour
{
    public static ResultManager Instance { get; private set; }

    private int eatenAppleCount;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCount()
    {
        eatenAppleCount += 1;
    }

    public void ResetCount()
    {
        eatenAppleCount = 0;
    }

    public int GetCount()
    {
        return eatenAppleCount;
    }

}
