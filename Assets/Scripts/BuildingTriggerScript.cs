using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTriggerScript : MonoBehaviour
{
    public List<GameObject> toDisappear;
    public GameObject floor;

    private int isIn = 0;
    public void PlayerEnter()
    {
        Debug.Log("enter");
        isIn++;
        Debug.Log(isIn);
        if (isIn != 1)
            return;
        floor.layer = 9; // Changing layer to the "Ground" so that player can aim with mouse on it
        foreach (GameObject obj in toDisappear)
        {
            MeshRenderer[] meshes = obj.GetComponentsInChildren<MeshRenderer>();
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }

            foreach (MeshRenderer mesh in meshes)
            {
                mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
        }
    }

    public void PlayerExit()
    {
        Debug.Log("exit");
        isIn--;
        Debug.Log(isIn);
        if (isIn != 0)
            return;
        floor.layer = 0;
        foreach (GameObject obj in toDisappear)
        {
            MeshRenderer[] meshes = obj.GetComponentsInChildren<MeshRenderer>();
            MeshRenderer meshRenderer = obj.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }

            foreach(MeshRenderer mesh in meshes)
            {
                mesh.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            }
        }
    }
}
