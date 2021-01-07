using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoadButton : Button
{
    public string TargetSceneName {
        get =>  _targetSceneName;
        set => _targetSceneName = value;
     }
    [SerializeField]
    string _targetSceneName;

    protected override void Awake() {
        base.Awake();
        this.onClick.AddListener(() => {
            SceneManager.LoadSceneAsync(_targetSceneName);
        });
    }

}
