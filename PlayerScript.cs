using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody rb;
    Vector2 cursorPos;
    GameObject modelObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        modelObject = GameObject.Find("WaveForm");
    }

    private void Update()
    {
        cursorPos = CursorPosition();
        YawRoll();
    }

    private void FixedUpdate()
    {
        float roll = Input.GetAxis("Horizontal");
        float pitch = cursorPos.y; // Mouse goes up - more we pitch.
        float yaw = cursorPos.x; // Moue goes sideways - slowly move right/left.
        float throttle = Input.GetAxis("Vertical");

        //rb.AddRelativeTorque(Vector3.back * torque * roll);
        //rb.AddRelativeTorque(Vector3.right * torque * pitch);
        //rb.AddRelativeTorque(Vector3.up * torque * yaw);
    }

    private Vector2 CursorPosition()
    {
        Vector2 cursorPosition = Input.mousePosition;
        /*
         * Get cursor position relative to middle of screen.
         * Top left of screen is pixels [0, 0]. We don't want to find the cursor relative to that point.
         * We want to find the cursor relative to the center of the screen instead.
         * We cut the screen in half and substract it, so we can find if we are left or right of the center of the screen.
         */
        cursorPosition.x -= Screen.width / 2; 
        cursorPosition.y -= Screen.height / 2;

        /*
         * Find relative value of the center of the screen.
         * Can be either max 1 or max -1 for left or right and up or down.
         */
        float cursorX = cursorPosition.x / (Screen.width / 2f);
        float cursorY = cursorPosition.y / (Screen.height / 2f);

        float deadZone = 0.05f;
        if (Mathf.Abs(cursorX) < deadZone) cursorX = 0;
        if (Mathf.Abs(cursorY) < deadZone) cursorY = 0;

        return new Vector2(cursorX, -cursorY);
    }

    private Vector3 CursorAngle()
    {
        /*
         * Find cursor angle relative to our Vector2.down.
         * If cursor is in a certain angle relative to the screen, our player should roll to match that.
         */
        Vector2 cursorAdjust = new Vector2(cursorPos.x, cursorPos.y * .25f);
        float angle = Vector2.SignedAngle(cursorAdjust, Vector2.down);
        if (cursorAdjust.x == 0) return new Vector3(0, 0, 0);
        return new Vector3(0, 0, angle / 4f); // Divide by 4 for adjustment.
    }

    private void YawRoll()
    {
        // Find out how much we shuld roll. Just change the roll (z) value, not the back and forth value.
        // Mathf.Clamp, because we dont want the z-axis to go more than 45*.
        Vector3 targetRollValue = new Vector3(0, 180, Mathf.Clamp(-CursorAngle().z, -45, 45)); // 180 becuase our player model is flipped by 180*
        // Apply the roll to the player. Immediate.
        modelObject.transform.localRotation = Quaternion.Euler(targetRollValue);
    }
}
