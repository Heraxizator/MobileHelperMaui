using MobileHelperMaui.Domain.Abstractions;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.Specifications
{
    public class QuotValidateSpecification : Specification<Quot>
    {
        public QuotValidateSpecification() 
        { 
        }

        public override Expression<Func<Quot, bool>> ToExpression()
        {
            return quot => quot.Author.Length > 0 && quot.Text.Length > 0;
        }
    }
}
