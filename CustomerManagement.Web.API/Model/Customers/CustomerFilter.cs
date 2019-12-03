using CustomerManagement.Web.API.Model.Builder;
using CustomerManagement.Web.API.Security;
using CustomerManagement.Web.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CustomerManagement.Web.API.Model.Customers
{
    public class CustomerFilter
    {
        public string Classification { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public DateTime LastPurchaseStart { get; set; }
        public DateTime LastPurchaseEnd { get; set; }
        public string Seller { get; set; }

        public Expression<Func<Customer, bool>> ToPredicate(CurrentUser currentUser)
        {
            Expression<Func<Customer, bool>> expressions = (x => true);

            if (!String.IsNullOrEmpty(Classification))
            {
                expressions = expressions.And(x => x.Classification.ToLower().Contains(Classification.ToLower()));
            }

            if (!String.IsNullOrEmpty(Name))
            {
                expressions = expressions.And(x => x.Name.Contains(Name));
            }
            
            if (!String.IsNullOrEmpty(Gender))
            {
                expressions = expressions.And(x => x.Gender.Equals(Gender));
            }
            
            if (!String.IsNullOrEmpty(Region))
            {
                expressions = expressions.And(x => x.Region.Equals(Region));
            }
            
            if (LastPurchaseStart > DateTime.MinValue)
            {
                expressions = expressions.And(x => x.LastPurchase.Date >= LastPurchaseStart.Date);
            }
            if (LastPurchaseEnd > DateTime.MinValue)
            {
                expressions = expressions.And(x => x.LastPurchase.Date <= LastPurchaseEnd.Date);
            }
                        
            if (currentUser.IsAdministrator && !String.IsNullOrEmpty(Seller))
            {
                expressions = expressions.And(x => x.Seller.Name.Equals(Seller));
            }

            if (!currentUser.IsAdministrator)
            {
                expressions = expressions.And(x => x.Seller.Email.Equals(currentUser.Email));
            }

            return expressions;
        }

    }
}
