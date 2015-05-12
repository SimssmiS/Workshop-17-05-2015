using UnityEditor;
using System.Collections;
using UnityEngine;

public class RigidbodyDebugWindow : EditorWindow
{
    private GameObject debugGameobject;
    private Rigidbody debugRigidbody;
    
    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/RigidbodyDebugWindow")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(RigidbodyDebugWindow));
    }

    void OnGUI()
    {
        GUILayout.Label("Rigidbody Information", EditorStyles.boldLabel);
        debugGameobject = Selection.activeGameObject;
        try
        {
            debugRigidbody = debugGameobject.rigidbody;
        }
        catch (System.Exception)
        {
            
        }
        GUILayout.Space(10);
        if (debugRigidbody == null)
        {
            GUILayout.Label("NO RIDGIDBODY SELECTED", EditorStyles.boldLabel);
        }
        else
        {
            GUILayout.Label("Velocity", EditorStyles.boldLabel);
            GUILayout.Label(string.Format("X: {0}", debugRigidbody.velocity.x));
            GUILayout.Label(string.Format("Y: {0}", debugRigidbody.velocity.y));
            GUILayout.Label(string.Format("Z: {0}", debugRigidbody.velocity.z));
            GUILayout.Space(4);
            GUILayout.Label("AngularVelocity", EditorStyles.boldLabel);
            GUILayout.Label(string.Format("X: {0}", debugRigidbody.angularVelocity.x));
            GUILayout.Label(string.Format("Y: {0}", debugRigidbody.angularVelocity.y));
            GUILayout.Label(string.Format("Z: {0}", debugRigidbody.angularVelocity.z));
        }

    }

    void Update()
    {
        Repaint();
    }
}
