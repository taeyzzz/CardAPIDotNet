using System;

namespace Domain.Commons
{
    public abstract class BaseEntity{ 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}