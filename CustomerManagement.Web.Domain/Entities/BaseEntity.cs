using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Web.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        public bool IsNew { 
            get {
                return Id.Equals(Guid.Empty);
            }
        }
    }
}
