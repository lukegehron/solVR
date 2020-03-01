using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Material_Modification_AT : MonoBehaviour

{
    //for tint color control
    public Material glassMaterial;
    public Slider tintColorSlider; 
    private Color tintColor;

    
    //for sun light
    public Light sunLight;
    private float shadowBias;

    //for frit on/off control
    public Button fritOnOff;
    public GameObject fritPanels;
    private bool fritToggle = false; 

    //for frit scaling control
    public Slider fritScaleSlider;
    public Material fritGlassMat;
    private Vector2 fritScale;

    public GameObject[] sliders;

    public static float wHeight = 0.0f;
    public static float wWidth = 0.0f;
    public static float horz = 0.0f;
    public static float vert = 0.0f;


    public static float[] mFloats = new float[4];


    void Start()
    {

        mFloats[0] = 0.0f;
        mFloats[1] = 0.0f;
        mFloats[2] = 0.0f;
        mFloats[3] = 0.0f;

        //trigger the buttonClicked function whenever the button is clicked 
        //fritOnOff.onClick.AddListener(buttonClicked);
        //grab the current color of the glass material
        tintColor = glassMaterial.color;
        fritScale = glassMaterial.GetTextureScale("_BaseMap");
        //grab the shadow Bias Depth value
        shadowBias = sunLight.shadowBias;
    }



    void Update()
    {
        //grab the alpha channel of the glass material color and assign the slider value to it.
        float currentPos = (sliders[0].transform.position.y - 1.06f) * 2.0f;
        //tintColor.a = tintColorSlider.value;
        tintColor.a = currentPos;

        //sets the modified color value back to the glass material 
        glassMaterial.SetColor("_BaseColor", tintColor);

        //convert the value to 1 to 0 with absolute value and assign back to Depth Bias

        //shadowBias = Mathf.Abs(tintColorSlider.value-1);
        shadowBias = Mathf.Abs(currentPos - 1);
        sunLight.shadowBias = shadowBias;

        //creates a new vector2 for scaling using the fritScaleSlider value
        currentPos = (sliders[1].transform.position.y - 1.06f) * 2.0f;
        Debug.Log("Your current pos" + currentPos);
        //Vector2 newFritScale = new Vector2(fritScale.x*fritScaleSlider.value, fritScale.y*fritScaleSlider.value);
        Vector2 newFritScale = new Vector2(fritScale.x * currentPos, fritScale.y * currentPos);
        //assigns the new fritscale to the main texture of the GlassFirt Material
        fritGlassMat.SetTextureScale("_BaseMap", newFritScale);


        float mFloatWindowHeight = GHLoader.mFloats[0];
        float mFloatWindowWidth = GHLoader.mFloats[1];
        float mFloatVertical = GHLoader.mFloats[2];
        float mFloatHorizontal= GHLoader.mFloats[3];


        float wHeight = (sliders[2].transform.position.y - 1.06f) * 2.0f;
        mFloats[0] = wHeight;
        GHLoader.mFloats[0] = wHeight;
        float wWidth = (sliders[3].transform.position.y - 1.06f) * 2.0f;
        mFloats[1] = wWidth;
        GHLoader.mFloats[1] = wWidth;
        float horz = (sliders[4].transform.position.y - 1.06f) * 2.0f;
        GHLoader.mFloats[2] = horz;
        mFloats[2] = horz;
        float vert = (sliders[5].transform.position.y - 1.06f) * 2.0f;
        mFloats[3] = vert;
        GHLoader.mFloats[3] = vert;






    }


    public void buttonClicked()
    {
        fritToggle = !fritToggle;

        fritPanels.SetActive(fritToggle);
    }

}