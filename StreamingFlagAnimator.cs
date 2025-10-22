using UnityEngine;
using ModTool.Interface;

public class StreamingFlagAnimator : ModBehaviour
{
    [Header("Assign your flag textures here in order")]
    public Texture2D[] flagFrames; // Drag all PNG frames into the inspector

    [Header("Animation Settings")]
    public float framesPerSecond = 30f; // Adjust speed

    private Renderer flagRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        flagRenderer = GetComponent<Renderer>();
        if (flagFrames == null || flagFrames.Length == 0)
        {
            Debug.LogWarning("No flag frames assigned!");
            enabled = false; // stop script if nothing assigned
            return;
        }

        // Initialize first frame
        flagRenderer.material.mainTexture = flagFrames[0];
    }

    void Update()
    {
        if (flagFrames.Length <= 1) return;

        timer += Time.deltaTime;
        float frameTime = 1f / framesPerSecond;

        if (timer >= frameTime)
        {
            timer -= frameTime;
            currentFrame = (currentFrame + 1) % flagFrames.Length;
            flagRenderer.material.mainTexture = flagFrames[currentFrame];
        }
    }
}
