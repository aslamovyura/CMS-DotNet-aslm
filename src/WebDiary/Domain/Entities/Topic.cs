namespace Domain.Entities
{
    /// <summary>
    /// Initialize object of the topic class.
    /// </summary>
    public class Topic
    {
        /// <summary>
        /// Topic identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Topic main content.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Post identifier.
        /// </summary>
        public int PostId { get; set; }

        /// <summary>
        /// Post.
        /// </summary>
        public Post Post { get; set; }
    }
}