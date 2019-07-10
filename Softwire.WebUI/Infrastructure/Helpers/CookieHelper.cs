using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MagicApps.Infrastructure.Helpers;

namespace Softwire.WebUI.Infrastructure.Helpers
{
    public class CookieHelper
    {
        public void SetCookies(int referenceId)
        {
            ReferenceId = referenceId;
            Authorised = true;
        }

        public bool Authorised {
            get {
                bool _id = bool.Parse(CustomHelper.GetCookieValue("Softwire-Authorised", Boolean.FalseString));
                return _id;
            }
            set {
                CustomHelper.CreateCookie("Softwire-Authorised", value.ToString());
            }
        }

        public int ReferenceId {
            get {
                int _id = int.Parse(CustomHelper.GetCookieValue("Softwire-ReferenceId"));
                return _id;
            }
            set {
                CustomHelper.CreateCookie("Softwire-ReferenceId", value.ToString());
            }
        }

        public void Flush()
        {
            CustomHelper.CreateCookie("Softwire-Authorised", Boolean.FalseString, -1);
            CustomHelper.CreateCookie("Softwire-ReferenceId", "0", -1);
        }
    }
}