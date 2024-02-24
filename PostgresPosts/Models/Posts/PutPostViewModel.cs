namespace PostgresPosts.Models.Posts
{
    public record PutPostViewModel
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }
    }
}
