using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// an example 
/// </summary>

public class Math3DTest : MonoBehaviour
{
    public Transform testCube1;
    public Transform testCube2;
    public Transform testCubeNormal;
    public Transform testCubeOutput;
    
    [Header("Vector Length")]
    [Range(0.1f, 10)]
    public float size = 1;

    #region Realtime Function Calls

    void Update()
    {
        //SetVectorLength();
        AddRotation();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }

    #endregion


    #region Static Function Calls
    void SetVectorLength()
    {
        Vector3 testVector3 = testCube1.localScale;

        Vector3 newSize = Math3D.SetVectorLength(testVector3, size);
        
        testCube1.localScale = new Vector3(newSize.x, newSize.y, newSize.z);
    }

    void AddRotation()
    {
        
        testCubeOutput.rotation = Math3D.AddRotation(testCube1.rotation, testCube2.rotation);

        testCubeOutput.eulerAngles = Math3D.TransformDirectionMath(testCube1.rotation, testCube2.position*size);
    }
    #endregion    
    

}
