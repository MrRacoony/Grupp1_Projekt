using NUnit.Framework;
using System.Collections.Generic;
using System;
using Unity.Mathematics;
using UnityEngine;

public class WorldInteractable : MonoBehaviour
{

    [SerializeField] private List<GameObject> layersToOpen;
    [SerializeField] private List<GameObject> layersToClose;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseOver()
    {
        transform.parent.transform.localScale = Vector3.one * 1.1f;
    }

    private void OnMouseExit()
    {
        transform.parent.transform.localScale = Vector3.one;
    }

    private void OnMouseDown() {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        transform.parent.transform.localScale = Vector3.one;
        
        for(int i=0; i<layersToOpen.Count; i++) {
            layersToOpen[i].SetActive(true);
        }
        for(int i=0; i<layersToClose.Count; i++) {
            layersToClose[i].SetActive(false);
        }
    }
    
    public void CloseLayer() {
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        for(int i=0; i<layersToOpen.Count; i++) {
            layersToOpen[i].SetActive(false);
        }
        for(int i=0; i<layersToClose.Count; i++) {
            layersToClose[i].SetActive(true);
        }
    }

}
