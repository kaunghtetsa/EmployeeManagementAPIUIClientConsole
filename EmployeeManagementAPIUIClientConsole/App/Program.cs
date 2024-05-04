using System;

using ASM.EmployeeManagementAPIUIClientConsole.Mid;
using ASM.EmployeeManagementAPIUIClientConsole.Utility;
using static ASM.EmployeeManagementAPIUIClientConsole.Utility.Constants;

namespace ASM.EmployeeManagementAPIUIClientConsole
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        #region Public method

        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter Function Command:");
                string commandCode = Console.ReadLine();

                ProcessCommand(commandCode);

                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        #endregion        

        #region Private methods

        /// <summary>
        /// ProcessCommand
        /// </summary>
        /// <param name="commandCode"></param>
        private static void ProcessCommand(string commandCode)
        {
            try
            {
                switch (commandCode.ToUpper())
                {
                    case Constants.GetUserInfoListAPICode:
                        ProcessGetUserInfoListCommand();
                        break;
                    case Constants.GetUserInfoAPICode:
                        ProcessGetUserInfoCommand();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        Console.WriteLine("For GetUserInfoList API: Enter USERLIST");
                        Console.WriteLine("For GetUserInfo API: Enter USERINFO");
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// RequestAuthenticationInfo
        /// </summary>
        /// <returns></returns>
        private static APIUIClient.AuthenticationInfo RequestAuthenticationInfo()
        {
            try
            {
                APIUIClient.AuthenticationInfo authenticationInfo = new APIUIClient.AuthenticationInfo();

                Console.Write("Enter LoginID:");
                authenticationInfo.LoginID = Console.ReadLine();

                Console.Write("Enter Password:");
                authenticationInfo.Password = Console.ReadLine();

                return authenticationInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region GetUserInfoList API

        /// <summary>
        /// ProcessGetUserInfoListCommand
        /// </summary>
        private static void ProcessGetUserInfoListCommand()
        {
            try
            {
                // Request Input
                bool isValidInput = GetRequestDataOfGetUserInfoList(out APIUIClient.AuthenticationInfo objAuthInfo, out APIUIClient.Paging objPaging,
                    out APIUIClient.UserFilterInfo objFilterInfo);

                if (!isValidInput)
                {
                    return;
                }

                // Call GetUserInfoList API
                APIUIClient.ResGetUserInfoList objResponse = GetUserInfoList.CallGetUserInfoList(objAuthInfo, objPaging, objFilterInfo);

                // Display result
                DisplayGetUserInfoListResult(objResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetRequestDataOfGetUserInfoList
        /// </summary>
        /// <param name="objAuthInfo"></param>
        /// <param name="objPaging"></param>
        /// <param name="objFilterInfo"></param>
        /// <returns></returns>
        private static bool GetRequestDataOfGetUserInfoList(out APIUIClient.AuthenticationInfo objAuthInfo, out APIUIClient.Paging objPaging,
                            out APIUIClient.UserFilterInfo objFilterInfo)
        {
            objAuthInfo = null;
            objPaging = null;
            objFilterInfo = null;

            try
            {
                // Get Authentication Info
                objAuthInfo = RequestAuthenticationInfo();

                // Get Paging Info
                objPaging = RequestPagingInfo(out bool isValidInput);
                if (!isValidInput)
                {
                    Console.WriteLine("Input can only be numbers.");
                    return false;
                }

                // Get Filter Info
                objFilterInfo = RequestUserFilterInfo();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// RequestPagingInfo
        /// </summary>
        /// <param name="isValidInput"></param>
        /// <returns></returns>
        public static APIUIClient.Paging RequestPagingInfo(out bool isValidInput)
        {
            isValidInput = true;
            try
            {
                APIUIClient.Paging paging = new APIUIClient.Paging();
                string input = null;
                int num = 0;

                if (isValidInput)
                {
                    Console.Write("Enter page size(0 to 1000):");
                    input = Console.ReadLine();

                    if (!int.TryParse(input, out num))
                    {
                        isValidInput = false;
                    }
                    paging.Num = num;
                }

                if (isValidInput)
                {
                    Console.Write("Enter page start index(Start from 0):");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out num))
                    {
                        isValidInput = false;
                    }
                    paging.StartIndex = num;
                }

                if (isValidInput)
                {
                    Console.Write("Enter sort key(0 to 8):");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out num))
                    {
                        isValidInput = false;
                    }
                    paging.SortKey = num;
                }

                if (isValidInput)
                {
                    Console.Write("Enter sort order(None: 0, ASC: 1, DESC: 2):");
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out num))
                    {
                        isValidInput = false;
                        return null;
                    }
                    paging.SortOrder = num;
                }

                return paging;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// RequestUserFilterInfo
        /// </summary>
        /// <returns></returns>
        private static APIUIClient.UserFilterInfo RequestUserFilterInfo()
        {
            try
            {
                APIUIClient.UserFilterInfo userFilterInfo = new APIUIClient.UserFilterInfo();
                userFilterInfo.IsLikeSearch = true;

                Console.Write("Enter search UserID:");
                userFilterInfo.UserID = Console.ReadLine();

                Console.Write("Enter search Email:");
                userFilterInfo.Email = Console.ReadLine();

                return userFilterInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DisplayGetUserInfoListResult
        /// </summary>
        /// <param name="objResponse"></param>
        private static void DisplayGetUserInfoListResult(APIUIClient.ResGetUserInfoList objResponse)
        {
            try
            {
                if (objResponse.Result.ResultCode == Constants.ResultCodeNack)
                {
                    Console.WriteLine(objResponse.Result.ErrorDetail);
                }
                else
                {
                    DisplayResultUserList(objResponse.UserInfoList);
                    if (objResponse.PagingResult != null)
                    {
                        Console.WriteLine(string.Format("Total Count: {0}", objResponse.PagingResult.HitCount));
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DisplayResultUserList
        /// </summary>
        /// <param name="userInfos"></param>
        private static void DisplayResultUserList(APIUIClient.UserInfo[] userInfos)
        {
            Console.WriteLine();
            CommonUtil.PrintLine(Constants.TableWidth);
            CommonUtil.PrintRow(Constants.TableWidth, "User ID", "User Name", "Department Name", "Gender", "Date of Birth", "Address", "Email", "PhoneNo", "Job Start Date");
            CommonUtil.PrintLine(Constants.TableWidth);

            if(userInfos == null || userInfos.Length == 0)
            {
                return;

            }

            foreach (APIUIClient.UserInfo userInfo in userInfos)
            {
                CommonUtil.PrintRow(Constants.TableWidth, userInfo.UserID, userInfo.UserName, userInfo.DepartmentName, Enum.GetName(typeof(Constants.eGender),
                    userInfo.Gender), userInfo.DateOfBirth, userInfo.Address, userInfo.Email, userInfo.PhoneNo, userInfo.JobStartDate);
            }

            CommonUtil.PrintLine(Constants.TableWidth);
        }

        #endregion

        #region GetUserInfo API

        /// <summary>
        /// ProcessGetUserInfoCommand
        /// </summary>
        private static void ProcessGetUserInfoCommand()
        {
            try
            {
                // Request Input
                GetRequestDataOfGetUserInfo(out APIUIClient.AuthenticationInfo objAuthInfo, out string userID);

                // Call GetUserInfoList API
                APIUIClient.ResGetUserInfo objResponse = GetUserInfo.CallGetUserInfo(objAuthInfo, userID);

                // Display result
                DisplayGetUserInfoResult(objResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// GetRequestDataOfGetUserInfo
        /// </summary>
        /// <param name="objAuthInfo"></param>
        /// <param name="userID"></param>
        private static void GetRequestDataOfGetUserInfo(out APIUIClient.AuthenticationInfo objAuthInfo, out string userID)
        {
            objAuthInfo = null;
            userID = null;

            try
            {
                // Get Authentication Info
                objAuthInfo = RequestAuthenticationInfo();

                // Get UserID
                Console.Write("Enter search UserID:");
                userID = Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DisplayGetUserInfoResult
        /// </summary>
        /// <param name="objResponse"></param>
        private static void DisplayGetUserInfoResult(APIUIClient.ResGetUserInfo objResponse)
        {
            try
            {
                if (objResponse.Result.ResultCode == Constants.ResultCodeNack)
                {
                    Console.WriteLine(objResponse.Result.ErrorDetail);
                }
                else
                {
                    DisplayResultUserInfo(objResponse.UserDetailInfo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// DisplayResultUserInfo
        /// </summary>
        /// <param name="userDetailInfo"></param>
        private static void DisplayResultUserInfo(APIUIClient.UserDetailInfo userDetailInfo)
        {
            if(userDetailInfo == null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("User Info Result");
            Console.WriteLine(string.Format("UserID : {0}", userDetailInfo.UserID));
            Console.WriteLine(string.Format("UserName : {0}", userDetailInfo.UserName));
            Console.WriteLine(string.Format("DepartmentName : {0}", userDetailInfo.DepartmentName));
            Console.WriteLine(string.Format("Gender : {0}", Enum.GetName(typeof(eGender), userDetailInfo.Gender)));
            Console.WriteLine(string.Format("DateOfBirth : {0}", userDetailInfo.DateOfBirth));
            Console.WriteLine(string.Format("Address : {0}", userDetailInfo.Address));
            Console.WriteLine(string.Format("Email: {0}", userDetailInfo.Email));
            Console.WriteLine(string.Format("PhoneNo : {0}", userDetailInfo.PhoneNo));
            Console.WriteLine(string.Format("JobStartDate : {0}", userDetailInfo.JobStartDate));
        }

        #endregion
    }
}
