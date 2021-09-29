using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contoso.Models
{
    /// <summary>
    /// Model of users.
    /// </summary>
    public class UsersOutput
    {   /// <summary>
        /// List of users.
        /// </summary>
        public List<User> Users;
    }
    /// <summary>
    /// Model of one user.
    /// </summary>
    public class User
    { 
        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Device name.
        /// </summary>
        public string Device { get; set; }
        /// <summary>
        /// Login time.
        /// </summary>
        public DateTime LoginTime { get; set; }
        /// <summary>
        /// Login from unexpected country
        /// </summary>
        public UnexceptedLogin UnexceptedLogin { get; set; }
    }
    /// <summary>
    /// Model of unexcepted login.
    /// </summary>
    public class UnexceptedLogin
    {
        /// <summary>
        /// The country from which the unexpected login was made.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Login time.
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}