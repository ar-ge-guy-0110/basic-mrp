using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicMRP
{
    class cs_pm
    {
        //
        //User
        //

        public static string logged_user = "";
        public static int logged_user_id = -1;
        public static int logged_user_authority = -1;

        //
        //Forms
        //

        public static Form mainloginform;

        //
        //Form Controls
        //

        public static TextBox usernamebox;
        public static TextBox passwordbox;
        public static Label loginlabel;
    }
}
