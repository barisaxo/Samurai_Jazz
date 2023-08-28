using UnityEngine;

public class Cam
{
    #region INSTANCE
    private Cam()
    {
        _ = Camera;
        _ = AudioListener;
    }

    public static Cam Io => Instance.Io;

    private class Instance
    {
        static Instance() { }
        static Cam _io;
        internal static Cam Io => _io ??= new Cam();
        internal static void Destruct() => _io = null;
    }

    public void SelfDestruct()
    {
        Object.Destroy(_cam.gameObject);
        Instance.Destruct();
    }
    #endregion INSTANCE

    public static float OrthoX => Io.Camera.orthographicSize * Io.Camera.aspect;
    public static float OrthoY => Io.Camera.orthographicSize;

    private Camera _cam;
    public Camera Camera
    {
        get
        {
            return _cam != null ? _cam : _cam = SetUpCam();
            static Camera SetUpCam()
            {
                Camera c = Object.FindObjectOfType<Camera>() != null ? Object.FindObjectOfType<Camera>() :
                    new GameObject(nameof(Camera)).AddComponent<Camera>();
                Object.DontDestroyOnLoad(c);
                c.orthographicSize = 5;
                c.orthographic = false;
                c.transform.position = Vector3.back * 10;
                c.backgroundColor = new Color(Random.Range(.9f, 1f), Random.Range(.8f, 1f), Random.Range(.85f, 1f));

                //SetObliqueness(1, 2);
                //void SetObliqueness(float horizObl, float vertObl)
                //{
                //    Matrix4x4 mat = c.projectionMatrix;
                //    mat[0, 2] = horizObl;
                //    mat[1, 2] = vertObl;
                //    c.projectionMatrix = mat;
                //https://docs.unity3d.com/Manual/ObliqueFrustum.html
                //}

                return c;
            }
        }
    }

    private AudioListener _audioListener;
    public AudioListener AudioListener => _audioListener != null ? _audioListener :
         Camera.TryGetComponent(out AudioListener ao) ? _audioListener = ao :
        _audioListener = Camera.gameObject.AddComponent<AudioListener>();
}
