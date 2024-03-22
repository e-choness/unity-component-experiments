using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CongratulationScript : MonoBehaviour
{
    [SerializeField] private TextMesh congratulationText;
    [SerializeField] private ParticleSystem sparksParticles;
    
    [SerializeField] private float rotatingSpeed = 90.0f;
    [SerializeField] private float timeToNextText = 1.5f;

    private readonly List<string> _textToDisplay = new(){"Congratulations!", "All Errors Fixed!"};
    
    private int _current;
    
    // Start is called before the first frame update
    private void Start()
    {
        congratulationText.text = _textToDisplay.FirstOrDefault();
        InvokeRepeating(nameof(DisplayText), 0.0f,timeToNextText);
    }

    // Update is called once per frame
    private void Update()
    {
        RotateText();
    }
    
    private void RotateText()
    {
        transform.Rotate(Vector3.down * (rotatingSpeed * Time.deltaTime));
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DisplayText));
    }

    private void DisplayText()
    {
        _current %= _textToDisplay.Count;
        congratulationText.text = _textToDisplay[_current];
        sparksParticles.Play();
        _current++;
    }
}