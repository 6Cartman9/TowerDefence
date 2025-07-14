using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TD
{
    public class TextUpdate : MonoBehaviour
    {
        public enum UpdateSource { Gold, Life, Diamont }
        public UpdateSource source;
        private Text m_Text;

        void Start()
        {
            m_Text = GetComponent<Text>();
            switch(source)
            {
                case UpdateSource.Gold:
                    TDPlayer.Instance.GoldUpdateSubscribe(UpdateText);
                    break;
                case UpdateSource.Life:
                    TDPlayer.Instance.LifeUpdateSubscribe(UpdateText);
                    break;
               /* case UpdateSource.Diamont:
                    TDPlayer.Instance.DiamontUpdateSubscribe(UpdateText);
                    break;*/
            }
        }

        private void UpdateText(int text)
        {
            m_Text.text = text.ToString();
        }
    }
}
