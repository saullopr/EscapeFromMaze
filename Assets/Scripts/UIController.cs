using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIController : UIBehaviour {
    [SerializeField] private CollisionChecker _collisionChecker;
    [SerializeField] private TMP_Text _distanceText;
    [SerializeField] private GameObject _gameOverPanel;

    private void Update() {
        _distanceText.text = $"Closest wall: {_collisionChecker.Distance:F2}m";

        //_gameOverPanel.gameObject.SetActive(_collisionChecker.Collided);
    }
}