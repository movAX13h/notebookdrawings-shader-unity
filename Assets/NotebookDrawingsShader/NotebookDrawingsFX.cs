using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class NotebookDrawingsFX : MonoBehaviour
{
    public Texture noiseTexture;
    public bool grid = true;
    [Range(0.0f, 15.0f)]
    public float vignette = 1.0f;

    private Shader shader;
    private Material material;

    void Awake()
    {
        shader = Shader.Find("Hidden/Notebook Drawings");
        if (shader == null)
        {
            Debug.LogError("'Notebook Drawings' shader is missing!");
            return;
        }

        material = new Material(shader);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetTexture("_NoiseTex", noiseTexture);
        material.SetVector("_Features", new Vector4(grid ? 1.0f : 0.0f, vignette, 0.0f, 0.0f));

        Graphics.Blit(source, destination, material);
    }
}
