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
    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    [SerializeField] private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");

//not lerping figure out why later
    private void Start()
    {
        _dissolveAmount = Shader.PropertyToID("_DissolveAmount");
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _materials = new Material[_spriteRenderers.Length];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }
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
        Debug.Log("In Eat");
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(0, 1.1f, (elapsedTime/dissolveTime));
            if (useDissolve)
                //_material.SetFloat(_dissolveAmount, lerpedDissolve);
            
            yield return null;
        }
    }

    public IEnumerator unEat (bool useDissolve)
    {
        Debug.Log("Not Eat");
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            float lerpedDissolve = Mathf.Lerp(1.1f, 0f, (elapsedTime/dissolveTime));
            if (useDissolve)
                //_material.SetFloat(_dissolveAmount, lerpedDissolve);
            
            yield return null;
        }
    }
}
