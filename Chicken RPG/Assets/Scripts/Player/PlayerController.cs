using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed;
    public float SkateboardSpeed;
    public float JumpForce;
    public GameObject Skateboard;

    private Rigidbody _rigidbody;
    private Camera _camera;
    private float _skateboardSpeed;
    private bool _grounded;

	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = FindObjectOfType<Camera>();
	}
	
	void Update ()
    {
        //Get the raycast of the mouse
        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            //Get the mouse position
            Vector3 mousePosition = cameraRay.GetPoint(rayLength);

            //Turn player towards mouse position
            transform.LookAt(new Vector3(mousePosition.x, transform.position.y, mousePosition.z));
        }

        //Jump
         if(Input.GetKeyDown(KeyCode.Space) && _grounded)
            _rigidbody.AddForce(0, JumpForce, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Skateboard.SetActive(true);
            _skateboardSpeed = SkateboardSpeed;
        }
        else
        {
            Skateboard.SetActive(false);
            _skateboardSpeed = 0;
        }
    }

    void FixedUpdate()
    {
        //Get user input
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 5.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * (MovementSpeed + _skateboardSpeed);

        //Move player
        transform.Translate(x, 0, z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
            _grounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
            _grounded = false;
    }
}
