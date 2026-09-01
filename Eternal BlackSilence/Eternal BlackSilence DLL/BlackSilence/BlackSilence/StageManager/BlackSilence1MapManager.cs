
using CustomMapUtility;
namespace BlackSilence
{
        public class BlackSilence1MapManager : CustomMapManager
        {
            protected override string[] CustomBGMs
            {
                get
                {
                    // Put the file name of your BGM here, you don't need the full path.
                    return new string[] { "BlackSilence1BGM.mp3" };
                }
            }

        }
}
