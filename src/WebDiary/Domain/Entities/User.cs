using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    /// <summary>
    /// Application user.
    /// </summary>
    public class User : IdentityUser
    {
        /////// <summary>
        /////// User Identifier.
        /////// </summary>
        ////public override string Id { get => base.Id; set => base.Id = value; }
        //public override string Id { get; set; }

        /// <summary>
        /// User first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User's birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// The list of posts.
        /// </summary>
        public virtual IList<Post> Posts { get; set; }

        /// <summary>
        /// The list of comments.
        /// </summary>
        public virtual IList<Comment> Comments { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public User()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
        }
    }
}