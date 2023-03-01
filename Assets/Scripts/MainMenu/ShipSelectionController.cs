using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class ShipSelectionController : MonoBehaviour
    {
        [SerializeField] private SpaceShip shipPrefab;

        [SerializeField] private TextMeshProUGUI  shipName, hitpoints, speed, agility;

        [SerializeField] private Image previewImage;

        [SerializeField] private GameObject mainMenu, shipSelectPanel;

        private void Start()
        {
            if(shipPrefab != null)
            {
                previewImage.sprite = shipPrefab.PreviewImage;
                shipName.text = shipPrefab.ShipType;

                hitpoints.text = "HP: " + shipPrefab.Hitpoints.ToString();
                speed.text = "Speed: " + shipPrefab.Speed.ToString();
                agility.text = "Agility: " + shipPrefab.Agility.ToString();
            }
        }


        public void OnSelectShip()
        {
            LevelSequenceController.PlayerShip = shipPrefab;

            MainMenuController.Instance.gameObject.SetActive(true);

            shipSelectPanel.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}