using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    enum VirtualCameras
    {
        CockpitCamera = 0,
        FollowCamera,
        NoCamera = -1
    }

    [SerializeField]
    List<GameObject> _virtualCameras;

    [SerializeField]
    AudioClip switchSoundEffect;

    AudioSource audioSource;

    VirtualCameras CameraKeyPressed
    {
        get
        {
            for (int i = 0; i < _virtualCameras.Count; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)) return (VirtualCameras)i;
            }
            return VirtualCameras.NoCamera;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetActiveCamera(VirtualCameras.CockpitCamera);
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        VirtualCameras newCamera = CameraKeyPressed;
        if (newCamera != VirtualCameras.NoCamera)
        {
            SetActiveCamera(newCamera);
            PlaySwitchSoundEffect();
        }
    }

    void SetActiveCamera(VirtualCameras activeCamera)
    {
        if (activeCamera == VirtualCameras.NoCamera)
        {
            Debug.Log("NoCamera");
            return;
        }

        Debug.Log($"Switching to {activeCamera.ToString()} camera");
        foreach (GameObject cam in _virtualCameras)
        {
            cam.SetActive(cam.tag.Equals(activeCamera.ToString()));
        }
    }

    void PlaySwitchSoundEffect()
    {
        if (switchSoundEffect != null)
        {
            audioSource.PlayOneShot(switchSoundEffect);
        }
    }
}
