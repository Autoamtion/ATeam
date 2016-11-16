using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Helpers
{
    using System.ComponentModel;

    public class ObjectHelper
    {
        public static void SetDefaultValues(object values)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(values))
            {
                DefaultValueAttribute myAttribute =
                    (DefaultValueAttribute)property.Attributes[typeof(DefaultValueAttribute)];

                if (myAttribute != null)
                {
                    property.SetValue(values, myAttribute.Value);
                }
            }
        }
    }
}
