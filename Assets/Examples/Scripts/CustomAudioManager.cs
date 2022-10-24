/*
 *	Created by:  Peter @sHTiF Stefcek
 */

using Dash;

namespace Examples.Scripts
{
    public class CustomAudioManager : IAudioManager
    {
        public void PlayAudio(string p_audioName, float p_volume)
        {
            throw new System.NotImplementedException();
        }

        public bool HasAudio(string p_audioName)
        {
            throw new System.NotImplementedException();
        }

        public string[] GetAudioNames()
        {
            return new string[]{"aaa","bbb"};
        }

#if UNITY_EDITOR
        public void PlayAudioPreview(string p_audioName, float p_volume)
        {
            throw new System.NotImplementedException();
        }
#endif
    }
}