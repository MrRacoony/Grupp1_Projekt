//using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
//using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class fadeMaterial : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform child;
    public float fade;
    [SerializeField] private float fadeTimer;
    void Start()
    {
        //child = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            fade += Time.deltaTime;
            if (fade > 1)
            {
                fade = 1;
            }
        }
        else
        {
            fade -= Time.deltaTime;
            if (fade < 0)
            {
                fade = 0;
            }
        }
        GetComponent<Image>().material.SetFloat("_Fade", fade); // Adjust glossiness


    }
    public static void FadeIn()
    {

    }
    public static void FadeOut()
    { 
    }
}