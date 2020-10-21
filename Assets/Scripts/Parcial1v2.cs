using UnityEngine;

public class Parcial1v2 : MonoBehaviour
{
    // When added to an object, draws colored rays from the
    // transform position.
    public int lineCount = 100;
    public float radius = 3.0f;
    float rot = 0;

    static Material lineMaterial;
    static void CreateLineMaterial()
    {
        if (!lineMaterial)
        {
            // Unity has a built-in shader that is useful for drawing
            // simple colored things.
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.hideFlags = HideFlags.HideAndDontSave;
            // Turn on alpha blending
            lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            // Turn backface culling off
            lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
            // Turn off depth writes
            lineMaterial.SetInt("_ZWrite", 0);
        }
    }

    // Will be called after all regular rendering is done
    public void OnRenderObject()
    {
        CreateLineMaterial();
        // Apply the line material
        lineMaterial.SetPass(0);

        GL.PushMatrix();
        // Set transformation matrix for drawing to
        // match our transform
        GL.MultMatrix(transform.localToWorldMatrix);
        transform.Rotate(0, 0.3f, 0);


        // Draw lines
        GL.Begin(GL.QUADS);
        GL.Color(new Color(1, 0 , 0, 0.8F));
        // Color Blue
        GL.Vertex3(1.0f, 1.0f, -1.0f);  // Top Right Of The Quad (Top)
        GL.Vertex3(-1.0f, 1.0f, -1.0f); // Top Left Of The Quad (Top)
        GL.Vertex3(-1.0f, 1.0f, 1.0f);  // Bottom Left Of The Quad (Top)
        GL.Vertex3(1.0f, 1.0f, 1.0f);   // Bottom Right Of The Quad (Top)
        // Color Orange
        GL.Vertex3(1.0f, -1.0f, 1.0f);  // Top Right Of The Quad (Bottom)
        GL.Vertex3(-1.0f, -1.0f, 1.0f); // Top Left Of The Quad (Bottom)
        GL.Vertex3(-1.0f, -1.0f, -1.0f);    // Bottom Left Of The Quad (Bottom)
        GL.Vertex3(1.0f, -1.0f, -1.0f); // Bottom Right Of The Quad (Bottom)
        // Color Red	
        GL.Vertex3(1.0f, 1.0f, 1.0f);   // Top Right Of The Quad (Front)
        GL.Vertex3(-1.0f, 1.0f, 1.0f);  // Top Left Of The Quad (Front)
        GL.Vertex3(-1.0f, -1.0f, 1.0f); // Bottom Left Of The Quad (Front)
        GL.Vertex3(1.0f, -1.0f, 1.0f);  // Bottom Right Of The Quad (Front)
        // Color Yellow
        GL.Vertex3(1.0f, -1.0f, -1.0f); // Top Right Of The Quad (Back)
        GL.Vertex3(-1.0f, -1.0f, -1.0f);    // Top Left Of The Quad (Back)
        GL.Vertex3(-1.0f, 1.0f, -1.0f); // Bottom Left Of The Quad (Back)
        GL.Vertex3(1.0f, 1.0f, -1.0f);  // Bottom Right Of The Quad (Back)
        // Color Blue
        GL.Vertex3(-1.0f, 1.0f, 1.0f);  // Top Right Of The Quad (Left)
        GL.Vertex3(-1.0f, 1.0f, -1.0f); // Top Left Of The Quad (Left)
        GL.Vertex3(-1.0f, -1.0f, -1.0f);    // Bottom Left Of The Quad (Left)
        GL.Vertex3(-1.0f, -1.0f, 1.0f); // Bottom Right Of The Quad (Left)
        // Color Violet
        GL.Vertex3(1.0f, 1.0f, -1.0f);  // Top Right Of The Quad (Right)
        GL.Vertex3(1.0f, 1.0f, 1.0f);   // Top Left Of The Quad (Right)
        GL.Vertex3(1.0f, -1.0f, 1.0f);  // Bottom Left Of The Quad (Right)
        GL.Vertex3(1.0f, -1.0f, -1.0f);
        
        GL.End();
        GL.PopMatrix();
        rot += 0.03f;
    }
}