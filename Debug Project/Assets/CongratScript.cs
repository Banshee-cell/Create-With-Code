using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay;

    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;

    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        RotatingSpeed = 1.0f;

        // ✅ Initialize the list before using it
        TextToDisplay = new List<string>();

        TextToDisplay.Add("Congratulations");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;

            CurrentText++;

            // ✅ Loop correctly through all text
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            }

            Text.text = TextToDisplay[CurrentText];
        }
    }
}
