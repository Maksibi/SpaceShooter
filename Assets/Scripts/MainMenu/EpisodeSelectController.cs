using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class EpisodeSelectController : MonoBehaviour
    {
        [SerializeField] private Episode episode;

        [SerializeField] private TextMeshProUGUI episodeNickname;

        [SerializeField] private Image previewImage;

        private void Start()
        {
            if(episodeNickname != null )  episodeNickname.text = episode.EpisodeName;

            if (previewImage != null) previewImage.sprite = episode.PreviewImage;
        }
        public void OnStartEpisodeButtonClick()
        {
            LevelSequenceController.Instance.StartEpisode(episode);
        }
    }
}