using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float dissolveTime = 0.5f;
    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    //now set to urmom, the actual id doesnt work??
    private int _dissolveAmount = Shader.PropertyToID("_urmom");
    private int _mainTex = Shader.PropertyToID("_mainTex");
    [SerializeField] private float newDissolveAmount;
    [SerializeField] private float oldDissovleAmount;


//not lerping figure out why later
    private void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        _materials = new Material[_spriteRenderers.Length];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;

            Texture2D spriteTexture = _spriteRenderers[i].sprite.texture;
            _materials[i].SetTexture("_mainTex", spriteTexture);
        }
    }

    void Update()
    {
        oldDissovleAmount = newDissolveAmount;
        int currentBuns = GetComponentInChildren<EatingScript>().currentBuns;
        int destroyTreshold = GetComponentInChildren<EatingScript>().destroyTreshold;
        newDissolveAmount = (float)currentBuns/(float)destroyTreshold;
        StartCoroutine(EatItem(true));
    }

    public IEnumerator EatItem (bool useDissolve)
    {
        Debug.Log("In Eat");
        float elapsedTime = 0f;
        while (elapsedTime < dissolveTime)
        {
            elapsedTime += Time.deltaTime;

            //float lerpedDissolve = Mathf.Lerp(0, 1.1f, (elapsedTime/dissolveTime));
            float lerpedDissolve = Mathf.Lerp(oldDissovleAmount, newDissolveAmount, (elapsedTime/dissolveTime));

            for (int i = 0; i < _materials.Length; i++)
            {
                if (useDissolve)
                {
                    _materials[i].SetFloat(_dissolveAmount, lerpedDissolve);
                }
            }
            
            
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

            //float lerpedDissolve = Mathf.Lerp(1.1f, 0f, (elapsedTime/dissolveTime));
            float lerpedDissolve = Mathf.Lerp(newDissolveAmount, 0f, (elapsedTime/dissolveTime));

            for (int i = 0; i < _materials.Length; i++)
            {
                if (useDissolve)
                {
                    _materials[i].SetFloat(_dissolveAmount, lerpedDissolve);
                }
            }
            
            yield return null;
        }
    }
}
