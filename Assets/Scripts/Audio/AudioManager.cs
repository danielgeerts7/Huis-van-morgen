using OVRSimpleJSON;
using System;
using System.IO;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public SoundInfo[] soundInfos;
    private JSONNode info;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        // Get audioclips from JSON
        TextAsset textfromfile = Resources.Load<TextAsset>("Audio");
        using (StreamReader sr = new StreamReader(new MemoryStream(textfromfile.bytes)))
        {
            string json = sr.ReadToEnd();
            info = JSON.Parse(json);
            soundInfos = JsonHelper.getJsonArray<SoundInfo>(info["files"].ToString());
            sr.Close();
        }

        sounds = new Sound[soundInfos.Length];
        for (int i = 0; i < soundInfos.Length; i++)
        {
            Sound sound = new Sound(soundInfos[i]);
            sounds[i] = sound;
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public bool Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound: {name} not found in JSON file");
            return false;
        }
        s.source.Play();
        return true;
    }

    public void StopAll()
    {
        foreach (Sound sound in sounds)
        {
            sound.source.Stop();
        }
    }
}