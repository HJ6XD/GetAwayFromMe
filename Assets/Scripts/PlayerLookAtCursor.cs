using UnityEngine;

public class PlayerLookAtCursor : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Camera myCam;
    [SerializeField] GameObject playerModel;
    Vector3 mousePos;
    public float RayDefaultDistance;
    private Vector3 targetRotationPos;
    void Start()
    {
        myCam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        LookAtCursor();
    }
    private void LookAtCursor()
    {
        mousePos = Input.mousePosition;
        Ray lookAtRay = (myCam.ScreenPointToRay(mousePos));
        Vector3 hitPosition;
        if (Physics.Raycast(lookAtRay, out RaycastHit hit, RayDefaultDistance)) {
            hitPosition = hit.point;
        }
        else {
            hitPosition = lookAtRay.GetPoint(RayDefaultDistance);
        }
        targetRotationPos = hitPosition - playerModel.transform.position;
        Vector3 targetRotation = Vector3.RotateTowards(playerModel.transform.forward, targetRotationPos, rotationSpeed * Time.deltaTime, 0);

        Quaternion lookRotation = Quaternion.LookRotation(targetRotation);
        playerModel.transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
    }

    public void StopLooking()
    {
        playerModel.SetActive(false);
    }
}
