
namespace BL_WebApi2_WS_ADONet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Nullable<short> Gender { get; set; }

        public Nullable<bool> TermCondition { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
    }
}
