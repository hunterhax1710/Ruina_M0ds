using CustomMapUtility;

namespace HunterHax
{
    public class HunterHaxMapManager : CustomMapManager
    {
        protected override string[] CustomBGMs
        {
            get
            {
                // Put the file name of your BGM here, you don't need the full path.
                return new string[] { "HunterHaxBGM.mp3" };
            }



        }

    }
    
    
}