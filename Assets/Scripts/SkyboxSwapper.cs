using UnityEngine;

public class SkyboxSwapper : MonoBehaviour
{
    [Header("Skybox Materials")]
    public Material daySkybox;
    public Material snowSkybox;
    public Material stormSkybox;
    public Material sunsetSkybox;
    public Material nightSkybox;

    void Start()
    {
        if (daySkybox != null)
        {
            RenderSettings.skybox = daySkybox;
            DynamicGI.UpdateEnvironment();
        }
    }

    public void SetDay()
    {
        SwapSkybox(daySkybox);
    }

    public void SetSnow()
    {
        SwapSkybox(snowSkybox);
    }

    public void SetStorm()
    {
        SwapSkybox(stormSkybox);
    }

    public void SetSunset()
    {
        SwapSkybox(sunsetSkybox);
    }
    private void SwapSkybox(Material newSkybox)
    {
        if (newSkybox == null)
        {
            Debug.LogWarning("SkyboxSwapper: skybox material is not assigned.");
            return;
        }

        RenderSettings.skybox = newSkybox;
        DynamicGI.UpdateEnvironment();
    }
}