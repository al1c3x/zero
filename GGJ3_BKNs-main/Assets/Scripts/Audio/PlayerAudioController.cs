using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    private IDictionary<string, string> playerSFX = new Dictionary<string, string>();
    private float minRange = 5;
    private float maxRange = 20;
    private float maxDelta;
    private float groanRandom;
    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerSFX.Add("Slash1", "ClawSlash1");
        playerSFX.Add("Slash2", "ClawSlash2");
        playerSFX.Add("Groan1", "Groan1");
        playerSFX.Add("Groan2", "Groan2");

        maxDelta = Random.Range(minRange, maxRange);
        groanRandom = Random.Range(0, 10);
    }

    public void PlayAttack()
    {
        float rndm = Random.Range(0, 10);

        if (rndm >= 5)
            tAudioManager.instance.playSFXByName(playerSFX["Slash1"], this.transform);
        else if (rndm < 5)
            tAudioManager.instance.playSFXByName(playerSFX["Slash2"], this.transform);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxDelta)
        {
            if (groanRandom >= 5)
                tAudioManager.instance.playSFXByName(playerSFX["Groan1"], this.transform);
            else if (groanRandom < 5)
                tAudioManager.instance.playSFXByName(playerSFX["Groan2"], this.transform);

            maxDelta = Random.Range(minRange, maxRange);
            groanRandom = Random.Range(0, 10);
            currentTime = 0.0f;
        }
    }
}
