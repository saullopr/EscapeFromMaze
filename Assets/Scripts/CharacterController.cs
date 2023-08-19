using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [SerializeField] private CollisionChecker _collisionChecker;

    private Vector2 _moveDirection;
    private Vector3 _originalPosition;

    private GameObject[] wall;

    public GameObject victoryPanel;
    public GameObject gameOverPanel;

    private void Awake() {
        _originalPosition = transform.position;

        wall = GameObject.FindGameObjectsWithTag("Wall");
    }

    private void Update() {
        //if (_collisionChecker.Collided) {
        //    ResetPosition();
        //    
        //    return;
        //}
        
        var vertical = (Input.GetKey(KeyCode.W) ? 1 : 0) + (Input.GetKey(KeyCode.S) ? -1 : 0);
        var horizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) + (Input.GetKey(KeyCode.D) ? 1 : 0);
        var rotate = (Input.GetKey(KeyCode.Q) ? -1 : 0) + (Input.GetKey(KeyCode.E) ? 1 : 0);

        transform.Translate(horizontal * Time.deltaTime * _moveSpeed, 0, vertical * Time.deltaTime * _moveSpeed);
        transform.Rotate(0, rotate * _rotateSpeed * Time.deltaTime, 0);
    }

    private void ResetPosition() {
        transform.position = _originalPosition;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            gameOverPanel.gameObject.SetActive(true);
            ResetPosition();
            Invoke("DeactivateCanvas", 2);
            //new WaitForSeconds(2);
            //gameOverPanel.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Victory")
        {

            Invoke("DeactivateCanvas", 2);
            ResetPosition();
        }
    }

    private void DeactivateCanvas()
    {
        gameOverPanel.gameObject.SetActive(false);
        victoryPanel.gameObject.SetActive(false);
    }
}