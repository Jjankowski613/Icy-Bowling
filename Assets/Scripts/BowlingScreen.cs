using UnityEngine;
using UnityEngine.Video;

public class BowlingScreen : MonoBehaviour
{
    private VideoPlayer vp;

    [Header("Listy Klipów (MP4)")]
    public VideoClip idleLoop;      // Tło (pętla)
    public VideoClip[] strikeClips; // 10 pkt w 1. rzucie
    public VideoClip[] spareClips;  // Dobicie do 10 w 2. rzucie
    public VideoClip[] normalClips; // 1-9 pkt
    public VideoClip[] gutterClips; // 0 pkt

    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        if(!vp) vp = gameObject.AddComponent<VideoPlayer>();
        
        vp.renderMode = VideoRenderMode.MaterialOverride;
        vp.loopPointReached += OnVideoEnd;
        
        PlayIdle();
    }

    public void PlayIdle() { PlayClip(idleLoop, true); }
    public void PlayStrike() { PlayRandom(strikeClips); }
    public void PlaySpare() { PlayRandom(spareClips); }
    public void PlayNormal() { PlayRandom(normalClips); }
    public void PlayGutter() { PlayRandom(gutterClips); }

    void PlayRandom(VideoClip[] c)
    {
        if (c != null && c.Length > 0)
            PlayClip(c[Random.Range(0, c.Length)], false);
    }

    void PlayClip(VideoClip c, bool loop)
    {
        if(c)
        {
            vp.clip = c;
            vp.isLooping = loop;
            vp.Play();
        }
    }

    void OnVideoEnd(VideoPlayer s)
    {
        // Jeśli skończył się filmik (nie pętla), wróć do Idle
        if (!s.isLooping) PlayIdle();
    }
}