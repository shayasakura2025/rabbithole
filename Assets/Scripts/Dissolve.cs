using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float dissolveTime = 0.75f;
    private SpriteRenderer _spriteRenderer;
    private Material _material;
    [SerializeField] private int _disolveAmount = Shader.PropertyToID("_DissolveAmount");

//not lerping figure out why later
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material = new Material(_spriteRenderer.material);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(EatItem(true));
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(unEat(true));
        }
    }

    public IEnumerator EatItem (bool useDissolve)
    {
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0, 1.1f, (elapsedTime/dissolveTime));
            if (useDissolve)
                _material.SetFloat(_disolveAmount, lerpedDissolve);
            
            yield return null;
        }
    }

    public IEnumerator unEat (bool useDissolve)
    {
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(1.1f, 0f, (elapsedTime/dissolveTime));
            if (useDissolve)
                _material.SetFloat(_disolveAmount, lerpedDissolve);
            
            yield return null;
        }
    }
}
