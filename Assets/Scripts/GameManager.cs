using UnityEngine;
using TMPro; // Do napisów
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Elementy Sceny")]
    public Pin[] pins;
    public BowlingScreen tv;
    public Transform ball;
    public Transform ballSpawnPoint; // Stojak
    public TextMeshProUGUI scoreBoardText;

    private Vector3 ballStartPos;
    private bool isResetting = false;
    
    // Zmienne logiczne
    private int throwNumber = 1; 
    private int pinsKnockedOnFirstThrow = 0;

    void Start()
    {
        if(ball) ballStartPos = ball.position;
        UpdateScore("START", 0);
    }

    public void BallEnteredPit()
    {
        if (!isResetting) StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        isResetting = true;
        
        // 1. Czekamy 3 sekundy aż fizyka się uspokoi
        yield return new WaitForSeconds(3f);

        // 2. Sprawdzamy stan kręgli
        int currentFallen = 0;
        foreach (Pin p in pins)
        {
            if (p.CheckStatus()) currentFallen++;
        }

        // --- LOGIKA RZUTÓW ---
        if (throwNumber == 1)
        {
            if (currentFallen == 10) // STRIKE!
            {
                if(tv) tv.PlayStrike();
                UpdateScore("STRIKE!", 10);
                yield return new WaitForSeconds(4f); // Czas na radość
                FullReset(); // Koniec rundy
            }
            else // Zwykły rzut, gramy dalej
            {
                if (currentFallen == 0) { if(tv) tv.PlayGutter(); }
                else { if(tv) tv.PlayNormal(); }
                
                UpdateScore("DOBITKA?", currentFallen);
                
                // Przygotowanie do 2 rzutu
                pinsKnockedOnFirstThrow = currentFallen;
                throwNumber = 2;
                
                yield return new WaitForSeconds(2f);
                
                // Ukrywamy leżące kręgle (żeby nie przeszkadzały w dobitce)
                foreach (Pin p in pins) if (p.isFallen) p.gameObject.SetActive(false);
                
                ResetBall(); // Oddajemy kulę
                isResetting = false; // Odblokowujemy grę
            }
        }
        else // Rzut numer 2
        {
            if (currentFallen == 10) // SPARE! (Dobił do 10)
            {
                if(tv) tv.PlaySpare();
                UpdateScore("SPARE!", 10);
            }
            else // Koniec bez szału (Open Frame)
            {
                int pinsHitSecondThrow = currentFallen - pinsKnockedOnFirstThrow;
                if (pinsHitSecondThrow == 0) { if(tv) tv.PlayGutter(); }
                else { if(tv) tv.PlayNormal(); }
                
                UpdateScore("KONIEC", currentFallen);
            }
            
            yield return new WaitForSeconds(4f);
            FullReset(); // Koniec rundy
        }
    }

    void FullReset()
    {
        foreach (Pin p in pins) p.ResetPin();
        ResetBall();
        throwNumber = 1;
        pinsKnockedOnFirstThrow = 0;
        UpdateScore("NOWA RUNDA", 0);
        isResetting = false;
    }

    void ResetBall()
    {
        if (ball != null)
        {
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // Jeśli mamy SpawnPoint (stojak), to tam. Jak nie, to na start.
            ball.position = (ballSpawnPoint) ? ballSpawnPoint.position : ballStartPos;
            ball.rotation = Quaternion.identity;
        }
    }

    void UpdateScore(string status, int score)
    {
        if (scoreBoardText != null)
            scoreBoardText.text = $"{status}\nPUNKTY: {score}";
    }
}