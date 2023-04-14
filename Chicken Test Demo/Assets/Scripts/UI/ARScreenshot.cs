using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ARScreenshot : MonoBehaviour
{
    public Button captureButton;
    public string screenshotPath;

    private Camera AR_Camera;

    private void Start()
    {
        // Find the AR camera in the scene
        AR_Camera = FindObjectOfType<Camera>();

        // Attach a click event to the capture button
        captureButton.onClick.AddListener(Capture);
    }

    public void Capture()
    {   
        // Taking Width and Height of the camera
        int screenshotWidth = AR_Camera.pixelWidth;
        int screenshotHeight = AR_Camera.pixelHeight;

        // Set the file name and path for the screenshot
        string filename = "Screenshot_" + System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";
        string path = Path.Combine(Application.persistentDataPath, screenshotPath, filename);

        // Capture the screenshot without UI
        RenderTexture renderTexture = new RenderTexture(screenshotWidth, screenshotHeight, 24);
        AR_Camera.targetTexture = renderTexture;
        AR_Camera.Render();
        RenderTexture.active = renderTexture;
        Texture2D screenshot = new Texture2D(screenshotWidth, screenshotHeight, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, screenshotWidth, screenshotHeight), 0, 0);
        screenshot.Apply();

        // Clean up the temporary objects
        AR_Camera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Save the screenshot to disk
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(path, bytes);

        // Log the path to the console
        Debug.Log("Screenshot saved to: " + path);
    }
}