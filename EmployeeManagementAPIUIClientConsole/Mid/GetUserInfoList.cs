using System;

namespace ASM.EmployeeManagementAPIUIClientConsole.Mid
{
    /// <summary>
    /// GetUserInfoList
    /// </summary>
    public class GetUserInfoList : APIUICallerBase

    {
        #region public methods

        /// <summary>
        /// CallGetUserInfoList
        /// </summary>
        /// <param name="objAuthInfo"></param>
        /// <param name="objPaging"></param>
        /// <returns></returns>
        public static APIUIClient.ResGetUserInfoList CallGetUserInfoList(APIUIClient.AuthenticationInfo objAuthInfo, APIUIClient.Paging objPaging, APIUIClient.UserFilterInfo objFilterInfo)
        {
            try
            {
                APIUIClient.EmployeeManagementWebAPIUIServiceClient objService = GetAPIUIServiceObject(endpointUrl);
                APIUIClient.ResGetUserInfoList objResponse =  objService.GetUserInfoList(objAuthInfo, objPaging, objFilterInfo);
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
