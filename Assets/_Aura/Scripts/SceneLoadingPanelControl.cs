using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class SceneLoadingPanelControl : MonoBehaviour
{
    float progress = 0f;
   public void loadSCeneByLabel(string labelOfScene)
    {
         Addressables.LoadSceneAsync(labelOfScene, LoadSceneMode.Single).Completed += SceneLoadingPanelControl_Completed;
         progress += Addressables.LoadSceneAsync(labelOfScene, LoadSceneMode.Single).PercentComplete;
        UtilityPanelControl.Instance.PrintInfo("Progress: "+ progress);
    }

    private void SceneLoadingPanelControl_Completed(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        //check if obj.Result property is null or not
        if(obj.Status == AsyncOperationStatus.Succeeded)
        {
            UtilityPanelControl.Instance.PrintInfo(obj.Result.Scene.name);
            SceneInstance sceneToLoad = obj.Result;
            sceneToLoad.ActivateAsync();
        }
        else if(obj.Status == AsyncOperationStatus.Failed)
        {
            UtilityPanelControl.Instance.PrintInfo("Status Failed..");
        }
        else if(obj.Status == AsyncOperationStatus.None)
        {
            UtilityPanelControl.Instance.PrintInfo("Ongoing");
        }
    }
}
