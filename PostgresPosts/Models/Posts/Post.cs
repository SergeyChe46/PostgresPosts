namespace PostgresPosts.Models.Posts
{
    public record Post
    {
        public Guid PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
