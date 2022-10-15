using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SoundManager : SingletonBase<SoundManager>
{
    public AudioMixer mixer;
    public AudioSource bgSound;
    public AudioClip[] bglist;
    private void Start()
    {
        BgSoundPlay(bglist[0]);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    //효과음
    public void SFXPlay(string sfxName, AudioClip clip, Vector3 pos)
    {
        GameObject go = new GameObject(sfxName + "Sound");
        go.transform.position = pos;
        AudioSource audiosource = go.AddComponent<AudioSource>();
        audiosource.spatialBlend = 1;
        audiosource.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        audiosource.clip = clip;
        audiosource.Play();
        Destroy(go, clip.length-0.01f);
    }
    //배경음
    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.outputAudioMixerGroup = mixer.FindMatchingGroups("BGM")[0];
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 1f;
        bgSound.Play();
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        for (int i = 0; i < bglist.Length; i++)
            if (scene.name == bglist[i].name)
                BgSoundPlay(bglist[i]);
    }
}
