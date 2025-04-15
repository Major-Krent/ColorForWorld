using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;

[ExecuteInEditMode]
public class InvertCircleController : MonoBehaviour
{
    public Material invertMaterial;
    public float expandSpeed = 1.0f;
    public Transform circleCenterObject;
    private bool isExpanding = false;
    private float radius = 0.0f;
    private Vector2 center;
    private bool isInverted = false;
    [SerializeField] private bool canChange;
    [SerializeField] private int defenseCooldown;

    public bool isColor()
    {
        return isInverted;
    }

    void Start()
    {
        if (circleCenterObject != null)
        {
            center = Camera.main.WorldToViewportPoint(circleCenterObject.position);
            invertMaterial.SetVector("_Center", center);
            invertMaterial.SetFloat("_IsInverted", 0.0f); // First not Invert
        }
        else
        {
            Debug.LogError("Circle center object not assigned.");
        }

        canChange = true;
    }

    void Update()
    {
        startChange();

    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (invertMaterial != null)
        {
            Graphics.Blit(source, destination, invertMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    public void Change()
    {
        if (circleCenterObject != null && canChange)
        {
            isInverted = !isInverted;
            isExpanding = true;
            radius = 0.0f;

        }
    }

    public void startChange()
    {
        invertMaterial.SetFloat("_IsInverted", isInverted ? 1.0f : 0.0f); // InvertSituation
        if (isExpanding)
        {
            radius += expandSpeed * Time.deltaTime;
            invertMaterial.SetFloat("_Radius", radius);

            if (radius >= 1.5f) // stopExpending
            {
                isExpanding = false;
            }
        }
    }
}