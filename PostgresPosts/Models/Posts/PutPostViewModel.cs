namespace PostgresPosts.Models.Posts
{
    public record PutPostViewModel
    {
        public Guid PostId { get; set; }
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
