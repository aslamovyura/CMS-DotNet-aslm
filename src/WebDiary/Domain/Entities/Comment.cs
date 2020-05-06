using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Initialize object of comment class.
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// Comment identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Comment main content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Publication date/
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Post identifier.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Post.
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// Author identifier.
        /// </summary>
        //[ForeignKey("User")]
        public virtual string UserId { get; set; }

        /// <summary>
        /// Author.
        /// </summary>
        //[ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}