using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncenseLit : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Collider col;
    private Color originalColor;
    private Color targetColor = Color.yellow;
    private float lerpDuration = 3f;
    private float lerpTime = 0f;
    private bool isLerping = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        if (meshRenderer != null)
        {
            originalColor = meshRenderer.material.color;
            Debug.Log("get the color!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!isLerping)
        {
            isLerping = true;
            lerpTime = 0f;
        }
    }

    void Update()
    {
        if (isLerping)
        {
            Debug.Log("Incense lit!!");
            lerpTime += Time.deltaTime;
            float lerpProgress = lerpTime / lerpDuration;


            meshRenderer.material.color = Color.Lerp(originalColor, targetColor, lerpProgress);

            if (lerpTime >= lerpDuration)
            {
                isLerping = false;
            }
        }
    }
}
