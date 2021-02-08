using System.Collections.Generic;
using UnityEngine;
using System;

public class SortManager : MonoBehaviour
{
    public int cloneCount = 100;
    GameObject bar;
    List<int> lengthList;
    int index;

    public struct Barobj
    {
        public int height { get; }
        public Bar script { get; }
        public Barobj(int h, Bar s) { height = h; script = s; }
    }

    public Barobj[] barArray;

    private void Start()
    {
        Camera.main.transform.position = new Vector3((cloneCount + 1) / 2, cloneCount / 2, -cloneCount);
        bar = Resources.Load("Bar") as GameObject;
        init();
    }

    public void init()
    {
        barArray = new Barobj[cloneCount];
        lengthList = new List<int>();
        for (int i = 0; i < cloneCount; i++)
        {
            lengthList.Add(i + 1);
        }

        for (int i = 0; i < cloneCount; i++)
        {
            var obj = Instantiate(bar, new Vector3(i, 0, 0), new Quaternion(), transform);
            index = UnityEngine.Random.Range(0, lengthList.Count);
            obj.transform.localScale = new Vector3(1, lengthList[index], 1);
            barArray[i] = new Barobj(lengthList[index], obj.GetComponent<Bar>());
            lengthList.RemoveAt(index);
        }
    }

    private void Update()
    {
        nowPlaying = false;
    }

    const double PI = System.Math.PI;
    private enum PlayState
    {
        None,
        C,
        CS,
        D,
        DS,
        E,
        F,
        FS,
        G,
        GS,
        A,
        AS,
        B,
        C2
    }

    public double gain = 1.5;
    private double increment;
    private double sampling_frequency = 48000;
    private double time;
    private PlayState playState = PlayState.None;
    public bool nowPlaying = false;
    private float fadeScale;
    double scale = 1;

    void SineWave(float[] data, int channels, double frequency)
    {
        increment = frequency * 2 * PI / sampling_frequency;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            time = time + increment;
            data[i] = (float)(gain * Math.Sin(time) * fadeScale);

            if (nowPlaying)
            {
                fadeScale *= 1.5f;
                if (fadeScale > 1.0f) fadeScale = 1.0f;
            }
            else
            {
                fadeScale -= .025f;
                if (fadeScale < 0.001f)
                {
                    fadeScale = 0.0f;
                    playState = PlayState.None;
                }
            }
            if (channels == 2)
                data[i + 1] = data[i];
            if (time > 2 * Math.PI)
                time = 0;
        }
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        switch (playState)
        {
            case PlayState.C:
                SineWave(data, channels, 261.6255653005985 * scale);
                break;
            case PlayState.CS:
                SineWave(data, channels, 277.18263097687196 * scale);
                break;
            case PlayState.D:
                SineWave(data, channels, 293.66476791740746 * scale);
                break;
            case PlayState.DS:
                SineWave(data, channels, 311.1269837220808 * scale);
                break;
            case PlayState.E:
                SineWave(data, channels, 329.62755691286986 * scale);
                break;
            case PlayState.F:
                SineWave(data, channels, 349.2282314330038 * scale);
                break;
            case PlayState.FS:
                SineWave(data, channels, 369.99442271163434 * scale);
                break;
            case PlayState.G:
                SineWave(data, channels, 391.99543598174927 * scale);
                break;
            case PlayState.GS:
                SineWave(data, channels, 415.3046975799451 * scale);
                break;
            case PlayState.A:
                SineWave(data, channels, 440.0 * scale);
                break;
            case PlayState.AS:
                SineWave(data, channels, 466.1637615180899 * scale);
                break;
            case PlayState.B:
                SineWave(data, channels, 493.8833012561241 * scale);
                break;
            case PlayState.C2:
                SineWave(data, channels, 523.2511306011974 * scale);
                break;
        }
    }

    private void Play(PlayState playState_)
    {
        if (playState == PlayState.None)
        {
            fadeScale = 0.1f;
            time = 0.0f;
        }
        playState = playState_;
        nowPlaying = true;
    }

    public void playSound(int length)
    {
        scale = (length - 1) / 12 + 1;
        switch ((length - 1) % 12)
        {
            case 1:
                Play(PlayState.C);
                break;
            case 2:
                Play(PlayState.CS);
                break;
            case 3:
                Play(PlayState.D);
                break;
            case 4:
                Play(PlayState.DS);
                break;
            case 5:
                Play(PlayState.E);
                break;
            case 6:
                Play(PlayState.F);
                break;
            case 7:
                Play(PlayState.FS);
                break;
            case 8:
                Play(PlayState.G);
                break;
            case 9:
                Play(PlayState.GS);
                break;
            case 10:
                Play(PlayState.A);
                break;
            case 11:
                Play(PlayState.AS);
                break;
            case 12:
                Play(PlayState.B);
                break;
        }
    }
}
