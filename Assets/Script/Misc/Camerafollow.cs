using UnityEngine;

public class Camerafollow {
    
    public float dampingSpeed;
    public float SmoothingSpeed;

    private GameObject target;

    public Camerafollow(GameObject FollowTarget)
    {
        target = FollowTarget;
    }

    public void CamFollowUpdateProcess()
    {
        
    }
}   