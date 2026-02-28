using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMStarter : MonoBehaviour
{
    public AudioClip bgmClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(bgmClip, 0.2f);
    }
}
