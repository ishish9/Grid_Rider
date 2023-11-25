using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    public float scrollSpeedX;
    public float scrollSpeedY;
    private MeshRenderer meshRenderer;
    [SerializeField] private LevelSpeed levelSpeed;
    [SerializeField] private bool UseScriptableObject;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (UseScriptableObject)
        {
            meshRenderer.material.mainTextureOffset = new Vector2(Time.realtimeSinceStartup * levelSpeed.TextureScrollSpeed_x, Time.realtimeSinceStartup * levelSpeed.TextureScrollSpeed_y);
        }
        else
        {
            meshRenderer.material.mainTextureOffset = new Vector2(scrollSpeedX * Time.realtimeSinceStartup, scrollSpeedY * Time.realtimeSinceStartup);
        }
    }
}
