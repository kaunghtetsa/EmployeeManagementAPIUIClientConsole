namespace ASM.EmployeeManagementAPIUIClientConsole.Utility
{
    public class Constants
    {
        /// <summary>
        /// Open/Close timeout hour
        /// </summary>
        public const int OpenCloseTimeoutHr = 0;

        /// <summary>
        /// Open/Close timeout minute
        /// </summary>
        public const int OpenCloseTimeoutMin = 1;

        /// <summary>
        /// Open/Close timeout second
        /// </summary>
        public const int OpenCloseTimeoutSec = 30;

        /// <summary>
        /// Send/Receive timeout hour
        /// </summary>
        public const int SendReceiveTimeoutHr = 0;

        /// <summary>
        /// Send/Receive timeout minute
        /// </summary>
        public const int SendReceiveTimeoutMin = 10;

        /// <summary>
        /// Send/Receive timeout second
        /// </summary>
        public const int SendReceiveTimeoutSec = 0;

        /// <summary>
        /// Maximum buffer size
        /// </summary>
        public const int MaxBuffSize = int.MaxValue;

        /// <summary>
        /// Maximum receive message size
        /// </summary>
        public const int MaxReceiveMsgSize = int.MaxValue;

        /// <summary>
        /// GetUserInfoListAPICode
        /// </summary>
        public const string GetUserInfoListAPICode = "USERLIST";

        /// <summary>
        /// GetUserInfoAPICode
        /// </summary>
        public const string GetUserInfoAPICode = "USERINFO";

        /// <summary>
        /// ResultCodeNack
        /// </summary>
        public const string ResultCodeNack = "2";

        /// <summary>
        /// ResultCodeAck
        /// </summary>
        public const string ResultCodeAck = "1";

        /// <summary>
        /// Table Width
        /// </summary>
        public const int TableWidth = 150;

        /// <summary>
        /// eGender
        /// </summary>
        public enum eGender
        {
            Male = 1,
            Female = 2
        }
    }
}
