using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDRestfulAPI.Models
{
    public class APIServiceResponse
    {

        private string msgResponseId;
        public string ResponseId
        {
            get { return msgResponseId; }
            set { msgResponseId = value; }
        }

        private string msgResponseDateTime;
        public string ResponseDateTime
        {
            get { return msgResponseDateTime; }
            set { msgResponseDateTime = value; }
        }

        private bool msgResponseStatus;
        public bool ResponseStatus
        {
            get { return msgResponseStatus; }
            set { msgResponseStatus = value; }
        }

        private string msgResponseMessage;
        public string ResponseMessage
        {
            get { return msgResponseMessage; }
            set { msgResponseMessage = value; }
        }

        private string msgRequestId;
        public string RequestId
        {
            get { return msgRequestId; }
            set { msgRequestId = value; }
        }

        private string msgResponseBusinessData;
        public string ResponseBusinessData
        {
            get { return msgResponseBusinessData; }
            set { msgResponseBusinessData = value; }
        }

        private string msgFunctionId;
        public string FunctionId
        {
            get { return msgFunctionId; }
            set { msgFunctionId = value; }
        }

        private string msgBranchId;
        public string BranchId
        {
            get { return msgBranchId; }
            set { msgBranchId = value; }
        }

        private string msgUserId;
        public string UserId
        {
            get { return msgUserId; }
            set { msgUserId = value; }
        }

        private string msgInstitueId;
        public string InstitueId
        {
            get { return msgInstitueId; }
            set { msgInstitueId = value; }
        }

        private string msgSessionId;
        public string SessionId
        {
            get { return msgSessionId; }
            set { msgSessionId = value; }
        }

        private string msgRequestDateTime;
        public string RequestDateTime
        {
            get { return msgRequestDateTime; }
            set { msgRequestDateTime = value; }
        }
    }
}