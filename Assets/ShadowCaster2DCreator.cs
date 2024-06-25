using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;

#if UNITY_EDITOR

[RequireComponent(typeof(CompositeCollider2D))]
public class ShadowCaster2DCreator : MonoBehaviour
{
    [SerializeField]
    private bool selfShadows = true;

    private CompositeCollider2D tilemapCollider;

    static readonly FieldInfo meshField = typeof(ShadowCaster2D).GetField("m_Mesh", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly FieldInfo shapePathField = typeof(ShadowCaster2D).GetField("m_ShapePath", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly FieldInfo shapePathHashField = typeof(ShadowCaster2D).GetField("m_ShapePathHash", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly MethodInfo generateShadowMeshMethod = typeof(ShadowCaster2D)
                                    .Assembly
                                    .GetType("UnityEngine.Rendering.Universal.ShadowUtility")
                                    .GetMethod("GenerateShadowMesh", BindingFlags.Public | BindingFlags.Static);

    public void Create()
    {
        DestroyOldShadowCasters();
        tilemapCollider = GetComponent<CompositeCollider2D>();

        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            CreateShadowCaster(i);
        }
    }

    private void CreateShadowCaster(int index)
    {
        Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(index)];
        tilemapCollider.GetPath(index, pathVertices);
        GameObject shadowCaster = new GameObject($"shadow_caster_{index}");
        shadowCaster.transform.parent = transform;

        ShadowCaster2D shadowCasterComponent = shadowCaster.AddComponent<ShadowCaster2D>();
        shadowCasterComponent.selfShadows = selfShadows;

        Vector3[] pathVertices3D = pathVertices.Select(v => (Vector3)v).ToArray();

        shapePathField.SetValue(shadowCasterComponent, pathVertices3D);
        shapePathHashField.SetValue(shadowCasterComponent, Random.Range(int.MinValue, int.MaxValue));
        meshField.SetValue(shadowCasterComponent, new Mesh());

        generateShadowMeshMethod.Invoke(shadowCasterComponent, new object[] { meshField.GetValue(shadowCasterComponent), shapePathField.GetValue(shadowCasterComponent) });
    }

    public void DestroyOldShadowCasters()
    {
        var shadowCasters = transform.Cast<Transform>().Where(t => t.name.StartsWith("shadow_caster_")).ToList();
        foreach (var child in shadowCasters)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}

[CustomEditor(typeof(ShadowCaster2DCreator))]
public class ShadowCaster2DCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ShadowCaster2DCreator creator = (ShadowCaster2DCreator)target;

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Create"))
        {
            creator.Create();
        }

        if (GUILayout.Button("Remove Shadows"))
        {
            creator.DestroyOldShadowCasters();
        }
        EditorGUILayout.EndHorizontal();
    }
}

#endif
