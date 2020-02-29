﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_Modification_AT : MonoBehaviour

{
    //for tint color control
    public Material glassMaterial;
    public Slider tintColorSlider; 
    private Color tintColor;


    //for frit on/off control
    public Button fritOnOff;
    public GameObject fritPanels;
    private bool fritToggle = false; 

    //for frit scaling control
    public Slider fritScaleSlider;
    public Material fritGlassMat;
    private Vector2 fritScale;
    


    void Start()
    {
        fritOnOff.onClick.AddListener(buttonClicked);
        //grab the current color of the glass material
        tintColor = glassMaterial.color;
        fritScale = glassMaterial.GetTextureScale("_BaseMap");
        
    }



    void Update()
    {
        //grab the alpha channel of the glass material color and assign the slider value to it.
        tintColor.a = tintColorSlider.value;

        //sets the modified color value back to the glass material 
        glassMaterial.SetColor("_BaseColor", tintColor);


        //creates a new vector2 for scaling using the fritScaleSlider value
        Vector2 newFritScale = new Vector2(fritScale.x*fritScaleSlider.value, fritScale.y*fritScaleSlider.value);
        //assigns the new fritscale to the main texture of the GlassFirt Material
        fritGlassMat.SetTextureScale("_BaseMap", newFritScale);
        
    }


    public void buttonClicked()
    {
        fritToggle = !fritToggle;

        fritPanels.SetActive(fritToggle);
    }

}