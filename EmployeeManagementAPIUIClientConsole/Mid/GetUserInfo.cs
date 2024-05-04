using System;

namespace ASM.EmployeeManagementAPIUIClientConsole.Mid
{
    /// <summary>
    /// GetUserInfo
    /// </summary>
    public class GetUserInfo : APIUICallerBase
    {
        #region public methods

        /// <summary>
        /// CallGetUserInfoList
        /// </summary>
        /// <param name="objAuthInfo"></param>
        /// <param name="objPaging"></param>
        /// <returns></returns>
        public static APIUIClient.ResGetUserInfo CallGetUserInfo(APIUIClient.AuthenticationInfo objAuthInfo, string userID)
        {
            try
            {
                APIUIClient.EmployeeManagementWebAPIUIServiceClient objService = GetAPIUIServiceObject(endpointUrl);
                APIUIClient.ResGetUserInfo objResponse = objService.GetUserInfo(objAuthInfo, userID);
                objService.Close();

                return objResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
