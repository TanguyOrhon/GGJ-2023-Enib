using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingEndScene : MonoBehaviour
{
    // Start is called before the first frame update
    public LoadSpecificScene changeScene;
    public void OnClick()
    {
        changeScene.OnClick();
    }

}
