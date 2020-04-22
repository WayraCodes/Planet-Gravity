using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController_Script : MonoBehaviour
{
    // Death PostP
    public PostProcessVolume PostVolume;
    private DepthOfField depthOfField;

    // References
    GameController_Script GameScript;

    private void Start()
    {
        PostVolume.profile.TryGetSettings(out depthOfField);
        GameScript = FindObjectOfType<GameController_Script>();
    }

    private void Update()
    {
        if (GameScript.IsPlayerDead == true)
        {
            depthOfField.focusDistance.value = 0.1f;
        }
    }
}
