using CustomMapUtility;
namespace BlackSilence
{
    public class BlackSilence2MapManager : CustomMapManager
    {
        protected override string[] CustomBGMs
        {
            get
            {
                // Put the file name of your BGM here, you don't need the full path.
                return new string[] { "BlackSilence2BGM.mp3" };
            }
        }

    }
}
