using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoUI.Model
{
    public class APIServiceResponse
    {
       
        private string _STATUS;
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        private string _MESSAGE;
        public string MESSAGE
        {
            get { return _MESSAGE; }
            set { _MESSAGE = value; }
        }

        private string msgResponseBusinessData;
        public string ResponseBusinessData
        {
            get { return msgResponseBusinessData; }
            set { msgResponseBusinessData = value; }
        }
    }
}