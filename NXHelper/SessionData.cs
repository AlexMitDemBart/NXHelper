using NXOpen;
using NXOpen.UF;

namespace NXHelper
{
    public class SessionData
    {
        public Session TheSession { get; set; }
        public UFSession TheUFSession { get; set; }
        public Part TheWorkpart { get; set; }
        public UI TheUI { get; set; }

        public SessionData()
        {
            Initialize();
        }

        /// <summary>
        /// Initialize the SiemensNX session data
        /// </summary>
        private void Initialize()
        {
            this.TheSession = Session.GetSession();
            this.TheUFSession = UFSession.GetUFSession();
            this.TheWorkpart = Session.GetSession().Parts.Work;
            this.TheUI = UI.GetUI();
        }
    }
}
