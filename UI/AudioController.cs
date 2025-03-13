using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public bool gender;//true为男 false为女
    public List<AudioClip> audioLiaMan;
    public List<AudioClip> audioLiaGirl;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
        if (audioSource == null)
    {
        Debug.LogError("AudioSource component is missing!");
    }
    }

    public AudioClip GetManAudioClip(string name){
        
    
    for (int i = 0; i < audioLiaMan.Count; i++)
    {
        if(name=="BaGuaZhen"||name=="BaiYinShiZi"||name=="CiXiongShuangGuJian"||name=="GuanShiFu"||name=="JiaMa"||name=="JianMa"||name=="QiLinGong"||name=="QingGangJian"||name=="QingLongYanYueDao"||name=="ZhangBaSheMao"||name=="ZhuGeLianNu"||name=="ZhuQueYuShan"){
           name="ZhuangBei";
            }
            // 输出当前正在检查的音频剪辑名称
            Debug.Log("Checking audio clip: " + audioLiaMan[i].name);

        // 检查是否相等或是否为基本名称
        if (audioLiaMan[i].name == name )
        {
            return audioLiaMan[i];
        }
    }

    Debug.LogWarning("Audio clip not found for man with name: " + name);
    return null;
    }
    public AudioClip GetGirlAudioClip(string name){
        for(int i=0;i<audioLiaGirl.Count;i++){
            if(name==audioLiaGirl[i].name){
                return audioLiaGirl[i];
            }
        }
        return null;
    }
    public void PlayAudio(string name){
        if(gender){
            audioSource.clip=GetManAudioClip(name);
            AudioClip clip = GetManAudioClip(name);
            if (clip == null)
        {
            Debug.LogError("Audio clip not found for man with name: " + name);
            return; // 提前返回
        }
        audioSource.clip = clip;
        }
        else{
            audioSource.clip=GetGirlAudioClip(name);
        }
        audioSource.Play();
    }
}
