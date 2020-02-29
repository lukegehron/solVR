using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Material_Modification_AT : MonoBehaviour

{
    //grab the glass material assigned in the editor
    public Material glassMaterial;
    
    //this slider will control the alpha channel values of the original color tint for the glass material 
    public Slider tintColorSlider;

    //this will store the color tint value of the glass material
    private Color tintColor;

    public Button fritOnOff;
    public Slider fritScaleSlider;

    private float fritScale;

    void Start()
    {
        //grab the current color of the glass material
        tintColor = glassMaterial.color;
    }


    void Update()
    {
        //grab the alpha channel of the glass material color and assign the slider value to it.
        tintColor.a = tintColorSlider.value;

        //sets the modified color value back to the glass material 
        glassMaterial.SetColor("_BaseColor", tintColor);
    }
}