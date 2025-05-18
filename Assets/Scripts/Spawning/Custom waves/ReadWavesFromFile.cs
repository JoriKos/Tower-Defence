using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReadWavesFromFile : MonoBehaviour
{
    private TextAsset _waveFile;
    private string[] _waveFileLine;

    private void Awake()
    {
        _waveFile = Resources.Load<TextAsset>("waves");
        string allText = _waveFile.text;

        for (int i = 0; i < 3; i++)
        {
            _waveFileLine = allText.Split('-');
            Debug.Log(_waveFileLine[i]);
        }
    }
}
