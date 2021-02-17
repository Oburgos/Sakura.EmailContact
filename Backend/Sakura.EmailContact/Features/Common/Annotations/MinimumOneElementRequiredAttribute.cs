using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Sakura.EmailContact.Features.Common.Annotations
{
    public class MinimumOneElementRequiredAttribute : ValidationAttribute
    {
        public MinimumOneElementRequiredAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            IList list = value as IList;
            if (list != null)
            {
                return list.Count > 0;
            }
            return false;
        }
    }
}
