namespace PostgresPosts.Models.Posts
{
    public class Post
    {
        public Guid PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
