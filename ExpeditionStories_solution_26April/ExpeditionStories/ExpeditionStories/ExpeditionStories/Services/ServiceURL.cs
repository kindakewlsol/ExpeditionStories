using System;
using System.Collections.Generic;
using System.Text;

namespace ExpeditionStories.Services
{
    public class ServiceURL
    {
        private static ServiceURL _ServiceURL;
        public static ServiceURL GetInstance()
        {
            if (_ServiceURL == null)
            {
                _ServiceURL = new ServiceURL();
            }
            return _ServiceURL;
        }

        private static string protocal = "https://";
        
    }
}
