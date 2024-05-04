using System;
using System.ServiceModel;
using ASM.EmployeeManagementAPIUIClientConsole.Utility;

namespace ASM.EmployeeManagementAPIUIClientConsole.Mid
{
    public class APIUICallerBase
    {
        #region Constant

        public const string endpointUrl = "http://localhost/EmployeeManagementWebAPIUI/EmployeeManagementWebAPIUIService.svc";

        #endregion

        #region public methods

        /// <summary>
        /// Return reference of APIUI
        /// </summary>
        /// <param name="endPointUrl"></param>
        /// <returns></returns>
        public static APIUIClient.EmployeeManagementWebAPIUIServiceClient GetAPIUIServiceObject(string endPointUrl)
        {
            APIUIClient.EmployeeManagementWebAPIUIServiceClient objService = null;
            try
            {
                // BasicHttpsBinding objBinding = new BasicHttpsBinding(); -- For https
                BasicHttpBinding objBinding = new BasicHttpBinding();

                objBinding.CloseTimeout = new TimeSpan(Constants.OpenCloseTimeoutHr,
                                              Constants.OpenCloseTimeoutMin, Constants.OpenCloseTimeoutSec);
                objBinding.OpenTimeout = new TimeSpan(Constants.OpenCloseTimeoutHr,
                                              Constants.OpenCloseTimeoutMin, Constants.OpenCloseTimeoutSec);

                objBinding.SendTimeout = new TimeSpan(Constants.SendReceiveTimeoutHr,
                                             Constants.SendReceiveTimeoutMin, Constants.SendReceiveTimeoutSec);
                objBinding.ReceiveTimeout = new TimeSpan(Constants.SendReceiveTimeoutHr,
                                             Constants.SendReceiveTimeoutMin, Constants.SendReceiveTimeoutSec);

                objBinding.MaxBufferSize = Constants.MaxBuffSize;
                objBinding.MaxReceivedMessageSize = Constants.MaxReceiveMsgSize;

                EndpointAddress objEndpoint = new EndpointAddress(endPointUrl);
                objService = new APIUIClient.EmployeeManagementWebAPIUIServiceClient(objBinding, objEndpoint);

                return objService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
