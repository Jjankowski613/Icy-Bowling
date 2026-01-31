using UnityEngine;

public class Pin : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;
    private Rigidbody rb;
    private AudioSource audioS;
    
    [Header("Ustawienia")]
    public AudioClip hitSound; // Dźwięk uderzenia
    public bool isFallen = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
        
        audioS = GetComponent<AudioSource>();
        // Zabezpieczenie: jak zapomnisz dodać AudioSource w inspektorze
        if(!audioS) audioS = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision c)
    {
        // Graj dźwięk tylko przy mocniejszym uderzeniu (żeby nie hałasował przy drganiu)
        if (c.relativeVelocity.magnitude > 0.5f && hitSound)
        {
            if (!audioS.isPlaying) audioS.PlayOneShot(hitSound);
        }
    }

    public bool CheckStatus()
    {
        // Kręgiel leży, jeśli jest przechylony > 10 stopni LUB przesunięty
        if (Vector3.Angle(Vector3.up, transform.up) > 10f || Vector3.Distance(startPos, transform.position) > 0.1f)
        {
            isFallen = true;
            return true;
        }
        return false;
    }

    public void ResetPin()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPos;
        transform.rotation = startRot;
        isFallen = false;
        gameObject.SetActive(true);
    }
}