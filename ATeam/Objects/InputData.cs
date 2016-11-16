using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Objects
{
    using System.ComponentModel;

    using ATeam.Helpers;

    public class InputData
    {
        public InputData()
        {
            ObjectHelper.SetDefaultValues(this);
        }

        [DefaultValue("ateam1@pgs-soft.com")]
        public string UserName { get; set; }

        [DefaultValue("YhBQWmtQLt")]
        public string Password { get; set; }
    }
}
